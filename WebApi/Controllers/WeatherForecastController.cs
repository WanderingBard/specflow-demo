using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly Dictionary<string,string> Summaries = new Dictionary<string, string>
        {
            {"Scotland", "Freezing" },
            {"Wales", "Bracing" },
            {"England", "Chilly" }
            //"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "place/{placeName}")]
        public WeatherForecast Get(string placeName)
        {
            var summary = Summaries[placeName];
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summary,
                Place = placeName
            };
        }
    }
}