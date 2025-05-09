using Windows.Storage.Pickers;
using CommunityToolkit.Mvvm.ComponentModel;
using Uno.Extensions.Reactive.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Uno.Extensions;
using Uno.Extensions.Navigation;
using Windows.Storage.Pickers;
using Windows.Storage;
using CommunityToolkit.Mvvm.Input;
using Stockino3.Services;
using Uno.Extensions.Reactive.Core;

namespace Stockino3.Presentation;

public partial class MainModel : ObservableObject
{
    private INavigator _navigator;
    private Analyze analyze;
    private AnyCoinTransactionLoader anyCoinTransactionLoader;
    
    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator, Analyze analyze, AnyCoinTransactionLoader anyCoinTransactionLoader)
    {
        _navigator = navigator;
        this.analyze = analyze;
        this.anyCoinTransactionLoader = anyCoinTransactionLoader;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
       
        
       SelectFile = new AsyncRelayCommand(  OnSelectFile);
       
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);
    
    public enum Provider
    {
        AynCoint,
        Xtb,
        Degiro
    }
    
    public Provider? SelectedProvider { get; set; }
    public ObservableCollection<Provider> Providers { get; } = new() { Provider.AynCoint, Provider.Xtb, Provider.Degiro };

    public async Task GoToSecond()
    {
        var name = await Name;
      await _navigator.NavigateViewModelAsync<TransactionsModel>(this, data: new Entity(name!));
    }
    
    public IRelayCommand SelectFile { get; }

    [ObservableProperty]
    private string? _selectedFileName;

    public async Task OnSelectFile()
    {
        var picker = new FileOpenPicker();

        // Required for WinUI and WebAssembly
#if WINDOWS || __WASM__
        picker.FileTypeFilter.Add("*");
        picker.SuggestedStartLocation = PickerLocationId.Desktop;
#endif

        // UWP and WinUI require this to set the correct window
#if WINDOWS
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
        WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);
#endif

#if __WASM__
        // Set the Wasm window
        picker.FileTypeFilter.Add("*");
        picker.SuggestedStartLocation = PickerLocationId.Desktop;
        Uno.Foundation.WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.setPickerTitle('Select a file');");
#endif

        picker.FileTypeFilter.Add("*");
        var file = await picker.PickSingleFileAsync();
        if (file != null && SelectedProvider != Provider.AynCoint)
        {
            SelectedFileName = file.Name;
           await analyze.PerformeAnalyze(file.Path);
        }

        switch ( SelectedProvider)
        {
            case Provider.AynCoint:
              await  anyCoinTransactionLoader.ImportFromCsv(file.Path);
                break;
            case Provider.Xtb:
                break;
            case Provider.Degiro:
                break;
            default:
                break;
        }
        {
            
        }
       
    }

}
