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
        return Ok("Success!");
    }

    [HttpGet("Id")]
    public IActionResult GetById()
    {
        return Ok("Success by Id!");
    }

    [HttpPost]
    public IActionResult Create()
    {
        return Created(string.Empty,"User Created!");
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok("User Updated!");
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok("User Deleted!");
    }
}