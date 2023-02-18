using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.MapGet("/statistics", (HttpContext context) =>
{
    var url = $"{context.Request.Scheme}://{context.Request.Host}";

    List<Country> coronavirusStatistics = new()
    {
        new Country("World", 1_133_455, 16_812, 60_381, 1_223, 236_000, 837_074, 39_599, new CountryInfo($"{url}/unknown.png")),
        new Country("USA", 277_607, 446, 7_406, 14, 12_283, 257_918, 5_787, new CountryInfo($"{url}/usa.png")),
        new Country("Spain", 124_736, 5_537, 11_744, 546, 34_219, 78_773, 6_416, new CountryInfo($"{url}/spain.png")),
        new Country("Italy", 119_827, 0, 14_618, 0, 19_758, 58_388, 4_068, new CountryInfo($"{url}/italy.png")),
        new Country("Germany", 91_159, 0, 1_275, 0, 24_575, 63_503, 3_936, new CountryInfo($"{url}/germany.png")),
        new Country("France", 82_165, 0, 6_507, 0, 14_008, 61_650, 6_662, new CountryInfo($"{url}/france.png")),
        new Country("China", 81_936, 19, 3_242, 4, 76_755, 1_558, 331, new CountryInfo($"{url}/china.png")),
        new Country("Iran", 55_774, 2_560, 3_543, 158, 19_736, 32_555, 4_103, new CountryInfo($"{url}/iran.png")),
    };

    return coronavirusStatistics;
}).WithOpenApi();

app.Run();

public record Country(string? Title, int Cases, int TodayCases, int Deaths, int TodayDeaths, int Recovered, int Active, int Critical, CountryInfo? CountryInfo);

public record CountryInfo(string Flag);