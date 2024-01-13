using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Config
{
    public class DataBaseConfig
    {
        [Required]
        public DataBaseType Type { get; init; }
        
        [Required]
        public LogLevel LogLevel { get; init; }

        [Required]
        public string Name { get; init; }

        [Required]
        public string ConnectionString { get; init; }

        [Required]
        public bool AllowForceRecreateBase { get; init; }

        public string? ConfigPath { get; init; }

        public List<DataBaseCredential>? Credential { get; init; }

        public List<DataBaseNetwork>? Network { get; init; }
    }
}
