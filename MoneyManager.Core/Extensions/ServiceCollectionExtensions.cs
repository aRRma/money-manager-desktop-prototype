using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MoneyManager.Core.Models;

namespace MoneyManager.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAutoService(this IServiceCollection services, IOptions<AutoRegisterServiceOptions> options)
        {

        }
    }
}
