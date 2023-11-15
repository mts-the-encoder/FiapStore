using System.Reflection.PortableExecutable;
using FiapStore.Dtos;
using FiapStore.Entities;
using FiapStore.Enums;
using FiapStore.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers;

[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly ILogger<UserController> _logger;
    public UserController(IUserRepository repository, ILogger<UserController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            throw new Exception("Error");
            var users = _repository.GetAll();
            return Ok(users);
        }
        catch (Exception e)
        {
           _logger.LogError(e,$"{DateTime.Now} | ex: {e.Message}");
           return BadRequest();
        }
    }

    [Authorize]
    [Authorize(Roles = $"{Permissions.Admin}, {Permissions.Employee}")]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        _logger.LogInformation("Executando");
        var user = _repository.GetById(id);
        return Ok(user);
    }

    [Authorize]
    [Authorize(Roles = $"{Permissions.Admin}, {Permissions.Employee}")]
    [HttpGet("orders/{id}")]
    public IActionResult GetOrdersById(int id)
    {
        var user = _repository.GetWithOrders(id);
        return Ok(user);
    }

    [Authorize]
    [Authorize(Roles = $"{Permissions.Admin}, {Permissions.Employee}")]
    [HttpPost]
    public IActionResult Create(CreateUserDto userDto)
    {
        _logger.LogWarning("be careful with req time...");
        _repository.Create(new User(userDto));
        return Created(string.Empty, userDto);
    }

    [HttpPut]
    public IActionResult Update(UpdateUserDto userDto)
    {
        _repository.Update(new User(userDto));
        return Ok(userDto);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repository.Delete(id);
        return Ok("User Deleted!");
    }
}