using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;

namespace MoneyManager.Core.DataBase.Configurations
{
    internal class EfEntityImageConfiguration : IEntityTypeConfiguration<EfEntityImage>
    {
        public void Configure(EntityTypeBuilder<EfEntityImage> builder)
        {
            builder.HasIndex(x => x.Uuid);
        }
    }
}
