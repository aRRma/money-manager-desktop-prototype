using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Repository.Interfaces
{
    public interface IEfBaseRepository<T> where T : IEfBaseEntity
    {
        public bool UseLocalView { get; set; }

        public Task<T> AddAsync(T item, CancellationToken cancellationToken = default);

        public Task<IReadOnlyList<T>> AddAsync(IEnumerable<T> items, CancellationToken cancellationToken = default);

        public Task<T?> DeleteAsync(T item, CancellationToken cancellationToken = default);

        public Task<T?> DeleteByIdAsync(long id, CancellationToken cancellationToken = default);

        public Task<bool> ExistAsync(T item, CancellationToken cancellationToken = default);

        public Task<bool> ExistByIdAsync(long id, CancellationToken cancellationToken = default);

        public Task<IReadOnlyList<T>> GetAsync(int count, int skip = 0, CancellationToken cancellationToken = default);

        public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

        public Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        public Task<T> GetByUuidAsync(Guid uuid, CancellationToken cancellationToken = default);

        public Task<int> GetCountAsync(CancellationToken cancellationToken = default);

        public Task<IEfPage<T>> GetPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken  = default);
        
        public Task<T> UpdateAsync(T item, CancellationToken cancellationToken  = default);
    }
}
