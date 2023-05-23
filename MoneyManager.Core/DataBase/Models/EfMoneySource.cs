﻿using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Models
{
    /// <summary>
    /// Источник денег
    /// </summary>
    public class EfMoneySource : IEfMoneySource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public MoneySourceType SourceType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}