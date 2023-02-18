namespace Pestivirus.ViewModels;

public class DashboardViewModel : BindableBase
{
    private readonly ICountryStatisticsService _countryStatisticsService;

    public DashboardViewModel(ICountryStatisticsService countryStatisticsService)
    {
        _countries = new ObservableCollection<Country>();
        _countryStatisticsService = countryStatisticsService;

        LoadCountryCommand = new DelegateCommand(LoadAsync);

        LoadAsync();

        ItemView.Filter = new Predicate<object>(country => Filter((Country)country));

        Title = "Corona Virus Pandemic | Word Real-Time Statistics";
    }

    public DelegateCommand LoadCountryCommand { get; set; }

    public ICollectionView ItemView => CollectionViewSource.GetDefaultView(Countries);

    private string? _status;
    public string? Status 
    { 
        get => _status; 
        set => SetProperty(ref _status, value); 
    }

    private string? _searchText;
    public string? SearchText
    {
        get => _searchText;
        set => SetProperty(ref _searchText, value);
    }

    private ObservableCollection<Country> _countries;
    public ObservableCollection<Country> Countries
    {
        get => _countries;
        set => SetProperty(ref _countries, value);
    }

    private string? _title;
    public string? Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    private bool Filter(Country country) => 
        string.IsNullOrWhiteSpace(SearchText) || country.Title?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) != -1;

    private async void LoadAsync()
    {
        Countries.Clear();

        var countries = await _countryStatisticsService.GetTopCases();

        Countries.AddRange(countries);

        Status = $"Updated {DateTime.Now:U}";
    }
}
