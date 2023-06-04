using System.Runtime.Serialization;

namespace MoneyManager.Core.DataBase.Exceptions
{
    [Serializable]
    public class DuplicateEntityException : Exception
    {
        public string? DuplicateEntityName { get; init; }

        public DuplicateEntityException()
        {

        }

        public DuplicateEntityException(string message)
            : base(message)
        {

        }

        public DuplicateEntityException(string message, Exception inner)
            : base(message, inner)
        {

        }

        protected DuplicateEntityException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            DuplicateEntityName = info?.GetString(nameof(DuplicateEntityName));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(DuplicateEntityName), DuplicateEntityName);
        }
    }
}
