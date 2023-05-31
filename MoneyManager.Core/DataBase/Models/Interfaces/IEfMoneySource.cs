using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfMoneySource : IEfNamedEntity
    {
        public MoneySourceType SourceType { get; set; }
    }
}
