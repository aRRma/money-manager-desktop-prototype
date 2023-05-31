using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.Extensions;

namespace MoneyManager.Core.DataBase.Configurations
{
    internal class EfMoneyOperationsConfiguration : IEntityTypeConfiguration<EfMoneyOperation>
    {
        public void Configure(EntityTypeBuilder<EfMoneyOperation> builder)
        {
            builder.HasIndex(x => x.Uuid);
            builder.HasData(
                Enumerable.Range(1, MoneyOperationType.NONE.GetLength())
                .Select(x => new EfMoneyOperation()
                {
                    Id = x,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    OperationType = (MoneyOperationType)x,
                    Name = ((MoneyOperationType)x).GetDescription()
                }));
        }
    }
}
