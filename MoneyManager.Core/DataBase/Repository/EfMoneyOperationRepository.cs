using FluentValidation;
using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfMoneyOperationRepository : EfNamedRepository<EfMoneyOperation>
    {
        private readonly ILogger<EfMoneyOperationRepository> _logger;
        private readonly IValidator<IEfNamedEntity> _validator;

        public EfMoneyOperationRepository(AppDbContext appDbContext, ILogger<EfMoneyOperationRepository> logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
