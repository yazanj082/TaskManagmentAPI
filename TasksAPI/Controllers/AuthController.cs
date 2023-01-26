using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Business.Dtos;
using TasksAPI.Business.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using TasksAPI.Extentions;

namespace TasksAPI.Controllers;


[Route("api/userauthentication")]
[ApiController]
public class AuthController : ControllerBase
{
    readonly private IAuthService _service;
    readonly private IConfiguration _config;
    readonly private ILogger<AuthController> _logger;
    public AuthController(IConfiguration config,IAuthService service, ILogger<AuthController> logger)
    {
        _service = service;
        _config = config;
        _logger = logger;
    }

    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] UserRegistrationDto userRegistration)
    {
        try
        {
            var userResult = _service.RegisterUser(userRegistration);
            return userResult? Ok() : StatusCode(201);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPost("login")]
    public IActionResult Authenticate([FromBody] UserLoginDto user)
    {
        try
        {
            var vUser = _service.ValidateUser(user);
            if (vUser != null)
            {
                var stringToken = JwtExtention.Encode(vUser, _config);
                return Ok(stringToken);
            }
            return Unauthorized();
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(); 
        }
    }

}
