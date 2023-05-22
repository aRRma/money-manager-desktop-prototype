using System.ComponentModel.DataAnnotations;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfMoneyStorage : IEfNamedEntity
    {
        [Required]
        public decimal TotalSum { get; set; }
    }
}
