using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models.Interfaces.Base
{
    /// <summary>
    /// Базовый интерфейс сущности в БД
    /// </summary>
    public interface IEfBaseEntity
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime? DeleteDate { get; set; }
    }
}
