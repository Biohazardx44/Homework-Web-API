using MoviesApp.DTOs.MovieDTOs;

namespace MoviesApp.Services.Abstraction
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto registerUserDto);
        string LoginUser(LoginUserDto loginUserDto);
        void ChangePassword(ChangePasswordDto changePasswordDto);
    }
}