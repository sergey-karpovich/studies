using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeAPI.Services
{
    public class AuthManager : IAuthManager
    {

        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthManager> _logger;
        private ApiUser _user;

        private string issuer;
        private const string _refreshToken = "RefreshToken";

        public AuthManager(UserManager<ApiUser> userManager,
            IConfiguration configuration,
            IMapper mapper,
            ILogger<AuthManager> logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
            issuer = _configuration["Jwt:Issuer"];
            //issuer = _configuration.GetSection("Jwt").GetSection("Issuer").Value;
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, issuer, _refreshToken);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, issuer, _refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(_user, issuer, _refreshToken, newRefreshToken);
            return newRefreshToken;
        }

        public async Task<AuthResponseDto> Login(LoginUserDTO loginDto)
        {
            _logger.LogInformation($"Looking for user with email {loginDto.Email}");
            _user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

            if (_user == null || isValidUser == false)
            {
                _logger.LogWarning($"User with email {loginDto.Email} was not found");
                return null;
            }

            var token = await GenerateToken();
            _logger.LogInformation($"Token generated for user with email {loginDto.Email} | Token: {token}");

            return new AuthResponseDto
            {
                Token = token,
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken()
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDTO userDto)
        {
            _user = _mapper.Map<ApiUser>(userDto);
            _user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(_user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, "User");
            }

            return result.Errors;
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q =>
            q.Type == JwtRegisteredClaimNames.Email)?.Value;
            _user = await _userManager.FindByNameAsync(username);

            if (_user == null || _user.Id != request.UserId)
            {
                return null;
            }

            var isValidRefreshToken = await _userManager
                .VerifyUserTokenAsync(_user, issuer, _refreshToken, request.RefreshToken);

            if (isValidRefreshToken)
            {
                var token = await GenerateToken();
                return new AuthResponseDto
                {
                    Token = token,
                    UserId = _user.Id,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }

        private async Task<string> GenerateToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid", _user.Id),
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert
                .ToInt32(_configuration["Jwt:Lifetime"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //private readonly UserManager<ApiUser> _userManager;
        //private readonly IConfiguration _configuration;
        //private ApiUser _user;

        //public AuthManager(UserManager<ApiUser> userManager,
        //    IConfiguration configuration)
        //{
        //    _userManager = userManager;
        //    _configuration = configuration;
        //}

        //public async Task<string> CreateToken()
        //{
        //    var signingCredentials = GetSigningCredentials();
        //    var claims = await GetClaims();
        //    var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        //    return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //}

        //private JwtSecurityToken GenerateTokenOptions(
        //    SigningCredentials signingCredentials, List<Claim> claims)
        //{
        //    var jwtSettings = _configuration.GetSection("Jwt");
        //    var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(
        //        jwtSettings.GetSection("lifetime").Value));

        //    var token = new JwtSecurityToken(
        //        issuer: jwtSettings.GetSection("Issuer").Value,
        //        claims: claims,
        //        expires: expiration,
        //        signingCredentials: signingCredentials
        //        );
        //    return token;
        //}

        //private async Task<List<Claim>> GetClaims()
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, _user.UserName)
        //    };
        //    var roles = await _userManager.GetRolesAsync(_user);
        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    }

        //    return claims;
        //}

        //private SigningCredentials GetSigningCredentials()
        //{
        //    // если ключ записан в системе
        //    //var key = Environment.GetEnvironmentVariable("KEY");
        //    var key = _configuration["Jwt:Key"];
        //    var secret = new SymmetricSecurityKey(Encoding.UTF8
        //        .GetBytes(key));

        //    return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        //}

        //public async Task<bool> ValidateUser(LoginUserDTO userDTO)
        //{
        //    _user = await _userManager.FindByNameAsync(userDTO.Email);
        //    return (_user != null && await _userManager.CheckPasswordAsync(_user, userDTO.Password));
        //}

        //public async Task<string> CreateRefreshToken()
        //{
        //    var issuer = _configuration.GetSection("Jwt").GetSection("Issuer").Value;
        //    await _userManager.RemoveAuthenticationTokenAsync(_user, issuer, "RefreshToken");
        //    var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, issuer, "RefreshToken");
        //    var result = await _userManager.SetAuthenticationTokenAsync(_user, issuer, "RefreshToken", newRefreshToken);
        //    return newRefreshToken;
        //}

        //public async Task<TokenRequest> VerifyRefreshToken(TokenRequest request)
        //{
        //    var issuer = _configuration.GetSection("Jwt").GetSection("Issuer").Value;

        //    var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        //    var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
        //    var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == ClaimTypes.Name)?.Value;
        //    _user = await _userManager.FindByNameAsync(username);
        //    try
        //    {
        //        var isValid = await _userManager
        //            .VerifyUserTokenAsync(_user, issuer, "RefreshToken",
        //            request.RefreshToken);
        //        if (isValid)
        //        {
        //            return new TokenRequest
        //            {
        //                Token = await CreateToken(),
        //                RefreshToken = await CreateRefreshToken()
        //            };
        //        }
        //        await _userManager.UpdateSecurityStampAsync(_user);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return null;
        //}
    }
}

