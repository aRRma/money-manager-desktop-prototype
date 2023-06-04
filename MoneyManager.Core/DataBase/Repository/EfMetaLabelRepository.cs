using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfMetaLabelRepository : EfNamedRepository<EfMetaLabel>
    {
        private readonly ILogger<EfMetaLabelRepository> _logger;

        public EfMetaLabelRepository(AppDbContext appDbContext, ILogger<EfMetaLabelRepository> logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
