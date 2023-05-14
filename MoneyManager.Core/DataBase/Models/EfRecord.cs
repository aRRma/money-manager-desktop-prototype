using MoneyManager.Core.DataBase.Models.Base;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Models
{
    public class EfRecord : IEfRecord
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Sum { get; set; }
        public MoneyOperationType OperationType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public EfMetaLabel MetaLabel { get; set; }
        public EfBaseCategory BaseCategory { get; set; }
        public EfSubCategory SubCategory { get; set; }
        public EfMoneyStorage MoneyStorage { get; set; }
    }
}
