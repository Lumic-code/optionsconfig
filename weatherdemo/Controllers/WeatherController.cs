using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace weatherdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherOptions _options;
        private readonly WeatherOptions _optionsSnapshot;
        private readonly WeatherOptions _optionsMonitor;

        public WeatherController(IOptions<WeatherOptions> options, 
            IOptionsSnapshot<WeatherOptions> optionsSnapshot, IOptionsMonitor<WeatherOptions> optionsMonitor)
        {
            _options = options.Value;
            _optionsSnapshot = optionsSnapshot.Value;
            _optionsMonitor = optionsMonitor.CurrentValue;
        }

        [HttpGet("options")]
        public IActionResult GetFromOptionsPattern()
        {
            var response = new
            {
                options = new { _options.City, _options.State, _options.Temperature, _options.Summary },
                optionsSnapshot = new { _optionsSnapshot.City, _optionsSnapshot.State, _optionsSnapshot.Temperature, _optionsSnapshot.Summary },
                _optionsMonitor = new { _optionsMonitor.City, _optionsSnapshot.State, _optionsSnapshot.Temperature, _optionsSnapshot.Summary }
            };
            return Ok(response);
        }
    }
}
