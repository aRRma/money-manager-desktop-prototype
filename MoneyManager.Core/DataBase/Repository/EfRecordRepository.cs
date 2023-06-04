using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfRecordRepository : EfNamedRepository<EfRecord>
    {
        private readonly ILogger<EfRecordRepository> _logger;

        public EfRecordRepository(AppDbContext appDbContext, ILogger<EfRecordRepository> logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
