using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfMoneyOperation : IEfNamedEntity
    {
        [Required]
        public MoneyOperationType OperationType { get; set; }
    }
}
