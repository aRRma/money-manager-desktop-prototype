using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.DataBase.Repository;

namespace MoneyManager.Core.RegistrationServices
{
    public static class RegisterRepositories
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<EfBaseCategoryRepository>();
            service.AddTransient<EfEntityImageRepository>();
            service.AddTransient<EfMetaLabelRepository>();
            service.AddTransient<EfMoneyOperationRepository>();
            service.AddTransient<EfMoneySourceRepository>();
            service.AddTransient<EfMoneyStorageRepository>();
            service.AddTransient<EfRecordRepository>();
            service.AddTransient<EfSubCategoryRepository>();
        }
    }
}
