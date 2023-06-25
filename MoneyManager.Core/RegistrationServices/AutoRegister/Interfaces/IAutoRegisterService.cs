using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.RegistrationServices.AutoRegister.Config;

namespace MoneyManager.Core.RegistrationServices.AutoRegister.Interfaces
{
    /// <summary>
    /// Авто регистрируемый сервис
    /// </summary>
    public interface IAutoRegisterService
    {
        /// <summary>
        /// Зарегистрировать сервис. Обязательно регистрировать как (typeof(IAutoRegisterService), type)
        /// </summary>
        /// <param name="provider">Провайдер сервисов</param>
        /// <param name="type">Тип регистрируемого сервиса</param>
        /// <param name="serviceInfo">Информация об регистрируемом сервисе</param>
        public void AutoRegister(IServiceCollection provider, Type type, AutoRegisterServiceInfo serviceInfo);
    }
}
