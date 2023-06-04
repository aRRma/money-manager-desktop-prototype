using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using System.Data;
using System.Runtime.CompilerServices;

namespace MoneyManager.Core.Constants
{
    public interface IAppDbExceptionConstantProvider
    {
        public string SqliteUniqueConstraintFailed { get; }

        /// <summary>
        /// Генерация текста ошибки при дублировании имени сущности в базе
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="callerName"></param>
        /// <returns></returns>
        public string GetDuplicateEntityByNameExceptionMessage(IEfNamedEntity entity, [CallerMemberName] string? callerName = default);

        /// <summary>
        /// Генерация текста ошибки при дублировании id сущности в базе
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="callerName"></param>
        /// <returns></returns>
        public string GetDuplicateEntityByIdExceptionMessage(IEfNamedEntity entity, [CallerMemberName] string? callerName = default);

    }
}
