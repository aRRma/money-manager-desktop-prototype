namespace MoneyManager.Core.DataBase.Models.Interfaces.Base
{
    /// <summary>
    /// Базовый интерфейс именованной сущности в БД
    /// </summary>
    public interface IEfNamedEntity : IEfBaseEntity
    {
        public string Name { get; set; }
    }
}
