using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfMoneyStorageRepository : EfNamedRepository<EfMoneyStorage>
    {
        private readonly ILogger _logger;

        public EfMoneyStorageRepository(AppDbContext appDbContext, ILogger logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
