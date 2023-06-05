using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Core.DataBase.Models
{
    [Table("sub_categories")]
    public class EfSubCategory : IEfSubCategory
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
        [Column("create_date")]
        public DateTime CreateDate { get; set; }


        public EfEntityImage? Image { get; set; }
        public EfMetaLabel? MetaLabel { get; set; }
        public EfBaseCategory? BaseCategory { get; set; }
        public virtual List<EfSubCategory> SubCategories { get; set; } = new();

        public static EfSubCategory GetDefaultEntity()
        {
            return new()
            {
                Uuid = Guid.NewGuid(),
                Name = "Default base category name",
                CreateDate = DateTime.Now,
            };
        }
    }
}
