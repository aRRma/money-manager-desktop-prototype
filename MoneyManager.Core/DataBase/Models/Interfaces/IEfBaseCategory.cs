using System.ComponentModel.DataAnnotations;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfBaseCategory : IEfNamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
