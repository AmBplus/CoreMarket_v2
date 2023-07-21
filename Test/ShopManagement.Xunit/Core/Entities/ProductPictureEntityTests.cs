using ShopManagement.Core.Entities.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Xunit.Core.Entities
{
    using Xunit;
    using ShopManagement.Core.Entities.ProductPictureAgg;

    public class ProductPictureTests
    {
        [Fact]
        public void Create_WithValidParameters_ShouldInitializeProperties()
        {
            // Arrange
            var productId = 1;
            var picture = "test.jpg";
            var alt = "Test Alt";
            var title = "Test Title";

            // Act
            var productPicture = CreateProductPicture(productId, picture, alt, title);

            // Assert
            Assert.Equal(productId, productPicture.ProductId);
            Assert.Equal(picture, productPicture.Picture);
            Assert.Equal(alt, productPicture.PictureAlt);
            Assert.Equal(title, productPicture.PictureTitle);
            Assert.False(productPicture.IsRemoved);
        }

        [Fact]
        public void Edit_WithValidParameters_ShouldUpdateProperties()
        {
            // Arrange
            var productPicture = CreateProductPicture(1, "initial.jpg", null, null);
            var newPicture = "new.jpg";

            // Act
            productPicture.Edit(1, newPicture, "New Alt", "New Title");

            // Assert
            Assert.Equal(newPicture, productPicture.Picture);
            Assert.Equal("New Alt", productPicture.PictureAlt);
            Assert.Equal("New Title", productPicture.PictureTitle);
        }

        [Fact]
        public void Remove_ShouldSetIsRemovedToTrue()
        {
            // Arrange
            var productPicture = CreateProductPicture(1, "pic.jpg", null, null);

            // Act
            productPicture.Remove();

            // Assert
            Assert.True(productPicture.IsRemoved);
        }

        [Fact]
        public void Restore_ShouldSetIsRemovedToFalse()
        {
            // Arrange
            var productPicture = CreateProductPicture(1, "pic.jpg", null, null);
            productPicture.Remove();

            // Act
            productPicture.Restore();

            // Assert
            Assert.False(productPicture.IsRemoved);
        }

        private ProductPictureEntity CreateProductPicture(long productId, string picture, string alt, string title)
        {
            return new ProductPictureEntity(productId, picture, alt, title);
        }
    }
}
