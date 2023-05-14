using System.ComponentModel.DataAnnotations;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfMoneyStorage : IEfBaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double TotalSum { get; set; }
    }
}
