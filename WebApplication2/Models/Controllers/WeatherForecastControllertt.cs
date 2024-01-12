using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastControllertt : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastControllertt> _logger;

    public WeatherForecastControllertt(ILogger<WeatherForecastControllertt> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecastt")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}