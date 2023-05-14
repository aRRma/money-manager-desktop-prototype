using MoneyManager.Core.DataBase.Models.Enums;
using System.ComponentModel;
using System.Reflection;

namespace MoneyManager.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T data) where T : System.Enum
        {
            var customAttribute = data.GetType()
                .GetMember(data.ToString())
                .SingleOrDefault()
                ?.GetCustomAttribute((typeof(DescriptionAttribute)));
            return ((DescriptionAttribute)customAttribute)?.Description ?? "";
        }

        public static int GetLength<T>(this T data) where T : System.Enum
        {
            return Enum.GetValues(data.GetType()).Length;
        }
    }
}
