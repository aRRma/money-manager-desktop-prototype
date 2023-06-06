using FluentValidation;
using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfMoneySourceRepository : EfNamedRepository<EfMoneySource>
    {
        private readonly ILogger<EfMoneySourceRepository> _logger;
        private readonly IValidator<IEfNamedEntity> _validator;

        public EfMoneySourceRepository(AppDbContext appDbContext, ILogger<EfMoneySourceRepository> logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
