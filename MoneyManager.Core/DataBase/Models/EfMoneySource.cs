using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models
{
    /// <summary>
    /// Источник денег
    /// </summary>
    public class EfMoneySource : IEfMoneySource
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public Guid Uuid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public MoneySourceType SourceType { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        // TODO валюта

        public EfEntityImage? Image { get; set; }
    }
}
