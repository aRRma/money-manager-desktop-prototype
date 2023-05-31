using System.Windows.Controls;

using MoneyManager.ViewModels;

namespace MoneyManager.Views;

public partial class MoneyStoragePage : Page
{
    public MoneyStoragePage(MoneyStorageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
