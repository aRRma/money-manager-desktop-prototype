﻿using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces.Base;

namespace MoneyManager.Core.DataBase.Models.Interfaces
{
    public interface IEfRecord : IEfNamedEntity
    {
        public double Sum { get; set; }

        public MoneyOperationType OperationType { get; set; }
    }
}
