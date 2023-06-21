using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.Models
{
    /// <summary>
    /// Узел списка конфигураций авто регистрируемых сервисов
    /// </summary>
    public class AutoRegisterServicesOptions
    {
        public List<AutoRegisterServiceInfo>? ServicesInfo { get; init; }
    }

    /// <summary>
    /// Модель описания конкретного авто регистрируемого сервиса
    /// </summary>
    public class AutoRegisterServiceInfo
    {
        public string? AssemblyName { get; init; }

        [Required]
        public string FullQualifiedServiceName { get; init; }

        // TODO возможно спец. параметры
    }
}
