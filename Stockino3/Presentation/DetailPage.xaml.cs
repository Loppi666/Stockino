using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Stockino3.Presentation;

public sealed partial class DetailPage : Page
{
    public DetailPage()
    {
        this.InitializeComponent();
    }
    
    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        // Navigace zpět na stránku s transakcemi
        Frame.GoBack();
    }
}
