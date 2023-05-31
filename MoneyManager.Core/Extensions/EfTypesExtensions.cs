using MoneyManager.Core.DataBase.Models;

namespace MoneyManager.Core.Extensions
{
    public static class EfTypesExtensions
    {
        public static Dictionary<string, string> ToDicDescription(this EfMoneyStorage storage)
        {
            return new()
            {
                { $"Id", $"{storage.Id}" },
                { $"Name", $"{storage.Name}" },
                { $"TotalSum", $"{storage.TotalSum}" },
                { $"CreateDate", $"{storage.CreateDate}" },
                { $"ImageId", $"{storage.Image?.Id}" },
                { $"MoneySourceName", $"{storage.MoneySource?.Name}" },
                { $"RecordsCount", $"{storage.Records?.Count}" }
            };
        }
    }
}
