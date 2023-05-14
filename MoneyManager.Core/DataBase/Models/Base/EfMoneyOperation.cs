﻿using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Base
{
    /// <summary>
    /// Тип операции
    /// </summary>
    public class EfMoneyOperation : IEfMoneyOperation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public MoneyOperationType OperationType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
