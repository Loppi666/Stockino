using Windows.Storage.Pickers;
using CommunityToolkit.Mvvm.ComponentModel;
using Uno.Extensions.Reactive.Commands;
using System;
using System.Collections.Generic;
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
    
    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator, Analyze analyze)
    {
        _navigator = navigator;
        this.analyze = analyze;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
       
        
       SelectFile = new AsyncRelayCommand(  OnSelectFile);
       
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

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
        if (file != null)
        {
            SelectedFileName = file.Name;
           await analyze.PerformeAnalyze(file.Path);
        }
        
       
    }

}
