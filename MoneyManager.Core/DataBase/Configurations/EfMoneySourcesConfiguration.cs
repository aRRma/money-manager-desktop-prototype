using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.Extensions;

namespace MoneyManager.Core.DataBase.Configurations
{
    internal class EfMoneySourcesConfiguration : IEntityTypeConfiguration<EfMoneySource>
    {
        public void Configure(EntityTypeBuilder<EfMoneySource> builder)
        {
            builder.HasIndex(x => x.Uuid);
            builder.HasData(
                Enumerable.Range(1, MoneySourceType.NONE.GetLength())
                .Select(x => new EfMoneySource()
                {
                    Id = x,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    SourceType = (MoneySourceType)x,
                    Name = ((MoneySourceType)x).GetDescription()
                }));
        }
    }
}
