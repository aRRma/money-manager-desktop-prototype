using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.RegistrationServices.AutoRegister.Config;
using MoneyManager.Core.RegistrationServices.AutoRegister.Interfaces;
using System.Reflection;

namespace MoneyManager.Core.RegistrationServices.AutoRegister
{
    /// <summary>
    /// Абстракция авторег. сервиса
    /// </summary>
    public abstract class BaseAutoRegisterService : IAutoRegisterService
    {
        public virtual void AutoRegister(IServiceCollection provider, Type type, AutoRegisterServiceInfo serviceInfo)
        {
            if (!type
                .GetTypeInfo().ImplementedInterfaces
                .Any(x => string.Equals(x.Name, serviceInfo.ImplementType, StringComparison.InvariantCultureIgnoreCase)))
                throw new ArgumentException($"Wrong service type {type.Name}. Expect {serviceInfo.ImplementType}");

            provider.AddServiceByRule(type, serviceInfo.InjectionType);
        }
    }
}
