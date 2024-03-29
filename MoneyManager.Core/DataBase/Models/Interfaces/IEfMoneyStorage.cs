﻿using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfMoneyStorage : IEfNamedEntity
    {
        public decimal TotalSum { get; set; }
    }
}
