using Microsoft.AspNetCore.Mvc;

namespace CubeView.Controllers;

[ApiController]
[Route("[controller]/{name}")]
public class HelloWorldController : ControllerBase
{
    private static readonly string Greeting = "Hello!";

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(ILogger<HelloWorldController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetHelloWorld")]
    public HelloWorld Get(string name)
    {
        return new HelloWorld {
            Greeting = Greeting,
            Name = name,
        };
    }
}
