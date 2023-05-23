﻿using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces;

namespace MoneyManager.Core.DataBase.Models
{
    /// <summary>
    /// Метка записи
    /// </summary>
    public class EfMetaLabel : IEfRecordLabel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public MetaLabelType RecordLabel { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}