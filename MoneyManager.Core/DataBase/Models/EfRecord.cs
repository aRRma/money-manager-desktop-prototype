using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models
{
    public class EfRecord : IEfRecord
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public Guid Uuid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Sum { get; set; }
        [Required]
        public MoneyOperationType OperationType { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public EfEntityImage? Image { get; set; }
        public EfMetaLabel? MetaLabel { get; set; }
        public EfBaseCategory? BaseCategory { get; set; }
        public EfSubCategory? SubCategory { get; set; }
        public EfMoneyStorage? MoneyStorage { get; set; }
    }
}
