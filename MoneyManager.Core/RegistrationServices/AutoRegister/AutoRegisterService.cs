using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.RegistrationServices.AutoRegister.Interfaces;
using MoneyManager.Core.RegistrationServices.AutoRegister.Options;
using System.Reflection;

namespace MoneyManager.Core.RegistrationServices.AutoRegister
{
    /// <summary>
    /// Абстракция авторег. сервиса
    /// </summary>
    public abstract class AutoRegisterService : IAutoRegisterService
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
