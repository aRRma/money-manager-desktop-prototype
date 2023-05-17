using System.ComponentModel.DataAnnotations;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfMoneyStorage : IEfNamedEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal TotalSum { get; set; }
    }
}
