using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.context;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  IHelloWorldServices helloWorldServices;
  TareasContext dbcontext;

  private readonly ILogger<HelloWorldController> _logger;
  public HelloWorldController(IHelloWorldServices helloWorld, TareasContext db,  ILogger<HelloWorldController> logger)
  {
    dbcontext = db;
    _logger = logger;
    helloWorldServices = helloWorld;
  }
  [HttpGet]
  public IActionResult Get()
  {
    _logger.LogDebug("Retornando un Hola Mundo");
    return Ok(helloWorldServices.GetHelloWorld());
  }
  [HttpGet]
  [Route("createdb")]
  public IActionResult CreateDataBase()
  {
    dbcontext.Database.EnsureCreated();
    return Ok();
  }
}
