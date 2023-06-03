using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;
using System.Globalization;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfStorageRepository : EfNamedRepository<EfMoneyStorage>
    {
        private readonly ILogger _logger;

        public EfStorageRepository(AppDbContext dbContext, ILogger logger)
            : base(dbContext)
        {
            _logger = logger;

            // TODO мож сюда какой-то валидатор надо?
            // в валидаторе должны быть правила типо макс сумма. минимальная, можно ли в минус уходить это все проверять перед операциями.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
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
                catch (Exception ex)
                {
                    // TODO log
                    return false;
                }
            }
            return false;
        }

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
