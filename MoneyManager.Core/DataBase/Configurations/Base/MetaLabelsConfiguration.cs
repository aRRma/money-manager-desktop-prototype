using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models.Base;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.Extensions;

namespace MoneyManager.Core.DataBase.Configurations.Base
{
    internal class MetaLabelsConfiguration : IEntityTypeConfiguration<EfMetaLabel>
    {
        public void Configure(EntityTypeBuilder<EfMetaLabel> builder)
        {
            builder.HasData(
                Enumerable.Range(1, MetaLabelType.NONE.GetLength())
                .Select(x => new EfMetaLabel()
                {
                    Id = x,
                    CreateDate = DateTime.Now,
                    RecordLabel = (MetaLabelType)x,
                    Name = ((MetaLabelType)x).GetDescription()
                }));
        }
    }
}
