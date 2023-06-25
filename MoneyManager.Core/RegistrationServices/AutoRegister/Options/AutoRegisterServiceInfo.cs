using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.RegistrationServices.AutoRegister.Options
{
    /// <summary>
    /// Модель описания конкретного авто регистрируемого сервиса
    /// </summary>
    public class AutoRegisterServiceInfo
    {
        /// <summary>
        /// Нэмспэйс включающий тип
        /// </summary>
        [Required]
        public string Namespace { get; init; }

        /// <summary>
        /// Название реализации сервиса (класса)
        /// </summary>
        [Required]
        public string Name { get; init; }

        /// <summary>
        /// Тип реализации сервиса
        /// </summary>
        [Required]
        public string ImplementType { get; init; }

        /// <summary>
        /// Тип инжекции сервиса в DI
        /// </summary>
        [Required]
        public ServiceInjectionType InjectionType { get; set; }

        /// <summary>
        /// Если тип лежит в другой сборке
        /// </summary>
        public string? AssemblyName { get; init; }

        /// <summary>
        /// Путь до конфига
        /// </summary>
        public string? ConfigPath { get; init; }
    }
}
