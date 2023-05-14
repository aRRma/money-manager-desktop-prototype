using System.Windows.Controls;

using MoneyManager.ViewModels;

namespace MoneyManager.Views;

public partial class MainPage : Page
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
