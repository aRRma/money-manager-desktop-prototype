namespace MoneyManager.Core.RegistrationServices.AutoRegister.Options
{
    /// <summary>
    /// Тип инжекции сервиса в DI
    /// </summary>
    public enum ServiceInjectionType
    {
        None,
        Singleton,
        Transient,
        Scoped
    }
}
