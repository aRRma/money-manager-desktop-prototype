using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfRecord : IEfNamedEntity
    {
        public decimal Sum { get; set; }

        public MoneyOperationType OperationType { get; set; }
    }
}
