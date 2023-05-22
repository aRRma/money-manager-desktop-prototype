using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Constants;

namespace MoneyManager.Core.DataBase.Configurations
{
    internal class SubCategoriesConfiguration : IEntityTypeConfiguration<EfSubCategory>
    {
        public void Configure(EntityTypeBuilder<EfSubCategory> builder)
        {
            builder.HasData(new EfSubCategory[]
            {
                new()
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuMagnit,
                },
                new()
                {
                    Id = 2,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRu5ka,
                },
                new()
                {
                    Id = 3,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuOzon,
                },
                new()
                {
                    Id = 4,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuWildberries,
                },
                new()
                {
                    Id = 5,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuUnderground,
                },
                new()
                {
                    Id = 6,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuTrain,
                },
                new()
                {
                    Id = 7,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstants.SubCategoryRuKarting,
                },
            });
        }
    }
}
