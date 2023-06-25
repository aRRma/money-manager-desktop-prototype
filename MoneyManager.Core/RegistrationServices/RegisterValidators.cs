using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.DataBase.Models.Interfaces;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Validators;

namespace MoneyManager.Core.RegistrationServices
{
    public static class RegisterValidators
    {
        public static void AddValidators(this IServiceCollection provider)
        {
            provider.AddScoped<EfBaseCategoryValidator<IEfBaseCategory>>();
            provider.AddScoped<EfEntityImageValidator<IEfEntityImage>>();
            provider.AddScoped<EfMetaLabelValidator<IEfMetaLabel>>();
            provider.AddScoped<EfMoneyOperationValidator<IEfMoneyOperation>>();
            provider.AddScoped<EfMoneySourceValidator<IEfMoneySource>>();
            provider.AddScoped<EfMoneyStorageValidator<IEfMoneyStorage>>();
            provider.AddScoped<EfNamedEntityValidator<IEfNamedEntity>>();
            provider.AddScoped<EfRecordValidator<IEfRecord>>();
            provider.AddScoped<EfSubCategoryValidator<IEfSubCategory>>();
        }
    }
}
