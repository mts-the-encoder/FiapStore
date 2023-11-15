using FiapStore.Dtos;
using FiapStore.Interface;
using FiapStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Configurations;

[ApiController]
[Route("login")]
public class LoginController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;
    public LoginController(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    [HttpPost]
    public IActionResult Authenticate(LoginDto loginDto)
    {
        var user = _repository.GetByNameAndPassword(loginDto.Username, loginDto.Password);
        
        if (user == null)
        {
            return NotFound("Not Found");
        }

        var token = _tokenService.GenerateToken(user);

        user.Password = null;

        return Ok($"Bearer: {token}");
    }
}