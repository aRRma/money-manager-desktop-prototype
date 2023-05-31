using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Repository.Interfaces
{
    public interface IEfNamedRepository<T> : IEfBaseRepository<T> where T : class, IEfNamedEntity, new()
    {
        public Task<bool> ExistByName(string name, CancellationToken cancellationToken = default);

        public Task<T> GetByName(string name, CancellationToken cancellationToken = default);

        public Task<T?> DeleteByName(string name, CancellationToken cancellationToken = default);
    }
}
