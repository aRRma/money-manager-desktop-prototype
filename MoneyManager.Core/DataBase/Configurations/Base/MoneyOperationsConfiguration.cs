using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models.Base;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.Extensions;

namespace MoneyManager.Core.DataBase.Configurations.Base
{
    internal class MoneyOperationsConfiguration : IEntityTypeConfiguration<EfMoneyOperation>
    {
        public void Configure(EntityTypeBuilder<EfMoneyOperation> builder)
        {
            builder.HasData(
                Enumerable.Range(1, MoneyOperationType.NONE.GetLength())
                .Select(x => new EfMoneyOperation()
                {
                    Id = x,
                    CreateDate = DateTime.Now,
                    OperationType = (MoneyOperationType)x,
                    Name = ((MoneyOperationType)x).GetDescription()
                }));
        }
    }
}
