using System.ComponentModel.DataAnnotations;

namespace Api_IOptions.ConfigOptions;

public class WeatherApiOptions
{
    public const string WeatherApi = "WeatherApi";

    [Required]
    public string? Url { get; set; }
    [Required]
    public string? Key { get; set; }
}
