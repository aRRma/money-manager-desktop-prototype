using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace MoneyManager.Core.Models
{
    public class SomeTestAutoRegisterService : IAutoRegisterService
    {
        public void AutoRegister(IServiceCollection services, IOptions<ServiceAssemblyOption> option)
        {
            Type type = this.GetType();

            services.AddTransient(typeof(IAutoRegisterService), type);
        }

        public void DoWork()
        {
            Debug.WriteLine("I do!!!!");
        }
    }
}
