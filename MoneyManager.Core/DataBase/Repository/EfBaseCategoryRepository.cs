using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfBaseCategoryRepository : EfNamedRepository<EfBaseCategory>
    {
        private readonly ILogger<EfBaseCategoryRepository> _logger;

        public EfBaseCategoryRepository(AppDbContext appDbContext, ILogger<EfBaseCategoryRepository> logger)
            : base(appDbContext)
        {
            _logger = logger;
        }

        public async Task<bool> BaseCategoryAddAsync(EfBaseCategory item, CancellationToken cancellationToken = default)
        {
            try
            {
                if (await ExistByNameAsync(item.Name, cancellationToken).ConfigureAwait(false))
                    return false;

                await AddAsync(item, cancellationToken);

                if (item.Id == default)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> BaseCategoryRemoveAsync(EfBaseCategory item, CancellationToken cancellationToken = default)
        {
            // TODO тут скорее должно быть тупо удаление если это возможно
            // вся логика переноса sub категорий и записей кудато, должна быть в бизнес процессоре
            throw new NotImplementedException();
        }
    }
}
