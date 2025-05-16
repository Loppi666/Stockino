using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Refit;
using Stockino3.Services;
using Uno.Resizetizer;

namespace Stockino3;

public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();
    }

    protected Window? MainWindow { get; private set; }
    public IHost? Host { get; private set; }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        string databasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Database.db");

        var builder = this.CreateBuilder(args)
                           // Add navigation support for toolkit controls such as TabBar and NavigationView
                          .UseToolkitNavigation()
                          .Configure(host => host
#if DEBUG
                                             // Switch to Development environment when running in DEBUG
                                            .UseEnvironment(Environments.Development)
#endif

                                            .ConfigureServices((context, services) =>
                                             {
                                                 services.Scan(scan => scan
                                                                      .FromAssemblyOf<IService>()
                                                                      .AddClasses(classes => classes.AssignableTo<IService>())
                                                                      .AsSelfWithInterfaces()
                                                                      .WithTransientLifetime());

                                                 services.AddTransient<TransactionDetailModel>();

                                                 services.AddDbContext<TransactionContext>(options =>
                                                 {
                                                     options.UseSqlite($"Data Source={databasePath}");
                                                     options.EnableSensitiveDataLogging();
                                                     options.EnableDetailedErrors();

                                                     options.LogTo(Console.WriteLine,
                                                                   new[] { DbLoggerCategory.Database.Command.Name },
                                                                   LogLevel.Information,
                                                                   DbContextLoggerOptions.UtcTime);
                                                 });

                                                 // Registrace handleru pro AlphaVantage API
                                                 services.AddTransient<AlphaVantageApiKeyHandler>();

                                                 services.AddRefitClient<IAlphaVantageApi>()
                                                         .ConfigureHttpClient(c => { c.BaseAddress = new Uri("https://www.alphavantage.co"); })
                                                         .AddHttpMessageHandler<AlphaVantageApiKeyHandler>();

                                                 // Registrace handleru a klienta pro OpenFIGI API
                                                 services.AddTransient<OpenFigiApiKeyHandler>();

                                                 services.AddRefitClient<IOpenFigiApi>()
                                                         .ConfigureHttpClient(c => { c.BaseAddress = new Uri("https://api.openfigi.com"); })
                                                         .AddHttpMessageHandler<OpenFigiApiKeyHandler>();
                                             })
                                            .UseLogging((context, logBuilder) =>
                                             {
                                                 // Configure log levels for different categories of logging
                                                 logBuilder
                                                    .SetMinimumLevel(context.HostingEnvironment.IsDevelopment()
                                                                         ? LogLevel.Information
                                                                         : LogLevel.Warning)

                                                     // Default filters for core Uno Platform namespaces
                                                    .CoreLogLevel(LogLevel.Warning);

                                                 // Uno Platform namespace filter groups
                                                 // Uncomment individual methods to see more detailed logging
                                                 //// Generic Xaml events
                                                 //logBuilder.XamlLogLevel(LogLevel.Debug);
                                                 //// Layout specific messages
                                                 //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
                                                 //// Storage messages
                                                 //logBuilder.StorageLogLevel(LogLevel.Debug);
                                                 //// Binding related messages
                                                 //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
                                                 //// Binder memory references tracking
                                                 //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
                                                 //// DevServer and HotReload related
                                                 //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
                                                 //// Debug JS interop
                                                 //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);
                                             }, true)
                                            .UseConfiguration(configure: configBuilder =>
                                                                  configBuilder
                                                                     .EmbeddedSource<App>()
                                                                     .Section<AppConfig>())
                                             // Enable localization (see appsettings.json for supported languages)
                                            .UseLocalization()
                                             // Register Json serializers (ISerializer and ISerializer)
                                            .UseSerialization((context, services) => services
                                                                                    .AddContentSerializer(context)
                                                                                    .AddJsonTypeInfo(WeatherForecastContext.Default.IImmutableListWeatherForecast))
                                            .UseHttp((context, services) => services
                                                                            // Register HttpClient
#if DEBUG
                                                                            // DelegatingHandler will be automatically injected into Refit Client
                                                                           .AddTransient<DelegatingHandler, DebugHttpHandler>()
#endif
                                                                           .AddSingleton<IWeatherCache, WeatherCache>())
                                            .ConfigureServices((context, services) =>
                                             {
                                                 // TODO: Register your services
                                                 //services.AddSingleton<IMyService, MyService>();
                                             })
                                            .UseNavigation(ReactiveViewModelMappings.ViewModelMappings, RegisterRoutes));

        MainWindow = builder.Window;

#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

        Host = await builder.NavigateAsync<Shell>();

        // Ensure database is created
        using (var scope = Host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var transactionContext = services.GetRequiredService<TransactionContext>();
            await transactionContext.Database.EnsureCreatedAsync();
        }
    }

    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        views.Register(new ViewMap(ViewModel: typeof(ShellModel)),
                       new ViewMap<MainPage, MainModel>(),
                       new DataViewMap<SecondPage, SecondModel, Entity>(),
                       new DataViewMap<TransactionsPage, TransactionsModel, TransactionEntity>(),
                       // případně další DataViewMap pro detail
                       new DataViewMap<DetailPage, TransactionDetailModel, TransactionViewModel>());

        routes.Register(new RouteMap("", views.FindByViewModel<ShellModel>(),
                                     Nested:
                                     [
                                         new RouteMap("Main", views.FindByViewModel<MainModel>(), true),
                                         new RouteMap("Second", views.FindByViewModel<SecondModel>()),
                                         new RouteMap("Transactions", views.FindByViewModel<TransactionsModel>()),
                                         new RouteMap("TransactionDetail", views.FindByViewModel<TransactionDetailModel>())
                                     ]));
    }
}

public interface IService
{ }

// Handler pro přidání apiKey do query stringu
public class AlphaVantageApiKeyHandler : DelegatingHandler
{
    private const string ApiKey = "9E71JJDSQDAD5CZR";

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var uriBuilder = new UriBuilder(request.RequestUri!);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["apikey"] = ApiKey;
        uriBuilder.Query = query.ToString();
        request.RequestUri = uriBuilder.Uri;

        return await base.SendAsync(request, cancellationToken);
    }
}

// Handler pro přidání OpenFIGI API klíče do hlavičky
public class OpenFigiApiKeyHandler : DelegatingHandler
{
    private const string ApiKey = "a08356ad-0452-4313-89b4-226e9906b9a4";

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Odeber případnou starou hlavičku a přidej aktuální klíč
        request.Headers.Remove("X-OPENFIGI-APIKEY");
        request.Headers.Add("X-OPENFIGI-APIKEY", ApiKey);

        return await base.SendAsync(request, cancellationToken);
    }
}
