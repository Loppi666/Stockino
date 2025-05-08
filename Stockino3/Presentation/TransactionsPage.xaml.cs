using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Navigation;
using Stockino3.Services;
using System;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;
using System.Threading.Tasks;

namespace Stockino3.Presentation;

public sealed partial class TransactionsPage : Page
{
    public TransactionsPage()
    {
        InitializeComponent();
        
  
    }
    
    private async void TransactionsListView_ItemClick(object sender, ItemClickEventArgs itemClickEventArgs)
    {
        var data = itemClickEventArgs.ClickedItem as TransactionViewModel; // nebo tvůj konkrétní typ
        
        // Navigace na detailní stránku s předáním entity
        await this.Navigator().NavigateDataAsync<TransactionViewModel>(this, data: data);
    }
    
    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (Frame.CanGoBack)
        {
            Frame.GoBack();
        }
        else
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
    
    // Metoda byla přesunuta do TransactionsModel
}
