using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MoneyManager.Core.Models
{
    public class SomeTestAutoRegisterServiceTwo : IAutoRegisterService
    {
        public void AutoRegister(IServiceCollection services, IOptions<ServiceAssemblyOption> option)
        {
            throw new NotImplementedException();
        }
    }
}
