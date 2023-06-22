namespace MoneyManager.Core.RegistrationServices.AutoRegister.Options
{
    /// <summary>
    /// Узел списка конфигураций авто регистрируемых сервисов
    /// </summary>
    public class AutoRegisterServicesConfig
    {
        public List<AutoRegisterServiceInfo>? ServicesInfo { get; init; }
    }
}
