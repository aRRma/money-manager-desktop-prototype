using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.Extensions;

namespace MoneyManager.Core.DataBase.Configurations
{
    internal class EfMetaLabelsConfiguration : IEntityTypeConfiguration<EfMetaLabel>
    {
        public void Configure(EntityTypeBuilder<EfMetaLabel> builder)
        {
            builder.HasIndex(x => x.Uuid);
            builder.HasData(
                Enumerable.Range(1, MetaLabelType.NONE.GetLength())
                .Select(x => new EfMetaLabel()
                {
                    Id = x,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    RecordLabel = (MetaLabelType)x,
                    Name = ((MetaLabelType)x).GetDescription()
                }));
        }
    }
}
