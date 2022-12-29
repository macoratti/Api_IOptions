
using Api_IOptions.ConfigOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//serviço HttpClient
builder.Services.AddHttpClient();

//var configOptions = builder.Configuration.GetSection(WeatherApiOptions.WeatherApi);
//builder.Services.Configure<WeatherApiOptions>(configOptions);

builder.Services.AddOptions<WeatherApiOptions>()
              .Bind(builder.Configuration.GetSection(WeatherApiOptions.WeatherApi))
              .ValidateDataAnnotations();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
