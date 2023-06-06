using FluentValidation;
using Microsoft.Extensions.Logging;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using MoneyManager.Core.DataBase.Repository.Base;

namespace MoneyManager.Core.DataBase.Repository
{
    public sealed class EfMetaLabelRepository : EfNamedRepository<EfMetaLabel>
    {
        private readonly ILogger<EfMetaLabelRepository> _logger;
        private readonly IValidator<IEfNamedEntity> _validator;

        public EfMetaLabelRepository(AppDbContext appDbContext, ILogger<EfMetaLabelRepository> logger) 
            : base(appDbContext)
        {
            _logger = logger;
        }
    }
}
