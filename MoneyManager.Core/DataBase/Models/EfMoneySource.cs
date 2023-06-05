using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Core.DataBase.Models
{
    /// <summary>
    /// Источник денег
    /// </summary>
    [Table("money_sources")]
    public class EfMoneySource : IEfMoneySource
    {
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        public Guid Uuid { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("source_type")]
        public MoneySourceType SourceType { get; set; }

        [Required]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }


        // TODO валюта
        public EfEntityImage? Image { get; set; }

        public static EfMoneySource GetDefaultEntity()
        {
            return new()
            {
                Uuid = Guid.NewGuid(),
                Name = "Default base category name",
                SourceType = MoneySourceType.NONE,
                CreateDate = DateTime.Now,
            };
        }
    }
}
