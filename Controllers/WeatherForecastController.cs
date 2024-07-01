using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.DataAccess.Models;

namespace ProjectTemplate.Controllers
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
            //------------------------------------
            // Test User model's validation
            //   in /DataAccess/Validators
            //------------------------------------
            User newUser = new User()
            {
                UserName = "JBStraubel",
                Password = "" //bad password
            };
             

            bool isUserValid = newUser.Validate();

            // log errors if not valid
            if (!isUserValid)
            {
                foreach (string err in newUser.ValidationErrors) {
                    Console.WriteLine(err);
                }
                
            }


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}