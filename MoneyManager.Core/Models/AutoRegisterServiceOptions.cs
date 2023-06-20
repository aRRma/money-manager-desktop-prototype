using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.Models
{
    /// <summary>
    /// Узел конфигураций авто регистрируемого сервиса
    /// </summary>
    public class AutoRegisterServiceOptions
    {
        public List<ServiceAssemblyOption>? Assemblies { get; }
    }

    /// <summary>
    /// Модель описания конкретного авто регистрируемого сервиса
    /// </summary>
    public class ServiceAssemblyOption
    {
        [Required]
        public string AssemblyName { get; }
    }
}
