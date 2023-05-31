namespace MoneyManager.Core.DataBase.Models.Interfaces.Base
{
    /// <summary>
    /// Базовый интерфейс сущности в БД
    /// </summary>
    public interface IEfBaseEntity
    {
        public long Id { get; set; }

        public Guid Uuid { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
    }
}
