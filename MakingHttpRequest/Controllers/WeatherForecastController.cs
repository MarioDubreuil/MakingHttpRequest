using Microsoft.AspNetCore.Mvc;

namespace MakingHttpRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private static HttpClient _httpClient;

        static WeatherForecastController()
        {
            _httpClient = new HttpClient();
        }

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Get(string zipCode)
        {
            var url = $"https://api.zippopotam.us/us/{zipCode}";
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}