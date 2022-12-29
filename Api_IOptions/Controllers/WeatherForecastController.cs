using Api_IOptions.ConfigOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api_IOptions.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly WeatherApiOptions _weatherOptions;

    public WeatherForecastController(IHttpClientFactory httpClientFactory,
                                     IOptionsSnapshot<WeatherApiOptions> weatherOptions)
    {
        _httpClientFactory = httpClientFactory;
        _weatherOptions = weatherOptions.Value;
    }

    [HttpGet]
    public async Task<string> Get(string cityName = "Santos")
    {
        //string baseUrl = _configuration.GetValue<string>("WeatherApi:Url");
        //string key = _configuration.GetValue<string>("WeatherApi:Key");

        string baseUrl = _weatherOptions.Url;
        string key = _weatherOptions.Key;

        string url = $"{baseUrl}?key={key}&q={cityName}";
        using (var client = _httpClientFactory.CreateClient())
        {
            return await client.GetStringAsync(url);
        }
    }
}