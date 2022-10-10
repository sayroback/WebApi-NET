using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
  private static readonly string[] Summaries = new[]
  {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

  private readonly ILogger<WeatherForecastController> _logger;
  public static List<WeatherForecast> ListWeatherForecasts = new List<WeatherForecast>();
  public WeatherForecastController(ILogger<WeatherForecastController> logger)
  {
    _logger = logger;
    if (ListWeatherForecasts == null || !ListWeatherForecasts.Any())
    {
      ListWeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToList();
    }
  }

  [HttpGet(Name = "GetWeatherForecast")]
  [Route("get/weatherforecast")] // endpoint 
  [Route("get/weatherforecast2")] // endpoint
  [Route("[action]")] // endpoint con el nombre del metodo
  public IEnumerable<WeatherForecast> GetW()
  {
    _logger.LogInformation("Retornando la lista de weather forecast");
    return ListWeatherForecasts;
  }

  [HttpPost]
  public IActionResult Post(WeatherForecast weatherForecast)
  {
    ListWeatherForecasts.Add(weatherForecast);
    return Ok();
  }
  [HttpDelete("{index}")]
  public IActionResult Delete(int index)
  {
    ListWeatherForecasts.RemoveAt(index);
    return Ok();
  }

}
