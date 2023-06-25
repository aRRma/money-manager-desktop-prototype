using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.DataBase.Repository;

namespace MoneyManager.Core.RegistrationServices
{
    public static class RegisterRepositories
    {
        public static void AddRepositories(this IServiceCollection provider)
        {
            provider.AddTransient<EfBaseCategoryRepository>();
            provider.AddTransient<EfEntityImageRepository>();
            provider.AddTransient<EfMetaLabelRepository>();
            provider.AddTransient<EfMoneyOperationRepository>();
            provider.AddTransient<EfMoneySourceRepository>();
            provider.AddTransient<EfMoneyStorageRepository>();
            provider.AddTransient<EfRecordRepository>();
            provider.AddTransient<EfSubCategoryRepository>();
        }
    }
}
