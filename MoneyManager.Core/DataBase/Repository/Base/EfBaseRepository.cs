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

        public async Task<T> Add(T item, CancellationToken cancellationToken = default)
        {
            Guard.IsNull(item);

            await _dbContext.AddAsync(item, cancellationToken).ConfigureAwait(false);
            await SaveChanges(cancellationToken).ConfigureAwait(false);

            return item;
        }

        public async Task<IReadOnlyList<T>> Add(IEnumerable<T> items, CancellationToken cancellationToken = default)
        {
            Guard.IsNull(items);

            await _dbContext.AddRangeAsync(items, cancellationToken).ConfigureAwait(false);
            await SaveChanges(cancellationToken).ConfigureAwait(false);

            return items.ToList();
        }

        public async Task<T?> Delete(T item, CancellationToken cancellationToken = default)
        {
            Guard.IsNull(item);

            if (!await ExistId(item.Id, cancellationToken).ConfigureAwait(false))
                return null;

            _dbContext.Remove(item);
            await SaveChanges(cancellationToken).ConfigureAwait(false);

            return item;
        }

        public async Task<T?> DeleteById(long id, CancellationToken cancellationToken = default)
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

            return await Delete(item, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> Exist(T item, CancellationToken cancellationToken = default)
        {
            Guard.IsNull(item);

            return await Items.AnyAsync(x => x.Id == item.Id).ConfigureAwait(false);
        }

        public async Task<bool> ExistId(long id, CancellationToken cancellationToken = default)
        {
            Guard.IsGreaterThan(id, 0);

            return await Items.AnyAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> Get(int count, int skip = 0, CancellationToken cancellationToken = default)
        {
            if (count <= 0)
                return new List<T>().AsReadOnly();

            IQueryable<T> query = Items.OrderBy(x => x.Id);

            if (skip > 0)
                query = query.Skip(skip);

            return await query.Take(count).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Items.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> GetById(long id, CancellationToken cancellationToken = default)
        {
            Guard.IsGreaterThan(id, 0);

            return await Items
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                .ConfigureAwait(false)
                ?? new T();
        }

        public async Task<T> GetByUuid(Guid uuid, CancellationToken cancellationToken = default)
        {
            return await Items
                .FirstOrDefaultAsync(x => x.Uuid == uuid, cancellationToken)
                .ConfigureAwait(false)
                ?? new T();
        }

        public async Task<int> GetCount(CancellationToken cancellationToken = default)
        {
            return await Items.CountAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEfPage<T>> GetPage(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
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

        public async Task<T> Update(T item, CancellationToken cancellationToken = default)
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