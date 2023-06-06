// Ignore Spelling: Validators
// Ignore Spelling: Validator
// Ignore Spelling: Ef

using FluentValidation;
using MoneyManager.Core.Constants;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Validators
{
    internal class EfRecordValidator<T> : EfNamedEntityValidator<T>
        where T : IEfRecord
    {
        public EfRecordValidator()
            : base()
        {
            RuleFor(x => x.Sum)
                .NotEqual(0.0m)
                .When(x => x.OperationType != MoneyOperationType.NONE)
                .WithMessage(ValidatorConstantProvider.DefaultValidateErrorTemplate);
        }
    }
}
