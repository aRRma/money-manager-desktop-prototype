using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfSubCategoryRepository : EfNamedRepository<EfSubCategory>
    {
        private readonly ILogger _logger;

        public EfSubCategoryRepository(AppDbContext appDbContext, ILogger logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
