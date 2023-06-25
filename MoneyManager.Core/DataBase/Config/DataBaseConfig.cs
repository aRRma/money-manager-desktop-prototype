using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Config
{
    public class DataBaseConfig
    {
        [Required]
        public DataBaseType BaseType { get; init; }
        [Required]

        public string Name { get; init; }

        [Required]
        public string ConnectionString { get; init; }

        public List<DataBaseCredential>? Credential { get; init; }

        public List<DataBaseNetwork>? Network { get; init; }
    }
}
