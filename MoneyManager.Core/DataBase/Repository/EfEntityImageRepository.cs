using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfEntityImageRepository : EfNamedRepository<EfEntityImage>
    {
        private readonly ILogger<EfEntityImageRepository> _logger;

        public EfEntityImageRepository(AppDbContext appDbContext, ILogger<EfEntityImageRepository> logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
