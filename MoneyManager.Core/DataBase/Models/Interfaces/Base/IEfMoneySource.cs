using MoneyManager.Core.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models.Interfaces.Base
{
    public interface IEfMoneySource : IEfNamedEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public MoneySourceType SourceType { get; set; }
    }
}
