namespace MoneyManager.Core.DataBase.Repository.Interfaces
{
    public interface IEfPage<out T>
    {
        IReadOnlyList<T> Items { get; }

        int TotalCount { get; }

        int PageIndex { get; }

        int PageSize { get; }

        int TotalPagesCount { get; }
    }
}
