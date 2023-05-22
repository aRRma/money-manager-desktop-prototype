using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfRecordLabel : IEfNamedEntity
    {
        [Required]
        public MetaLabelType RecordLabel { get; set; }
    }
}
