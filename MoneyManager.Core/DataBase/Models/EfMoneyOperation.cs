﻿using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Models
{
    /// <summary>
    /// Тип операции
    /// </summary>
    public class EfMoneyOperation : IEfMoneyOperation
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public Guid Uuid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public MoneyOperationType OperationType { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
