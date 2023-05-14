using System.ComponentModel;

namespace MoneyManager.Core.DataBase.Models.Enums
{
    /// <summary>
    /// Базовый типы лейблов
    /// </summary>
    public enum MetaLabelType
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        [Description("Неизвестно")]
        NONE = 1,
        /// <summary>
        /// Еда
        /// </summary>
        [Description("Еда")]
        EAT,
        /// <summary>
        /// Покупки
        /// </summary>
        [Description("Покупки")]
        PURCHASES,
        /// <summary>
        /// Жилье
        /// </summary>
        [Description("Жилье")]
        HOUSING,
        /// <summary>
        /// Транспорт
        /// </summary>
        [Description("Транспорт")]
        TRANSPORT,
        /// <summary>
        /// Личный транспорт
        /// </summary>
        [Description("Личный транспорт")]
        MY_TRANSPORT,
        /// <summary>
        /// Отдых
        /// </summary>
        [Description("Отдых")]
        RELAXATION,
        /// <summary>
        /// Связь
        /// </summary>
        [Description("Связь")]
        CONNECT,
        /// <summary>
        /// Финансовые
        /// </summary>
        [Description("Финансовые")]
        FINANSIAL,
        /// <summary>
        /// Инвестиции
        /// </summary>
        [Description("Инвестиции")]
        INVESTMENT,
        /// <summary>
        /// Доход
        /// </summary>
        [Description("Доход")]
        INCOME,
        /// <summary>
        /// Разное
        /// </summary>
        [Description("Разное")]
        OTHER
    }
}
