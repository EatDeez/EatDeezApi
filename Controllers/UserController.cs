using Microsoft.AspNetCore.Mvc;
using EatDeezApi.Models;

namespace EatDeezApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    // mock data
    private static List<User> users = new List<User>
    {
        new User
        {
            Id = 1,
            Name = "John",
            Email = "john@example.com",
            DateOfBirth = new DateTime(1980, 1, 1)
        },
    };
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUsers")]
    public User Get()
    {
        return users[0];
    }

    [HttpPost("Hello/{name}", Name = "GetHelloToName")]
    public string Post(string name)
    {
        return "hello " + name + "!";
    }
}
