using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Core.DataBase.Models
{
    /// <summary>
    /// Хранилище денег
    /// </summary>
    [Table("money_storages")]
    public class EfMoneyStorage : IEfMoneyStorage
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
        [Column("total_sum")]
        public decimal TotalSum { get; set; }

        [Required]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("delete_date")]
        public DateTime? DeleteDate { get; set; }


        public EfEntityImage? Image { get; set; }
        public EfMoneySource? MoneySource { get; set; }
        public virtual List<EfRecord> Records { get; set; } = new();
    }
}
