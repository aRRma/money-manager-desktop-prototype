using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using System.Collections.Generic;

namespace MoneyManager.Core.DataBase.Repository.Interfaces
{
    public interface IEfBaseRepository<T> where T : IEfBaseEntity
    {
        public Task<T> Add(T item, CancellationToken cancellationToken = default);

        public Task<IReadOnlyList<T>> Add(IEnumerable<T> items, CancellationToken cancellationToken = default);

        public Task<T?> Delete(T item, CancellationToken cancellationToken = default);

        public Task<T?> DeleteById(long id, CancellationToken cancellationToken = default);

        public Task<bool> Exist(T item, CancellationToken cancellationToken = default);

        public Task<bool> ExistId(long id, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<T>> Get(int count, int skip = 0, CancellationToken cancellationToken = default);

        public Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default);

        public Task<T?> GetById(long id, CancellationToken cancellationToken = default);

        public Task<int> GetCount(CancellationToken cancellationToken = default);

        public Task<IEfPage<T>> GetPage(int pageIndex, int pageSize, CancellationToken cancellationToken  = default);
        
        public Task<T> Update(T item, CancellationToken cancellationToken  = default);
    }
}
