namespace Pestivirus.Services;

public interface ICountryStatisticsService
{
    Task<IEnumerable<Country>> GetTopCases();
}
