using System.ComponentModel;

namespace MoneyManager.Core.DataBase.Models.Enums
{
    /// <summary>
    /// Тип расчета источника
    /// </summary>
    public enum MoneySourceType
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        [Description("Неизвестно")]
        NONE = 1,
        /// <summary>
        /// Наличные
        /// </summary>
        [Description("Наличные")]
        CASH,
        /// <summary>
        /// Безналичные
        /// </summary>
        [Description("Безналичные")]
        ECASH,
        /// <summary>
        /// Кредит
        /// </summary>
        [Description("Кредит")]
        CREDIT,
        /// <summary>
        /// Копилка
        /// </summary>
        [Description("Копилка")]
        MONEYBOX,
    }
}
