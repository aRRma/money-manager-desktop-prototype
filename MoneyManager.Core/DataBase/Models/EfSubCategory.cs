using MoneyManager.Core.DataBase.Models.Base;
using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Models
{
    public class EfSubCategory : IEfSubCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public EfMetaLabel MetaLabel { get; set; }
        public EfBaseCategory BaseCategory { get; set; }
        public List<EfSubCategory> SubCategories { get; set; } = new();
    }
}
