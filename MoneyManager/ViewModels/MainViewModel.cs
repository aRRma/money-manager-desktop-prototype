using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyManager.Core.DataBase;
using System.Globalization;

namespace MoneyManager.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly AppDbContext _db;

    public MainViewModel(AppDbContext dbContext)
    {
        _db = dbContext;
        _db.MoneyStorages.Add(new()
        {
            CreateDate = DateTime.Now,
            Name = "Cash",
            TotalSum = 100.99m
        });
        _db.SaveChanges();

        TotalSum = _db.MoneyStorages.Single(x => string.Equals(x.Name, "Cash")).TotalSum;
    }

    #region observable fields

    [ObservableProperty] private decimal _totalSum;
    [ObservableProperty] private double _sumUp;
    [ObservableProperty] private double _sumDown;

    #endregion observable fields

    #region commands 

    [RelayCommand]
    private async Task AddMoney(object count)
    {
        if (count is string str)
        {
            str = str.Replace('.', ',');

            if (int.TryParse(str, NumberStyles.Any, CultureInfo.CurrentCulture, out var data))
            {
                var storage = _db.MoneyStorages.Single(x => string.Equals(x.Name, "Cash"));
                storage.TotalSum += data;
                await _db.SaveChangesAsync().ConfigureAwait(false);
                TotalSum = storage.TotalSum;
            }
        }
    }

    [RelayCommand]
    private async Task DenyMoney(object count)
    {
        if (count is string str)
        {
            str = str.Replace('.', ',');

            if (int.TryParse(str, NumberStyles.Any, CultureInfo.CurrentCulture, out var data))
            {
                var storage = _db.MoneyStorages.Single(x => string.Equals(x.Name, "Cash"));
                storage.TotalSum -= data;
                await _db.SaveChangesAsync().ConfigureAwait(false);
                TotalSum = storage.TotalSum;
            }
        }
    }

    #endregion commands 
}
