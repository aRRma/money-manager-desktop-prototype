using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.Extensions;

namespace MoneyManager.Core.DataBase.EntityConfigurations
{
    internal class EfBaseCategoriesConfiguration : IEntityTypeConfiguration<EfBaseCategory>
    {
        public void Configure(EntityTypeBuilder<EfBaseCategory> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.Uuid);
            builder.HasData(new EfBaseCategory[]
            {
                new()
                {
                    Id = 1,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.EAT.GetDescription(),
                },
                new()
                {
                    Id = 2,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.PURCHASES.GetDescription()
                },
                new()
                {
                    Id = 3,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.TRANSPORT.GetDescription()
                },
                new()
                {
                    Id = 4,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.RELAXATION.GetDescription()
                },
                new()
                {
                    Id = 5,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.OTHER.GetDescription()
                },
            });
        }
    }
}
