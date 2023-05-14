using MoneyManager.Core.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models.Interfaces.Base
{
    public interface IEfMoneyOperation : IEfBaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public MoneyOperationType OperationType { get; set; }
    }
}
