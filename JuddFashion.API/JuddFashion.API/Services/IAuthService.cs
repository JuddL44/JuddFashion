using JuddFashion.API.Models.DTOs;

namespace JuddFashion.API.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDTO?> Register(RegisterDTO RegisterDto);
        Task<AuthResponseDTO?> Login(LoginDTO LoginDto);
        Task<UserDTO?> GetUserById(int userId);
    }
}
