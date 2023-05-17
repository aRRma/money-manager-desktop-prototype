using MoneyManager.Core.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models.Interfaces.Base
{
    public interface IEfRecordLabel : IEfNamedEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public MetaLabelType RecordLabel { get; set; }
    }
}
