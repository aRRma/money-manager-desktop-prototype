using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Config
{
    /// <summary>
    /// Сетевая конфигурация базы
    /// </summary>
    public class DataBaseNetwork
    {
        [Required]
        public string Host { get; init; }

        [Required]
        public string Port{ get; init; }

        // TODO протокол, ssl, серт и тд.
    }
}
