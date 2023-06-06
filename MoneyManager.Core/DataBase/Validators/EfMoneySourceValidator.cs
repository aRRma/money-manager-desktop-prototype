﻿// Ignore Spelling: Validators
// Ignore Spelling: Validator
// Ignore Spelling: Ef

using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Validators
{
    public class EfMoneySourceValidator<T> : EfNamedEntityValidator<T>
        where T : IEfMoneySource
    {
        public EfMoneySourceValidator()
            : base()
        {

        }
    }
}
