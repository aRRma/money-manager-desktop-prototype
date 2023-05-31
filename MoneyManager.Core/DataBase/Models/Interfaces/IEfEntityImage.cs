using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfEntityImage : IEfNamedEntity
    {
        public string Path { get; set; }
    }
}
