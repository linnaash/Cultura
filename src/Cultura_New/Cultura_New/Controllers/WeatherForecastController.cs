using Microsoft.AspNetCore.Mvc;

namespace Cultura_New.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Summaries);
        }
        [HttpPost("put")]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count())
            {
                return BadRequest("Ну чего вы издеваетесь, напишите пож корректный индекс...");

            }
            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count())
            {
                return BadRequest("Ну чего вы издеваетесь, напишите пож корректный индекс...");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }
        [HttpGet("find-by-index")]
        public IActionResult GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count())
            {
                return BadRequest("Ну чего вы издеваетесь, напишите пож корректный индекс...");
            }
            return Ok(Summaries[index]);
        }
        [HttpGet("find-by-name")]
        public IActionResult GetByName(string name)
        {
            int count = 0;
            foreach(string el in  Summaries) {
                if(el == name) 
                    count++;
            }
            return Ok(count);
        }
    }
}