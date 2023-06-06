// Ignore Spelling: Validators
// Ignore Spelling: Validator
// Ignore Spelling: Ef

using FluentValidation;
using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Validators
{
    public class EfMoneyStorageValidator<T> : EfNamedEntityValidator<T>
        where T : IEfMoneyStorage
    {
        public EfMoneyStorageValidator()
            : base()
        {
            RuleFor(x => x.TotalSum)
                .GreaterThan(-1);
        }
    }
}
