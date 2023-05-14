using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfRecord : IEfBaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Sum { get; set; }

        [Required]
        public MoneyOperationType OperationType { get; set; }
    }
}
