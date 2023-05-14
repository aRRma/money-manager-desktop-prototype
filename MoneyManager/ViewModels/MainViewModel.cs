using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyManager.Core.DataBase;

namespace MoneyManager.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly AppDbContext _db;

    #region observable fields

    [ObservableProperty] private double _totalSum;
    [ObservableProperty] private double _sumUp;
    [ObservableProperty] private double _sumDown;

    #endregion observable fields

    public MainViewModel(AppDbContext dbContext)
    {
        _db = dbContext;
        _db.MoneyStorages.Add(new()
        {
            CreateDate = DateTime.Now,
            Name = "Cash",
            TotalSum = 100.99
        });
        _db.SaveChanges();

        TotalSum = _db.MoneyStorages.First().TotalSum;
    }
}
