using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.Extensions;

namespace MoneyManager.Core.DataBase.Configurations
{
    internal class EfMoneyStoragesConfiguration : IEntityTypeConfiguration<EfMoneyStorage>
    {
        public void Configure(EntityTypeBuilder<EfMoneyStorage> builder)
        {
            builder.HasIndex(x => x.Uuid);
            builder.HasData(new EfMoneyStorage[]
            {
                new() 
                {
                    Id = 1,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = MoneySourceType.CASH.GetDescription(),
                    TotalSum = 1000.99m,
                },
                new()
                {
                    Id = 2,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = MoneySourceType.ECASH.GetDescription(),
                    TotalSum = 888.99m
                },
                new()
                {
                    Id = 3,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = MoneySourceType.MONEYBOX.GetDescription(),
                    TotalSum = 150000.99m
                },
            });
        }
    }
}
