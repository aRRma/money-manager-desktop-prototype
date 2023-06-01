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

        [Column("delete_date")]
        public DateTime? DeleteDate { get; set; }


        public EfEntityImage? Image { get; set; }
        public EfMetaLabel? MetaLabel { get; set; }
        public EfBaseCategory? BaseCategory { get; set; }
        public virtual List<EfSubCategory> SubCategories { get; set; } = new();
    }
}
