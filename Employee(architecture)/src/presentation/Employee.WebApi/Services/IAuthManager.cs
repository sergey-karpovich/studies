using EmployeeAPI.Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace EmployeeAPI.Services
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDTO userDto);
        Task<AuthResponseDto> Login(LoginUserDTO loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);

        //Task<bool> ValidateUser(LoginUserDTO userDTO);
        //Task<string> CreateToken();
        //Task<string> CreateRefreshToken();
        //Task<TokenRequest> VerifyRefreshToken(TokenRequest request);
    }
}
