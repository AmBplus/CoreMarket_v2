using Microsoft.EntityFrameworkCore;
using ShopManagement.Core.Data;
using ShopManagement.Core.Entities.ProductAgg;
using ShopManagement.Core.Entities.ProductCategoryAgg;
using ShopManagement.Core.Entities.ProductPictureAgg;
using ShopManagement.Core.Entities.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Data
{
    public class ShopManagementEfCoreContext : DbContext, Core.Data.IShopManagementEfCoreContext
    {
        public DbSet<ProductEntity> ProductEntities { get ; set  ; }
        public DbSet<ProductCategoryEntity> ProductCategoryEntities { get  ; set  ; }
        public DbSet<ProductPictureEntity> ProductPictureEntities { get  ; set  ; }
        public DbSet<SlideEntity> SlideEntities { get  ; set  ; }
    }
}
