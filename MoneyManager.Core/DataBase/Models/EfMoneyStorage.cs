using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models
{
    /// <summary>
    /// Хранилище денег
    /// </summary>
    public class EfMoneyStorage : IEfMoneyStorage
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public Guid Uuid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal TotalSum { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public EfEntityImage? Image { get; set; }
        public EfMoneySource? MoneySource { get; set; }
        public List<EfRecord> Records { get; set; } = new();
    }
}
