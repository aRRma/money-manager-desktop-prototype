using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.RegistrationServices.AutoRegister.Interfaces;
using MoneyManager.Core.RegistrationServices.AutoRegister.Options;
using System.Diagnostics;

namespace MoneyManager.Core.Services.AutoRegister
{
    public class SomeTestAutoRegisterService : IAutoRegisterService
    {
        public void AutoRegister(IServiceCollection services, Type type, AutoRegisterServiceInfo serviceInfo)
        {
            services.AddTransient(typeof(IAutoRegisterService), type);
        }

        public void DoWork()
        {
            Debug.WriteLine("I do!!!!");
        }
    }
}
