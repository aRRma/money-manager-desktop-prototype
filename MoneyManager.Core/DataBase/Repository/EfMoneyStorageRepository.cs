using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoneyManager.Core.Constants;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Repository.Base;
using System.Globalization;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfMoneyStorageRepository : EfNamedRepository<EfMoneyStorage>
    {
        private readonly ILogger<EfMoneyStorageRepository> _logger;
        private readonly IAppDbExceptionConstantProvider _exceptionConstantProvider;
        private readonly IValidator<IEfNamedEntity> _validator;

        public EfMoneyStorageRepository(
            AppDbContext dbContext, 
            ILogger<EfMoneyStorageRepository> logger,
            IAppDbExceptionConstantProvider exceptionConstantProvider)
            : base(dbContext)
        {
            _logger = logger;
            _exceptionConstantProvider = exceptionConstantProvider;

            // TODO мож сюда какой-то валидатор надо?
            // в валидаторе должны быть правила типо макс сумма. минимальная, можно ли в минус уходить это все проверять перед операциями.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateException">Если item null</exception>
        /// <exception cref="ArgumentNullException">Если item null</exception>
        public async Task<bool> MoneyAdd(EfMoneyStorage item, string sum)
        {
            sum = sum.Replace('.', ',');

            if (decimal.TryParse(sum, NumberStyles.Any, CultureInfo.CurrentCulture, out var data))
            {
                item.TotalSum += data;

                try
                {
                    await UpdateAsync(item).ConfigureAwait(false);
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    // TODO log
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateException">Если item null</exception>
        /// <exception cref="ArgumentNullException">Если item null</exception>
        public async Task<bool> MoneyRemove(EfMoneyStorage item, string sum)
        {
            sum = sum.Replace('.', ',');

            if (decimal.TryParse(sum, NumberStyles.Any, CultureInfo.CurrentCulture, out var data))
            {
                item.TotalSum -= data;

                try
                {
                    await UpdateAsync(item).ConfigureAwait(false);
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    // TODO log
                    return false;
                }
            }

            return false;
        }
    }
}
