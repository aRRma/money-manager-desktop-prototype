using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfMoneyOperationRepository : EfNamedRepository<EfMoneyOperation>
    {
        private readonly ILogger<EfMoneyOperationRepository> _logger;

        public EfMoneyOperationRepository(AppDbContext appDbContext, ILogger<EfMoneyOperationRepository> logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
