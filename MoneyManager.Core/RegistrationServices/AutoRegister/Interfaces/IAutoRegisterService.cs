using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.RegistrationServices.AutoRegister.Options;

namespace MoneyManager.Core.RegistrationServices.AutoRegister.Interfaces
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
        /// <param name="type">По типу проверять что это реально тот тип сервиса, малоли имя попутали</param>
        /// <param name="serviceInfo"></param>
        public void AutoRegister(IServiceCollection services, Type type, AutoRegisterServiceInfo serviceInfo);
    }
}
