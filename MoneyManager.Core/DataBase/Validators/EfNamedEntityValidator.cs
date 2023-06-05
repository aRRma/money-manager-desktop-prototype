// Ignore Spelling: Validators
// Ignore Spelling: Validator
// Ignore Spelling: Ef

using FluentValidation;
using MoneyManager.Core.Constants;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Validators
{
    public class EfNamedEntityValidator : AbstractValidator<IEfNamedEntity>
    {
        public EfNamedEntityValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(-1)
                .WithMessage(ValidatorConstantProvider.DefaultValidateErrorTemplate);

            RuleFor(x => x.Name)
                .Must(x => x.All(char.IsLetter))
                .WithMessage(ValidatorConstantProvider.DefaultValidateErrorTemplate);

            RuleFor(x => x.CreateDate)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage(ValidatorConstantProvider.DefaultValidateErrorTemplate);
        }
    }
}
