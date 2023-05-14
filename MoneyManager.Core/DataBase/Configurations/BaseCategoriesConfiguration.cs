using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.Extensions;

namespace MoneyManager.Core.DataBase.Configurations
{
    internal class BaseCategoriesConfiguration : IEntityTypeConfiguration<EfBaseCategory>
    {
        public void Configure(EntityTypeBuilder<EfBaseCategory> builder)
        {
            builder.HasData(new EfBaseCategory[]
            {
                new()
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.EAT.GetDescription(),
                },
                new()
                {
                    Id = 2,
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.PURCHASES.GetDescription()
                },
                new()
                {
                    Id = 3,
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.TRANSPORT.GetDescription()
                },
                new()
                {
                    Id = 4,
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.RELAXATION.GetDescription()
                },
                new()
                {
                    Id = 5,
                    CreateDate = DateTime.Now,
                    Name = MetaLabelType.OTHER.GetDescription()
                },
            });
        }
    }
}
