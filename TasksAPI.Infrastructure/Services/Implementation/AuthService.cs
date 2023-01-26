using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Business.Dtos;
using TasksAPI.Persistence.Data;
using TasksAPI.Persistence.Repsitories;
using TasksAPI.Persistence.Repsitories.Implementation;

namespace TasksAPI.Business.Services.Implementation
{
    public class AuthService : IAuthService
    { 
        private readonly ILogger<AuthService> _logger;
        private readonly IUserRepository _userRepository;
        public AuthService(ILogger<AuthService> logger, IUserRepository userRepository) { 
            _logger = logger;
            _userRepository = userRepository;
        }

        public bool RegisterUser(UserRegistrationDto userForRegistration)
        {
            var toCreate = new UserData() { UserName = userForRegistration.UserName, Password = userForRegistration.Password };
            var user = _userRepository.Add(toCreate).Result;
            if (user > 0)
            {
                return true;
            }
            return false;
        }

        public int? ValidateUser(UserLoginDto loginDto)
        {
            var toCheck = new UserData() { UserName = loginDto.UserName, Password = loginDto.Password};
            var user = _userRepository.GetByUserNameAndPassword(toCheck).Result;
            if (user != null)
            {
                return user.Id;
            }
            return null;
        }
    }
}
