using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Core.DataBase.Models
{
    [Table("records")]
    public class EfRecord : IEfRecord
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
        [Column("sum")]
        public double Sum { get; set; }

        [Required]
        [Column("operation_type")]
        public MoneyOperationType OperationType { get; set; }

        [Required]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("delete_date")]
        public DateTime? DeleteDate { get; set; }


        public EfEntityImage? Image { get; set; }
        public EfMetaLabel? MetaLabel { get; set; }
        public EfBaseCategory? BaseCategory { get; set; }
        public EfSubCategory? SubCategory { get; set; }
        public EfMoneyStorage? MoneyStorage { get; set; }

        public static EfRecord GetDefaultEntity()
        {
            return new()
            {
                Uuid = Guid.NewGuid(),
                Name = "Default base category name",
                Sum = 0,
                OperationType = MoneyOperationType.NONE,
                CreateDate = DateTime.Now,
            };
        }
    }
}
