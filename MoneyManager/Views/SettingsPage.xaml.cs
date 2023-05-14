using System.Windows.Controls;

using MoneyManager.ViewModels;

namespace MoneyManager.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
