using Base.Core;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Core.Entities.ProductAgg;
using ShopManagement.Core.Entities.ProductCategoryAgg;
using ShopManagement.Core.Entities.ProductPictureAgg;
using ShopManagement.Core.Entities.SlideAgg;

namespace ShopManagement.Core.Data
{
    public interface IShopManagementEfCoreContext : IEfDbContext
    {
        public DbSet<ProductEntity> ProductEntities { get; set; }   
        public DbSet<ProductCategoryEntity> ProductCategoryEntities { get; set; }   
        public DbSet<ProductPictureEntity> ProductPictureEntities { get; set; }   
        public DbSet<SlideEntity> SlideEntities { get; set; }   
    }
}
