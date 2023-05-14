using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.DataBase.Configurations;
using MoneyManager.Core.DataBase.Configurations.Base;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Base;
using MoneyManager.Core.DataBase.Models.Constans;
using MoneyManager.Core.DataBase.Models.Enums;
using MoneyManager.Core.Extensions;

namespace MoneyManager.Core.DataBase
{
    public sealed class AppDbContext : DbContext
    {
        // простые типы (enum'ы всякие)
        public DbSet<EfMoneyOperation> MoneyOperations { get; set; }
        public DbSet<EfMoneySource> MoneySources { get; set; }
        public DbSet<EfMetaLabel> MetaLabels { get; set; }


        public DbSet<EfMoneyStorage> MoneyStorages { get; set; }
        public DbSet<EfBaseCategory> BaseCategories { get; set; }
        public DbSet<EfSubCategory> SubCategories { get; set; }
        public DbSet<EfRecord> Records { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            // удаляем и создаем базу при каждом запуске приложения
            Database.EnsureDeleted();
            Database.EnsureCreated();
            // базовая настройка для чистой базы
            SetUpMoneyStorages();
            SetUpBaseCategories(); 
            SetUpSubCategories();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // простые типы (enum'ы всякие)
            modelBuilder.ApplyConfiguration(new MetaLabelsConfiguration());
            modelBuilder.ApplyConfiguration(new MoneySourcesConfiguration());
            modelBuilder.ApplyConfiguration(new MoneyOperationsConfiguration());

            modelBuilder.ApplyConfiguration(new MoneyStoragesConfiguration());
            modelBuilder.ApplyConfiguration(new BaseCategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoriesConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        private void SetUpMoneyStorages()
        {
            var storages = this.MoneyStorages.ToList();
            var sources = this.MoneySources.ToList();

            foreach (var storage in storages)
            {
                storage.MoneySource = sources.Single(x => string.Equals(x.Name, storage.Name, StringComparison.OrdinalIgnoreCase));
            }

            SaveChanges();
        }

        private void SetUpBaseCategories()
        {
            var categories = this.BaseCategories.ToList();
            var labes = this.MetaLabels.ToList();

            foreach (var category in categories)
            {
                category.MetaLabel = labes.Single(x => string.Equals(x.Name, category.Name, StringComparison.OrdinalIgnoreCase));
            }

            SaveChanges();
        }

        private void SetUpSubCategories()
        {
            var subCategories = this.SubCategories.ToList();
            var categories = this.BaseCategories.ToList();
            var labes = this.MetaLabels.ToList();

            foreach (var subCategory in subCategories)
            {
                switch (subCategory.Name)
                {
                    case EfBaseModelConstans.SubCategoryRuMagnit:
                    case EfBaseModelConstans.SubCategoryRu5ka:
                        subCategory.MetaLabel = labes.Single(x => string.Equals(x.Name, MetaLabelType.EAT.GetDescription()));
                        subCategory.BaseCategory = categories.Single(x => string.Equals(x.Name, MetaLabelType.EAT.GetDescription()));
                        break;
                    case EfBaseModelConstans.SubCategoryRuOzon:
                    case EfBaseModelConstans.SubCategoryRuWildberries:
                        subCategory.MetaLabel = labes.Single(x => string.Equals(x.Name, MetaLabelType.PURCHASES.GetDescription()));
                        subCategory.BaseCategory = categories.Single(x => string.Equals(x.Name, MetaLabelType.PURCHASES.GetDescription()));
                        break;
                    case EfBaseModelConstans.SubCategoryRuUnderground:
                    case EfBaseModelConstans.SubCategoryRuTrain:
                        subCategory.MetaLabel = labes.Single(x => string.Equals(x.Name, MetaLabelType.TRANSPORT.GetDescription()));
                        subCategory.BaseCategory = categories.Single(x => string.Equals(x.Name, MetaLabelType.TRANSPORT.GetDescription()));
                        break;
                    case EfBaseModelConstans.SubCategoryRuKarting:
                        subCategory.MetaLabel = labes.Single(x => string.Equals(x.Name, MetaLabelType.RELAXATION.GetDescription()));
                        subCategory.BaseCategory = categories.Single(x => string.Equals(x.Name, MetaLabelType.RELAXATION.GetDescription()));
                        break;
                    default:
                        break;
                }
            }

            SaveChanges();
        }
    }
}
