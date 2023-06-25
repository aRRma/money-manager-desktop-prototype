using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Core.RegistrationServices.AutoRegister;
using MoneyManager.Core.RegistrationServices.AutoRegister.Config;

namespace MoneyManager.Core.Services.AutoRegister
{
    public class SomeTestAutoRegisterServiceTwo : AutoRegisterService, ISomeTestAutoRegisterService
    {
        public override void AutoRegister(IServiceCollection provider, Type type, AutoRegisterServiceInfo serviceInfo)
        {
            base.AutoRegister(provider, type, serviceInfo);

            ;
        }
    }
}
