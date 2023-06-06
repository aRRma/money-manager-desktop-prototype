// Ignore Spelling: Validators
// Ignore Spelling: Validator
// Ignore Spelling: Ef

using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Validators
{
    public class EfMetaLabelValidator<T> : EfNamedEntityValidator<T>
        where T : IEfMetaLabel
    {
        public EfMetaLabelValidator()
            : base()
        {

        }
    }
}
