using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MoneyManager.Core.DataBase.Configurations;
using MoneyManager.Core.DataBase.Models;
using MoneyManager.Core.DataBase.Models.Constants;
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
        public DbSet<EfEntityImage> EntityImages { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<AppDbConfig> config)
            : base(options)
        {
            if (config?.Value?.AllowForceRecreateBase ?? false)
                ForceRecreateBase();
        }

        /// <summary>
        /// Конструктор с возможность пересоздания базы
        /// </summary>
        /// <param name="options"></param>
        /// <param name="forceDeleteBase"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options, bool forceDeleteBase)
            : base(options)
        {
            if (forceDeleteBase)
                ForceRecreateBase();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EfBaseCategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new EfEntityImageConfiguration());
            modelBuilder.ApplyConfiguration(new EfMetaLabelsConfiguration());
            modelBuilder.ApplyConfiguration(new EfMoneyOperationsConfiguration());
            modelBuilder.ApplyConfiguration(new EfMoneySourcesConfiguration());
            modelBuilder.ApplyConfiguration(new EfMoneyStoragesConfiguration());
            modelBuilder.ApplyConfiguration(new EfRecordConfiguration());
            modelBuilder.ApplyConfiguration(new EfSubCategoriesConfiguration());
        }

        private void ForceRecreateBase()
        {
            // удаляем и создаем базу при каждом запуске приложения
            Database.EnsureDeleted();
            Database.EnsureCreated();
            // базовая настройка для чистой базы
            SetUpMoneyStorages();
            SetUpBaseCategories();
            SetUpSubCategories();

            this.Records.Add(new()
            {
                Id = 1,
                Uuid = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Name = "Test record",
                OperationType = MoneyOperationType.NONE,
                Sum = 0,
                MoneyStorage = MoneyStorages.Single(x => x.Id == 1),
                BaseCategory = BaseCategories.Single(x => x.Id ==1)
            });

            this.EntityImages.Add(new()
            {
                Id = 1,
                Uuid = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Name = "Test image path",
                Path = "./"
            });

            SaveChanges();
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
                    case EfBaseModelConstants.SubCategoryRuMagnit:
                    case EfBaseModelConstants.SubCategoryRu5ka:
                        subCategory.MetaLabel = labes.Single(x => string.Equals(x.Name, MetaLabelType.EAT.GetDescription()));
                        subCategory.BaseCategory = categories.Single(x => string.Equals(x.Name, MetaLabelType.EAT.GetDescription()));
                        break;
                    case EfBaseModelConstants.SubCategoryRuOzon:
                    case EfBaseModelConstants.SubCategoryRuWildberries:
                        subCategory.MetaLabel = labes.Single(x => string.Equals(x.Name, MetaLabelType.PURCHASES.GetDescription()));
                        subCategory.BaseCategory = categories.Single(x => string.Equals(x.Name, MetaLabelType.PURCHASES.GetDescription()));
                        break;
                    case EfBaseModelConstants.SubCategoryRuUnderground:
                    case EfBaseModelConstants.SubCategoryRuTrain:
                        subCategory.MetaLabel = labes.Single(x => string.Equals(x.Name, MetaLabelType.TRANSPORT.GetDescription()));
                        subCategory.BaseCategory = categories.Single(x => string.Equals(x.Name, MetaLabelType.TRANSPORT.GetDescription()));
                        break;
                    case EfBaseModelConstants.SubCategoryRuKarting:
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
