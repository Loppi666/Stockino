using System.Collections.ObjectModel;
using Windows.Storage.Pickers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stockino3.Services;

namespace Stockino3.Presentation;

public partial class MainModel : ObservableObject
{
    private readonly INavigator _navigator;
    private readonly DegiroParser degiroParser;
    private readonly AnyCoinTransactionLoader anyCoinTransactionLoader;
    private readonly XtbParser xtbParser;

    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator, DegiroParser degiroParser, AnyCoinTransactionLoader anyCoinTransactionLoader, XtbParser xtbParser)
    {
        _navigator = navigator;
        this.degiroParser = degiroParser;
        this.anyCoinTransactionLoader = anyCoinTransactionLoader;
        this.xtbParser = xtbParser;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";

        SelectFile = new AsyncRelayCommand(OnSelectFile);
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public enum Provider
    {
        AynCoint,
        Xtb,
        Degiro
    }

    public IState<Provider?> SelectedProvider => State<Provider?>.Value(this, () => null);

    public ObservableCollection<Provider?> Providers { get; } = new()
    {
        null,
        Provider.AynCoint,
        Provider.Xtb,
        Provider.Degiro
    };

    public async Task GoToSecond()
    {
        string? name = await Name;
        await _navigator.NavigateViewModelAsync<TransactionsModel>(this, data: new Entity(name!));
    }

    public IRelayCommand SelectFile { get; }

    [ObservableProperty]
    private string? _selectedFileName;

    public async Task OnSelectFile()
    {
        var picker = new FileOpenPicker();
        
        var ff = await SelectedProvider.Value();
        picker.FileTypeFilter.Clear();
        switch (ff)
        {
            case Provider.Degiro:
            case Provider.AynCoint:
                picker.FileTypeFilter.Add(".csv");
                break;
            case Provider.Xtb:
                picker.FileTypeFilter.Add(".xlsx");
                break;
            default:
                picker.FileTypeFilter.Add("*");
                break;
        }

        // Required for WinUI and WebAssembly
#if WINDOWS || __WASM__
      
        picker.SuggestedStartLocation = PickerLocationId.Desktop;
#endif

        // UWP and WinUI require this to set the correct window
#if WINDOWS
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
        WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);
#endif

#if __WASM__
       
        picker.SuggestedStartLocation = PickerLocationId.Desktop;
        Uno.Foundation.WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.setPickerTitle('Select a file');");
#endif

     

        // Nastav FileTypeFilter podle providera
      

        var file = await picker.PickSingleFileAsync();

       

        switch (ff)
        {
            case Provider.AynCoint:
                await anyCoinTransactionLoader.ImportFromCsv(file.Path);

                break;
            case Provider.Xtb:
                await xtbParser.ParseXtb(file.Path);

                break;
            case Provider.Degiro:
                await degiroParser.PerformeAnalyze(file.Path);
                break;
        }

        { }
    }
}
