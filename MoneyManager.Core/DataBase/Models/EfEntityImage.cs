using MoneyManager.Core.DataBase.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Core.DataBase.Models
{
    [Table("entity_images")]
    public class EfEntityImage : IEfEntityImage
    {
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        public Guid Uuid { get; set; }
        
        [Required]
        [Column("name")]
        public string Name { get; set; }
        
        [Required]
        [Column("path")]
        public string Path { get; set; }
        
        [Required]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("delete_date")]
        public DateTime? DeleteDate { get; set; }

        public static EfEntityImage GetDefaultEntity()
        {
            return new()
            {
                Uuid = Guid.NewGuid(),
                Name = "Default base category name",
                Path = "./",
                CreateDate = DateTime.Now,
            };
        }
    }
}
