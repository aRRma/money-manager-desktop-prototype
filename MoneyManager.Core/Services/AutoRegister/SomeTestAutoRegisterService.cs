using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.RegistrationServices.AutoRegister;
using MoneyManager.Core.RegistrationServices.AutoRegister.Config;
using System.Diagnostics;

namespace MoneyManager.Core.Services.AutoRegister
{
    public class SomeTestAutoRegisterService : BaseAutoRegisterService, ISomeTestAutoRegisterService
    {
        public override void AutoRegister(IServiceCollection provider, Type type, AutoRegisterServiceInfo serviceInfo)
        {
            base.AutoRegister(provider, type, serviceInfo);

            ;
        }

        public void DoWork()
        {
            Debug.WriteLine("Just do it!!!!");
        }
    }
}
