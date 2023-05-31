using MoneyManager.Core.DataBase.Models;

namespace MoneyManager.Core.Extensions
{
    public static class EfTypesExtensions
    {
        public static Dictionary<string, string> ToDicDescription(this EfMoneyStorage storage)
        {
            var type = storage.GetType();
            var props = type.GetProperties();
            var dic = new Dictionary<string, string>();

            foreach (var item in props)
            {
                string key;
                string value;

                if (item.PropertyType == typeof(EfEntityImage))
                {
                    var propVal = item.GetValue(storage);
                    key = "ImageId";
                    value = propVal is not null
                        ? ((EfEntityImage)propVal).Id.ToString()
                        : "";
                }
                else if (item.PropertyType == typeof(EfMoneySource))
                {
                    var propVal = item.GetValue(storage);
                    key = "MoneySourceName";
                    value = propVal is not null
                        ? ((EfMoneySource)propVal).Name
                        : "";
                }
                else if (item.PropertyType == typeof(List<EfRecord>))
                {
                    var propVal = item.GetValue(storage);
                    key = "RecordsCount";
                    value = propVal is not null
                        ? ((List<EfRecord>)propVal).Count.ToString()
                        : "";
                }
                else
                {
                    key = item.Name;
                    value = item.GetValue(storage)?.ToString() ?? "";
                }

                dic.Add(key, value);
            }

            return dic;
        }
    }
}
