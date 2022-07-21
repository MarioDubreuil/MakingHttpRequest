using Microsoft.AspNetCore.Mvc;

namespace MakingHttpRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<string> Get(string zipCode)
        {
            var httpClient = _httpClientFactory.CreateClient("zippopotam");
            var url = $"{zipCode}";
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}