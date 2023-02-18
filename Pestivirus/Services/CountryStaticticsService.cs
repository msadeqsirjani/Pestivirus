namespace Pestivirus.Services;

public class CountryStatisticsService : ICountryStatisticsService
{
    private const string _uri = "https://corona.lmao.ninja/v3/covid-19/countries?sort=cases";

    public async Task<IEnumerable<Country>> GetTopCases()
    {
        using var client = new HttpClient();

        var response = await client.GetAsync(_uri);

        var result = await response.Content.ReadFromJsonAsync<IEnumerable<CountryDto>>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (result == null)
            return new List<Country>();

        return result.Select(country => new Country
        {
            Title = country.Country,
            Cases = country.Cases,
            Deaths = country.Deaths,
            TodayCases = country.TodayCases,
            TodayDeaths = country.TodayDeaths,
            Active = country.Active,
            Critical = country.Critical,
            Recovered = country.Recovered,
            FlagUri = country.CountryInfo?.Flag
        });
    }
}
