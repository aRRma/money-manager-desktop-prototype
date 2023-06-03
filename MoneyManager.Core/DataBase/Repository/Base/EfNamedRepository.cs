using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Repository.Interfaces;

namespace MoneyManager.Core.DataBase.Repository.Base
{
    public abstract class EfNamedRepository<T> : EfBaseRepository<T>, IEfNamedRepository<T> where T : class, IEfNamedEntity, new()
    {
        public EfNamedRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }

        public async Task<T?> DeleteByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNullOrEmpty(name);

            //var item = DataSet.Local.FirstOrDefault(x => EF.Functions.Like(x.Name, name));
            var item = DataSet.Local.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));
            if (item is null)
                item = await Items
                    .Select(x => new T { Id = x.Id, Name = x.Name })
                    .FirstOrDefaultAsync(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase), cancellationToken)
                    .ConfigureAwait(false);
            if (item is null)
                return null;

            return await DeleteAsync(item, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> ExistByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNullOrEmpty(name);

            if (UseLocalView)
            {
                // TODO предположительно быстрее, но надо проверить
                return await DataSet
                    .AnyAsync(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase))
                    .ConfigureAwait(false);
            }

            return await Items
                //.AnyAsync(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase), cancellationToken)
                .AnyAsync(x => EF.Functions.Like(x.Name, name), cancellationToken) // для sqlite'a like регистронезависимый
                .ConfigureAwait(false);
        }

        public async Task<T> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNullOrEmpty(name);

            if (UseLocalView)
            {
                // TODO предположительно быстрее, но надо проверить
                var localItem = await DataSet
                    .FirstOrDefaultAsync(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase))
                    .ConfigureAwait(false);

                if (localItem is not null)
                    return await Items.SingleOrDefaultAsync(x => x.Id == localItem.Id)
                        .ConfigureAwait(false)
                        ?? new T();
            }

            return await Items
                .FirstOrDefaultAsync(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase), cancellationToken)
                .ConfigureAwait(false)
                ?? new T();
        }
    }
}
