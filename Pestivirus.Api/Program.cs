var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/statistics", () =>
{
    var forecast = Enumerable.Range(1, 10).Select(index =>
        new Country
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


public class Country
{
    public string? Title { get; init; }
    public int Cases { get; init; }
    public int TodayCases { get; init; }
    public int Deaths { get; init; }
    public int TodayDeaths { get; init; }
    public int Recovered { get; init; }
    public int Active { get; init; }
    public int Critical { get; init; }
    public CountryInfo? CountryInfo { get; init; }
}

public record CountryInfo(string? Flag);