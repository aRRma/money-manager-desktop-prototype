using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models
{
    /// <summary>
    /// Базовая категория
    /// </summary>
    public class EfBaseCategory : IEfBaseCategory
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public Guid Uuid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public EfEntityImage? Image { get; set; }
        public EfMetaLabel? MetaLabel { get; set; }
        public List<EfSubCategory> SubCategories { get; set; } = new();
        public List<EfRecord> Records { get; set; } = new();
    }
}
