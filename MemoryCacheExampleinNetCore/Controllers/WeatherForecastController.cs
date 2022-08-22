using MemoryCacheExampleinNetCore.Models;
using MemoryCacheExampleinNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemoryCacheExampleinNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCacheService _memoryCacheService;
        private readonly ITeamService _teamService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,IMemoryCacheService memoryCacheService,ITeamService teamService)
        {
            _logger = logger;
            _memoryCacheService = memoryCacheService;
            _teamService = teamService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet(Name = "GetTeamSquad")]
        public TeamSquad GetTeamSquad()
        {
            return _memoryCacheService.GetTeamSquad();
        }
    }
}