using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  IHelloWorldServices helloWorldServices;
  public HelloWorldController(IHelloWorldServices helloWorld)
  {
    helloWorldServices = helloWorld;
  }
  public IActionResult Get()
  {
    return Ok(helloWorldServices.GetHelloWorld());
  }
}
