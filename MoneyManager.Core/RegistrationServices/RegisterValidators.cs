using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.DataBase.Models.Interfaces;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Validators;

namespace MoneyManager.Core.RegistrationServices
{
    public static class RegisterValidators
    {
        public static void AddValidators(this IServiceCollection service)
        {
            service.AddScoped<EfBaseCategoryValidator<IEfBaseCategory>>();
            service.AddScoped<EfEntityImageValidator<IEfEntityImage>>();
            service.AddScoped<EfMetaLabelValidator<IEfMetaLabel>>();
            service.AddScoped<EfMoneyOperationValidator<IEfMoneyOperation>>();
            service.AddScoped<EfMoneySourceValidator<IEfMoneySource>>();
            service.AddScoped<EfMoneyStorageValidator<IEfMoneyStorage>>();
            service.AddScoped<EfNamedEntityValidator<IEfNamedEntity>>();
            service.AddScoped<EfRecordValidator<IEfRecord>>();
            service.AddScoped<EfSubCategoryValidator<IEfSubCategory>>();
        }
    }
}
