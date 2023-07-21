using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Xunit.Core.Entities
{
    using ShopManagement.Core.Entities.ProductAgg;
    using Xunit;

    public class ProductEntityTests
    {
        [Fact]
        public void ProductEntity_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string name = "Sample Product";
            string code = "SP001";
            double unitPrice = 99.99;
            string shortDescription = "Short Description";
            string description = "Product Description";
            string picture = "product.jpg";
            string pictureAlt = "Product Image";
            string pictureTitle = "Product";
            long categoryId = 1;
            string slug = "sample-product";
            string keywords = "sample, product, test";
            string metaDescription = "Sample product for testing.";

            // Act
            var product = new ProductEntity(name, code, unitPrice, shortDescription, description, picture,
                pictureAlt, pictureTitle, categoryId, slug, keywords, metaDescription);

            // Assert
            Assert.Equal(name, product.Name);
            Assert.Equal(code, product.Code);
            Assert.Equal(unitPrice, product.UnitPrice);
            Assert.Equal(shortDescription, product.ShortDescription);
            Assert.Equal(description, product.Description);
            Assert.Equal(picture, product.Picture);
            Assert.Equal(pictureAlt, product.PictureAlt);
            Assert.Equal(pictureTitle, product.PictureTitle);
            Assert.Equal(categoryId, product.CategoryId);
            Assert.Equal(slug, product.Slug);
            Assert.Equal(keywords, product.Keywords);
            Assert.Equal(metaDescription, product.MetaDescription);
            Assert.True(product.IsStock); // Default value should be true
            Assert.False(product.IsRemove); // Default value should be false
        }

        [Fact]
        public void Edit_ShouldUpdateProperties()
        {
            // Arrange
            var product = new ProductEntity("Old Name", "OLD", 50.00, "Old Short Desc", "Old Desc", "old.jpg",
                "Old Alt", "Old Title", 1, "old-product", "old,test", "Old Meta");

            // Act
            product.Edit("New Name", "NEW", 75.00, "New Short Desc", "New Desc", "new.jpg",
                "New Alt", "New Title", 2, "new-product", "new,test", "New Meta");

            // Assert
            Assert.Equal("New Name", product.Name);
            Assert.Equal("NEW", product.Code);
            Assert.Equal(75.00, product.UnitPrice);
            Assert.Equal("New Short Desc", product.ShortDescription);
            Assert.Equal("New Desc", product.Description);
            Assert.Equal("new.jpg", product.Picture);
            Assert.Equal("New Alt", product.PictureAlt);
            Assert.Equal("New Title", product.PictureTitle);
            Assert.Equal(2, product.CategoryId);
            Assert.Equal("new-product", product.Slug);
            Assert.Equal("new,test", product.Keywords);
            Assert.Equal("New Meta", product.MetaDescription);
        }

        [Fact]
        public void ChangeStock_ShouldUpdateStockStatus()
        {
            // Arrange
            var product = new ProductEntity("Sample Product", "SP001", 99.99, "Short Desc", "Desc", "product.jpg",
                "Alt", "Title", 1, "sample-product", "sample,test", "Meta");

            // Act
            product.ChangeStock(false);

            // Assert
            Assert.False(product.IsStock);
        }

        [Fact]
        public void SetRemove_ShouldSetIsRemoveToTrue()
        {
            // Arrange
            var product = new ProductEntity("Sample Product", "SP001", 99.99, "Short Desc", "Desc", "product.jpg",
                "Alt", "Title", 1, "sample-product", "sample,test", "Meta");

            // Act
            var result = product.SetRemove();

            // Assert
            Assert.True(product.IsRemove);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void SetUnRemove_ShouldSetIsRemoveToFalse()
        {
            // Arrange
            var product = new ProductEntity("Sample Product", "SP001", 99.99, "Short Desc", "Desc", "product.jpg",
                "Alt", "Title", 1, "sample-product", "sample,test", "Meta");
            product.SetRemove(); // Ensure IsRemove is initially true

            // Act
            var result = product.SetUnRemove();

            // Assert
            Assert.False(product.IsRemove);
            Assert.True(result.IsSuccess);
        }
    }

}
