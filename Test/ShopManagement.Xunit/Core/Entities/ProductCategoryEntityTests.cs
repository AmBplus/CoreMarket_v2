using ShopManagement.Core.Entities.ProductCategoryAgg;

using ShopManagement.Core.Entities.ProductAgg;

public class ProductCategoryFixture
{
    public static ProductCategoryEntity ValidCategory = new ProductCategoryEntity(
      "Test Name",
      "Test Description",
      "Test Picture",
      "Picture Alt",
      "Picture Title",
      "Test Keywords",
      "Test Meta",
      "test-slug");

    public static ProductEntity ExistingProduct = new ProductEntity(
      "Test Product",
      "CODE123",
      100,
      "ShortDesc",
      "LongDesc",
      "Image.png",
      "Alt",
      "Title",
      ValidCategory.Id,
      "test-product",
      "Keywords",
      "Meta");
}

[CollectionDefinition("Product category collection")]
public class ProductCategoryCollection : ICollectionFixture<ProductCategoryFixture> { }

[Collection("Product category collection")]
public class ProductCategoryTests
{
    private readonly ProductCategoryFixture ProductCategoryFixture;

    public ProductCategoryTests( )
    {
        
    }

    [Fact]
    public void Create_ShouldInitializeAllProperties()
    {
        // Assert
        Assert.Equal("Test Name", ProductCategoryFixture.ValidCategory.Name);
        Assert.Equal("Test Description", ProductCategoryFixture.ValidCategory.Description);
        Assert.Equal("Test Picture", ProductCategoryFixture.ValidCategory.Picture);
        Assert.Equal("Picture Alt", ProductCategoryFixture.ValidCategory.PictureAlt);
        Assert.Equal("Picture Title", ProductCategoryFixture.ValidCategory.PictureTitle);
        Assert.Equal("Test Keywords", ProductCategoryFixture.ValidCategory.Keywords);
        Assert.Equal("Test Meta", ProductCategoryFixture.ValidCategory.MetaDescription);
        Assert.Equal("test-slug", ProductCategoryFixture.ValidCategory.Slug);
    }

    [Fact]
    public void Edit_ShouldUpdateAllProperties()
    {
        // Arrange
        var category = ProductCategoryFixture.ValidCategory;

        // Act
        category.Edit(
          "New Name",
          "New Description",
          "New Picture",
          "New Alt",
          "New Title",
          "New Keywords",
          "New Meta",
          "new-slug");

        // Assert
        Assert.Equal("New Name", category.Name);
        Assert.Equal("New Description", category.Description);
        Assert.Equal("New Picture", category.Picture);
        Assert.Equal("New Alt", category.PictureAlt);
        Assert.Equal("New Title", category.PictureTitle);
        Assert.Equal("New Keywords", category.Keywords);
        Assert.Equal("New Meta", category.MetaDescription);
        Assert.Equal("new-slug", category.Slug);
    }

    [Fact]
    public void Remove_ShouldSetIsRemovedToTrue()
    {
        // Arrange
        var category = ProductCategoryFixture.ValidCategory;

        // Act
        category.Remove();

        // Assert
        Assert.True(category.IsRemoved);
    }

    [Fact]
    public void Restore_ShouldSetIsRemovedToFalse()
    {
        // Arrange 
        var category = ProductCategoryFixture.ValidCategory;
        category.Remove();

        // Act
        category.Restore();

        // Assert
        Assert.False(category.IsRemoved);
    }

    [Fact]
    public void AddProduct_ShouldIncreaseProductCount()
    {
        // Arrange
        var category = ProductCategoryFixture.ValidCategory;
        var initialCount = category.Products.Count;

        // Act
        category.Products.Add(ProductCategoryFixture.ExistingProduct);

        // Assert
        Assert.Equal(initialCount + 1, category.Products.Count);
    }

    [Fact]
    public void RemoveProduct_ShouldDecreaseProductCount()
    {
        // Arrange
        var category = ProductCategoryFixture.ValidCategory;
        category.Products.Add(ProductCategoryFixture.ExistingProduct);
        var initialCount = category.Products.Count;

        // Act
        category.Products.Remove(ProductCategoryFixture.ExistingProduct);

        // Assert
        Assert.Equal(initialCount - 1, category.Products.Count);
    }
}