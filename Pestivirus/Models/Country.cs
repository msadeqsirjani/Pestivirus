namespace Pestivirus.Models;

public class Country
{
    public string? Title { get; set; }
    public int Cases { get; set; }
    public int TodayCases { get; set; }
    public int Deaths { get; set; }
    public int TodayDeaths { get; set; }
    public int Recovered { get; set; }
    public int Active { get; set; }
    public int Critical { get; set; }
    public string? FlagUri { get; set; }
}