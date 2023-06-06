using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository;
using System.Collections.ObjectModel;
using MoneyManager.Core.Extensions;
using FluentValidation;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.ViewModels;

public partial class MoneyStorageViewModel : ObservableObject
{
    private readonly EfMoneyStorageRepository _storageRepository;

    public MoneyStorageViewModel()
    {
        //#if DEBUG
        //        var opt = new DbContextOptionsBuilder<AppDbContext>().UseSqlite($"Data Source = {DB_NAME}").Options;
        //        using var dbContext = new AppDbContext(_dbContextOptions, true);
        //#endif
    }

    public MoneyStorageViewModel(EfMoneyStorageRepository storageRepository)
    {
        _storageRepository = storageRepository;

        Task.Run(async () =>
        {
            MoneyStorages = new ObservableCollection<EfMoneyStorage>(await _storageRepository.GetAllAsync());
            CurrentStorage = MoneyStorages.First();
            CurrentStorageDescription = CurrentStorage.ToDicDescription();
        });
    }


    #region observable fields

    [ObservableProperty] private ObservableCollection<EfMoneyStorage> _moneyStorages;
    [ObservableProperty] private EfMoneyStorage _currentStorage;
    [ObservableProperty] private Dictionary<string, string> _currentStorageDescription;

    #endregion observable fields

    #region commands 

    [RelayCommand]
    private async Task MoneyAdd(object count)
    {
        if (count is string str)
        {
            var result = await _storageRepository.MoneyAdd(CurrentStorage, str).ConfigureAwait(false);
            if (!result)
                ; // можно среагировать
            OnPropertyChanged(nameof(CurrentStorage));
        }
    }

    [RelayCommand]
    private async Task MoneyRemove(object count)
    {
        if (count is string str)
        {
            var result = await _storageRepository.MoneyRemove(CurrentStorage, str).ConfigureAwait(false);
            if (!result)
                ; // можно среагировать
            OnPropertyChanged(nameof(CurrentStorage));
        }
    }

    [RelayCommand]
    private void SelectedStorageChanged(object index)
    {
        if (index is EfMoneyStorage storage)
        {
            CurrentStorage = storage;
            CurrentStorageDescription = storage.ToDicDescription();
        }
    }

    #endregion commands 
}
