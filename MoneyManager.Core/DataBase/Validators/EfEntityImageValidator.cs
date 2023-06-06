// Ignore Spelling: Validators
// Ignore Spelling: Validator
// Ignore Spelling: Ef

using FluentValidation;
using MoneyManager.Core.Constants;
using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Validators
{
    public class EfEntityImageValidator<T> : EfNamedEntityValidator<T>
        where T : IEfEntityImage
    {
        public EfEntityImageValidator()
            : base()
        {
            RuleFor(x => x.Path)
                .Must(x => Path.GetExtension(x).Length > 0)
                .WithMessage(ValidatorConstantProvider.DefaultValidateErrorTemplate);
        }
    }
}
