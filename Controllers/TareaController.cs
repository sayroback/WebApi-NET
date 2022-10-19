using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TareaController : ControllerBase
  {
    ITareasService tareasService;
    
    public TareaController(ITareasService service)
    {
      tareasService = service;
    }

    // GET: api/<TareaController>
    [HttpGet]
    public IActionResult Get()
    {
      return Ok(tareasService.Get());
    }

    // GET api/<TareaController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<TareaController>
    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
      tareasService.Save(tarea);
      return Ok();
    }

    // PUT api/<TareaController>/5
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
      tareasService.Update(id, tarea);
      return Ok();
    }

    // DELETE api/<TareaController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
      tareasService.Delete(id);
      return Ok();
    }
  }
}
