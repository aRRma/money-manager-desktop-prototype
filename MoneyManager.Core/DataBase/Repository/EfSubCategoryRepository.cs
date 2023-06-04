using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfSubCategoryRepository : EfNamedRepository<EfSubCategory>
    {
        private readonly ILogger<EfSubCategoryRepository> _logger;

        public EfSubCategoryRepository(AppDbContext appDbContext, ILogger<EfSubCategoryRepository> logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
