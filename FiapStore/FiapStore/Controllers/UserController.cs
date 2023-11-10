using FiapStore.Dtos;
using FiapStore.Entities;
using FiapStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers;

[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _repository.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _repository.GetById(id);
        return Ok(user);
    }

    [HttpGet("orders/{id}")]
    public IActionResult GetOrdersById(int id)
    {
        var user = _repository.GetWithOrders(id);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(CreateUserDto user)
    {
        _repository.Create(new User(user));
        return Created(string.Empty, user);
    }

    [HttpPut]
    public IActionResult Update(UpdateUserDto user)
    {
        _repository.Update(new User(user));
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repository.Delete(id);
        return Ok("User Deleted!");
    }
}