using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Repository.Interfaces;

namespace MoneyManager.Core.DataBase.Repository.Base
{
    public abstract class EfBaseRepository<T> : IEfBaseRepository<T> where T : class, IEfBaseEntity, new()
    {
        private readonly AppDbContext _dbContext;

        public EfBaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            DataSet = dbContext.Set<T>();

            //TODO возможно не надо инжектить DbContext, а запрашивать его через фабрику в методах
            //т.к. саму репу лучше делать одиночкой дабы не плодить обьекты
        }

        public bool UseLocalView { get; set; }

        protected DbSet<T> DataSet { get; init; }

        protected IQueryable<T> Items => DataSet;

        public async Task<T> AddAsync(T item, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(item);

            await _dbContext.AddAsync(item, cancellationToken).ConfigureAwait(false);
            await SaveChanges(cancellationToken).ConfigureAwait(false);

            return item;
        }

        public async Task<IReadOnlyList<T>> AddAsync(IEnumerable<T> items, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(items);

            await _dbContext.AddRangeAsync(items, cancellationToken).ConfigureAwait(false);
            await SaveChanges(cancellationToken).ConfigureAwait(false);

            return items.ToList();
        }

        public async Task<T?> DeleteAsync(T item, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(item);

            var some = _dbContext.Remove(item);
            await SaveChanges(cancellationToken).ConfigureAwait(false);

            return item;
        }

        public async Task<T?> DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            Guard.IsGreaterThan(id, 0);

            var item = DataSet.Local.FirstOrDefault(x => x.Id == id);
            if (item is null)
                item = await Items
                    .Select(x => new T { Id = x.Id }) // вытаскиваем из бд только id
                    .SingleOrDefaultAsync(x => x.Id == id)
                    .ConfigureAwait(false);
            if (item is null)
                return null;

            return await DeleteAsync(item, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> ExistAsync(T item, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(item);

            return await Items.AnyAsync(x => x.Id == item.Id).ConfigureAwait(false);
        }

        public async Task<bool> ExistByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            Guard.IsGreaterThan(id, 0);

            return await Items.AnyAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> GetAsync(int count, int skip = 0, CancellationToken cancellationToken = default)
        {
            if (count <= 0)
                return new List<T>().AsReadOnly();

            IQueryable<T> query = Items.OrderBy(x => x.Id);

            if (skip > 0)
                query = query.Skip(skip);

            return await query.Take(count).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Items.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            Guard.IsGreaterThan(id, 0);

            return await Items
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                .ConfigureAwait(false)
                ?? new T();
        }

        public async Task<T> GetByUuidAsync(Guid uuid, CancellationToken cancellationToken = default)
        {
            return await Items
                .FirstOrDefaultAsync(x => x.Uuid == uuid, cancellationToken)
                .ConfigureAwait(false)
                ?? new T();
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await Items.CountAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEfPage<T>> GetPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            Guard.IsGreaterThan(pageIndex, -1);
            Guard.IsGreaterThan(pageSize, -1);

            IQueryable<T> query = Items.OrderBy(x => x.Id);

            var totalCount = await query.CountAsync(cancellationToken).ConfigureAwait(false);
            if (totalCount == 0)
                return new EfPage<T>(new List<T>().AsReadOnly(), 0, pageIndex, pageSize);

            if (pageIndex > 0)
                query = query.Skip(pageIndex * pageSize);

            var items = await query.Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false);

            return new EfPage<T>(items, totalCount, pageIndex, pageSize);
        }

        public async Task<T> UpdateAsync(T item, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(item);

            _dbContext.Update(item);
            await SaveChanges(cancellationToken).ConfigureAwait(false);

            return item;
        }

        protected async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    public record EfPage<T>(IReadOnlyList<T> Items, int TotalCount, int PageIndex, int PageSize) : IEfPage<T> where T : class, IEfBaseEntity, new()
    {
        public int TotalPagesCount => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}