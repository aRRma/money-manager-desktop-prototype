using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Repository.Interfaces
{
    public interface IEfNamedRepository<T> : IEfBaseRepository<T> where T : class, IEfNamedEntity, new()
    {
        public Task<bool> ExistByNameAsync(string name, CancellationToken cancellationToken = default);

        public Task<T> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        public Task<T?> DeleteByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
