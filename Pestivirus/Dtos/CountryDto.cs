namespace Pestivirus.Dtos;

public class CountryDto
{
    public string? Title { get; init; }
    public int Cases { get; init; }
    public int TodayCases { get; init; }
    public int Deaths { get; init; }
    public int TodayDeaths { get; init; }
    public int Recovered { get; init; }
    public int Active { get; init; }
    public int Critical { get; init; }
    public CountryInfoDto? CountryInfo { get; init; }
}
