using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Constans;

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
                    Name = EfBaseModelConstans.SubCategoryRuMagnit,
                },
                new()
                {
                    Id = 2,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstans.SubCategoryRu5ka,
                },
                new()
                {
                    Id = 3,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstans.SubCategoryRuOzon,
                },
                new()
                {
                    Id = 4,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstans.SubCategoryRuWildberries,
                },
                new()
                {
                    Id = 5,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstans.SubCategoryRuUnderground,
                },
                new()
                {
                    Id = 6,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstans.SubCategoryRuTrain,
                },
                new()
                {
                    Id = 7,
                    CreateDate = DateTime.Now,
                    Name = EfBaseModelConstans.SubCategoryRuKarting,
                },
            });
        }
    }
}
