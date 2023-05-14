using System.ComponentModel;

namespace MoneyManager.Core.DataBase.Models.Enums
{
    /// <summary>
    /// Тип операции
    /// </summary>
    public enum MoneyOperationType
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        [Description("Неизвестно")]
        NONE = 1,
        /// <summary>
        /// Доход
        /// </summary>
        [Description("Доход")]
        INCOME,
        /// <summary>
        /// Расход
        /// </summary>
        [Description("Расход")]
        OUTCOME,
        /// <summary>
        /// Перевод
        /// </summary>
        [Description("Перевод")]
        TRANSFER,
        /// <summary>
        /// Займ
        /// </summary>
        [Description("Займ")]
        LOAN,
    }
}
