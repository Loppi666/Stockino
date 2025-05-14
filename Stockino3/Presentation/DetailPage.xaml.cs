namespace Stockino3.Presentation;

public sealed partial class DetailPage : Page
{
    public DetailPage()
    {
        InitializeComponent();
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        // Navigace zpět na stránku s transakcemi
        Frame.GoBack();
    }
}
