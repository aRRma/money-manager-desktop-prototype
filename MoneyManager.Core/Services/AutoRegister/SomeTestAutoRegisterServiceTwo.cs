using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.RegistrationServices.AutoRegister.Interfaces;
using MoneyManager.Core.RegistrationServices.AutoRegister.Options;

namespace MoneyManager.Core.Services.AutoRegister
{
    public class SomeTestAutoRegisterServiceTwo : IAutoRegisterService
    {
        public void AutoRegister(IServiceCollection services, Type type, AutoRegisterServiceInfo serviceInfo)
        {
            services.AddTransient(typeof(IAutoRegisterService), type);
        }
    }
}
