using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MoneyManager.Core.Models
{
    /// <summary>
    /// Авто регистрируемый сервис
    /// </summary>
    public interface IAutoRegisterService
    {
        /// <summary>
        /// Зарегистрировать сервис
        /// </summary>
        /// <param name="services"></param>
        /// <param name="option"></param>
        public void AutoRegister(IServiceCollection services, IOptions<ServiceAssemblyOption> option);
    }
}
