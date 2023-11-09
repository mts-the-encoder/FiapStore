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

    [HttpPost]
    public IActionResult Create(User user)
    {
        _repository.Create(user);
        return Created(string.Empty, user);
    }

    [HttpPut]
    public IActionResult Update(User user)
    {
        _repository.Update(user);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repository.Delete(id);
        return Ok("User Deleted!");
    }
}