namespace Pestivirus;

public partial class App
{
    protected override Window CreateShell() => Container.Resolve<DashboardView>();

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<ICountryStatisticsService, CountryStatisticsService>();
    }
}
