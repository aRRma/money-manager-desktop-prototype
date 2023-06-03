using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfMoneyOperationRepository : EfNamedRepository<EfMoneyOperation>
    {
        private readonly ILogger _logger;

        public EfMoneyOperationRepository(AppDbContext appDbContext, ILogger logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
