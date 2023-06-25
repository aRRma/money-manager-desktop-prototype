using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Constants;

namespace MoneyManager.Core.DataBase.EntityConfigurations
{
    internal class EfSubCategoriesConfiguration : IEntityTypeConfiguration<EfSubCategory>
    {
        public void Configure(EntityTypeBuilder<EfSubCategory> builder)
        {
            builder.HasIndex(x => x.Uuid);
            builder.HasData(new EfSubCategory[]
            {
                new()
                {
                    Id = 1,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuMagnit,
                },
                new()
                {
                    Id = 2,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRu5ka,
                },
                new()
                {
                    Id = 3,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuOzon,
                },
                new()
                {
                    Id = 4,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuWildberries,
                },
                new()
                {
                    Id = 5,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuUnderground,
                },
                new()
                {
                    Id = 6,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuTrain,
                },
                new()
                {
                    Id = 7,
                    Uuid = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuKarting,
                },
            });
        }
    }
}
