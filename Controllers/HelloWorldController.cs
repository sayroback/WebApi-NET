using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  IHelloWorldServices helloWorldServices;
  private readonly ILogger<HelloWorldController> _logger;
  public HelloWorldController(IHelloWorldServices helloWorld, ILogger<HelloWorldController> logger)
  {
    _logger = logger;
    helloWorldServices = helloWorld;
  }
  public IActionResult Get()
  {
    _logger.LogDebug("Retornando un Hola Mundo");
    return Ok(helloWorldServices.GetHelloWorld());
  }
}
