using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAuthManager authManager, ILogger<AccountController> logger)
        {
            this._authManager = authManager;
            this._logger = logger;
        }

        // POST: api/Account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] ApiUserDTO apiUserDto)
        {
            _logger.LogInformation($"Registration Attempt for {apiUserDto.Email}");
            var errors = await _authManager.Register(apiUserDto);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        // POST: api/Account/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO loginDto)
        {
            _logger.LogInformation($"Login Attempt for {loginDto.Email} ");
            var authResponse = await _authManager.Login(loginDto);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);

        }

        // POST: api/Account/refreshtoken
        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto request)
        {
            var authResponse = await _authManager.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }



        //private readonly UserManager<ApiUser> _userManager;

        //private readonly ILogger<AccountController> _logger;
        //private readonly IMapper _mapper;
        //private readonly IAuthManager _authManager;

        //public AccountController(UserManager<ApiUser> userManager,
        //    ILogger<AccountController> logger, IMapper mapper,
        //    IAuthManager authManager)
        //{
        //    _userManager = userManager;
        //    _logger = logger;
        //    _mapper = mapper;
        //    _authManager = authManager;
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status202Accepted)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Route("register")]
        //public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        //{
        //    _logger.LogInformation($"Registration Attempt for {userDTO.Email} ");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        var user = _mapper.Map<ApiUser>(userDTO);
        //        user.UserName = userDTO.Email;
        //        var result = await _userManager.CreateAsync(user, userDTO.Password);

        //        if (!result.Succeeded)
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(error.Code, error.Description);
        //            }
        //            return BadRequest(ModelState);
        //        }
        //        foreach (var role in userDTO.Roles)
        //        {
        //            await _userManager.AddToRoleAsync(user, role);
        //        }
        //        return Accepted();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
        //        return Problem($"Something Went Wrong in the {nameof(Register)}",
        //            statusCode: 500);
        //    }
        //}

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        //{
        //    _logger.LogInformation($"Login Attempt for {userDTO.Email} ");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        if (!await _authManager.ValidateUser(userDTO))
        //        {
        //            return Unauthorized();
        //        }

        //        return Accepted(new TokenRequest
        //        {
        //            Token = await _authManager.CreateToken(),
        //            RefreshToken = await _authManager.CreateRefreshToken()
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
        //        return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
        //    }
        //}

        //[HttpPost]
        //[Route("refreshtoken")]
        //public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        //{
        //    var tokenRequest = await _authManager.VerifyRefreshToken(request);
        //    if (tokenRequest is null)
        //    {
        //        return Unauthorized();
        //    }

        //    return Ok(tokenRequest);
        //}
    }
}
