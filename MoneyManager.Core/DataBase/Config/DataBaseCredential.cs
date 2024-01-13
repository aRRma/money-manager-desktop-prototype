using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Core.DataBase.Config
{
    /// <summary>
    /// Креды пользователя
    /// </summary>
    public class DataBaseCredential
    {
        [Required]
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }

        public string? Schema { get; init; }

        // TODO атата, так нельзя хранить креды!
    }
}
