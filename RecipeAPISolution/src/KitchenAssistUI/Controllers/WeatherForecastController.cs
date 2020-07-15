using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KitchenAssistUI.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
               Id = 1,
               Title = "Recipe 1",
               Ingredients = "Eggs, Bread, Cheese",
               Instructions = "just make it",
               Description = "Its real good",
               Source = "google.com",
               Rating = 5,
               PrepTime = "30 min"
            })
            .ToArray();

            //return Enumerable.Range(1,5).Select(index => new WeatherForecast
            //{
            //    Id = 1,
            //    Title = "Recipe 1",
            //    Ingredients = "Eggs, Bread, Cheese",
            //    Instructions = "just make it",
            //    Description = "Its real good",
            //    Source = "google.com",
            //    Rating = 5,
            //    PrepTime = "30 min"
            //}).ToArray();
        }
    }
}
