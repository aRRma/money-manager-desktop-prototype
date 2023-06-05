using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoneyManager.Core.Constants;
using MoneyManager.Core.DataBase.Exceptions;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfBaseCategoryRepository : EfNamedRepository<EfBaseCategory>
    {
        private readonly ILogger<EfBaseCategoryRepository> _logger;
        private readonly IAppDbExceptionConstantProvider _exceptionConstantProvider;

        public EfBaseCategoryRepository(
            AppDbContext appDbContext,
            ILogger<EfBaseCategoryRepository> logger,
            IAppDbExceptionConstantProvider exceptionConstantProvider)
            : base(appDbContext)
        {
            _logger = logger;
            _exceptionConstantProvider = exceptionConstantProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateEntityException"/>
        /// <exception cref="ArgumentNullException"/>
        public async Task<EfBaseCategory> BaseCategoryAddAsync(EfBaseCategory item, CancellationToken cancellationToken = default)
        {
            try
            {
                if (await ExistByNameAsync(item.Name, cancellationToken).ConfigureAwait(false))
                {
                    // TODO log
                    throw new DuplicateEntityException(_exceptionConstantProvider.GetDuplicateEntityByNameExceptionMessage(item));
                }

                await AddAsync(item, cancellationToken).ConfigureAwait(false);

                if (item.Id == default) return null;
                return item;
            }
            catch (DbUpdateException ex)
            {
                // TODO log
                if (ex.InnerException?.Message.Contains(_exceptionConstantProvider.SqliteUniqueConstraintFailed) ?? false)
                    throw new DuplicateEntityException(_exceptionConstantProvider.GetDuplicateEntityByIdExceptionMessage(item), ex);
                throw;
            }
            catch (Exception ex)
            {
                // TODO log
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateEntityException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public async Task<bool> BaseCategoryRemoveAsync(EfBaseCategory item, CancellationToken cancellationToken = default)
        {
            // TODO тут скорее должно быть тупо удаление если это возможно
            // вся логика переноса sub категорий и записей кудато, должна быть в бизнес процессоре
            try
            {
                if (!await ExistByIdAsync(item.Id, cancellationToken).ConfigureAwait(false))
                    return false;

                await DeleteAsync(item, cancellationToken).ConfigureAwait(false);

                return true;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception)
            {
                    
                throw;
            }
        }
    }
}
