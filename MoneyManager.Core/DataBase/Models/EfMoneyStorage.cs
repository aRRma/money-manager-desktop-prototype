using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Models
{
    /// <summary>
    /// Хранилище денег
    /// </summary>
    public class EfMoneyStorage : IEfMoneyStorage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public EfMoneySource? MoneySource { get; set; }
        public List<EfRecord> Records { get; set; } = new();
    }
}
