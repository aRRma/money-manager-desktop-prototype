using MoneyManager.Core.DataBase.Models.Interfaces.Base;
using System.Runtime.CompilerServices;

namespace MoneyManager.Core.Constants
{
    /// <inheritdoc/>
    public class AppDbExceptionConstantProvider : IAppDbExceptionConstantProvider
    {
        public string SqliteUniqueConstraintFailed => "UNIQUE constraint failed";

        public string GetDuplicateEntityByIdExceptionMessage(IEfNamedEntity entity, [CallerMemberName] string? callerName = null)
            => $"Duplicate entity [{entity.GetType().Name}]. Entity with parameter 'id' - [{entity.Id}]. From method [{callerName}]";

        public string GetDuplicateEntityByNameExceptionMessage(IEfNamedEntity entity, [CallerMemberName] string? callerName = default)
            => $"Duplicate entity [{entity.GetType().Name}]. Entity with parameter 'name' - [{entity.Name}]. From method [{callerName}]";
    }
}
