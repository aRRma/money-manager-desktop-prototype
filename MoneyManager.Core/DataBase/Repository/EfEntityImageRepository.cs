using FluentValidation;
using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfEntityImageRepository : EfNamedRepository<EfEntityImage>
    {
        private readonly ILogger<EfEntityImageRepository> _logger;
        private readonly IValidator<IEfNamedEntity> _validator;

        public EfEntityImageRepository(AppDbContext appDbContext, ILogger<EfEntityImageRepository> logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
