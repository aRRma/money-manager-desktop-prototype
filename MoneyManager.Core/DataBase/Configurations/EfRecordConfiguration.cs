using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;

namespace MoneyManager.Core.DataBase.Configurations
{
    internal class EfRecordConfiguration : IEntityTypeConfiguration<EfRecord>
    {
        public void Configure(EntityTypeBuilder<EfRecord> builder)
        {
            builder.HasIndex(x => x.Uuid);
        }
    }
}
