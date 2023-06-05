using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoneyManager.Core.Constants;
using MoneyManager.Core.DataBase.Exceptions;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfBaseCategoryRepository : EfNamedRepository<EfBaseCategory>
    {
        private readonly ILogger<EfBaseCategoryRepository> _logger;
        private readonly IAppDbExceptionConstantProvider _exceptionConstantProvider;
        private readonly IValidator<IEfNamedEntity> _validator;

        public EfBaseCategoryRepository(
            AppDbContext appDbContext,
            ILogger<EfBaseCategoryRepository> logger,
            IAppDbExceptionConstantProvider exceptionConstantProvider,
            IValidator<IEfNamedEntity> validator)
            : base(appDbContext)
        {
            _logger = logger;
            _exceptionConstantProvider = exceptionConstantProvider;
            _validator = validator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"/>
        /// <exception cref="DbUpdateException"/>
        /// <exception cref="DuplicateEntityException"/>
        /// <exception cref="ArgumentNullException"/>
        public async Task<EfBaseCategory> BaseCategoryAddAsync(EfBaseCategory item, CancellationToken cancellationToken = default)
        {
            try
            {
                _validator.ValidateAndThrow(item);

                if (await ExistByNameAsync(item.Name, cancellationToken).ConfigureAwait(false))
                    throw new DuplicateEntityException(_exceptionConstantProvider.GetDuplicateEntityByNameExceptionMessage(item));

                await AddAsync(item, cancellationToken).ConfigureAwait(false);

                return item;
            }
            catch(ValidationException ex)
            {
                // TODO log
                throw;
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
