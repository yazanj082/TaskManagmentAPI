using TasksAPI.Business.Dtos;

namespace TasksAPI.Business.Services
{
    public interface IAuthService
    {
        bool RegisterUser(UserRegistrationDto userForRegistration);
        int? ValidateUser(UserLoginDto loginDto);
    }
}
