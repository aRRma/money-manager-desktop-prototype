using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models.Interfaces.Base
{
    public interface IEfNamedEntity : IEfBaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
