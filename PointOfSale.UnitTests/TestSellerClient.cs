using PointOfSale.Api;
using PointOfSale.Api.Products;
using Xunit;

namespace PointOfSale.UnitTests
{
    public class TestSellerClient
    {
        [Fact]
        public void CanCreateUnitProduct()
        {
            // Assert 
            Product product;
            
            // Act
            product = SellerClient.CreateProduct("A", 1.25m);
            var result = product is VolumeProduct;
            
            // Arrange
            Assert.False(result);
            Assert.NotNull(product);
            Assert.Equal(1.25m, product.Price);
        }
        
        [Fact]
        public void CanCreateVolumeProduct()
        {
            // Assert 
            Product product;
            
            // Act
            product = SellerClient.CreateProduct("A", 1.25m, 3, 3m);
            var result = product as VolumeProduct;
            
            // Arrange
            Assert.NotNull(result);
            Assert.Equal(3m, result.VolumePrice);
        }
        
        [Fact]
        public void CanBuyProduct()
        {
            // Assert 
            const int count = 10;
            var product = SellerClient.CreateProduct("A", 1.25m);
            
            // Act
            for (var i = 0; i < count; i++)
                product.Buy();
                        
            // Arrange
            Assert.NotNull(product);
            Assert.Equal(count, product.Count);
        }
        
        [Fact]
        public void CanCalculateTotal()
        {
            // Assert
            const int count = 10;
            var product = SellerClient.CreateProduct("A", 1.25m, 3, 3m);
            
            // Act
            for (var i = 0; i < count; i++)
                product.Buy();
            
            // Arrange
            Assert.NotNull(product);
            Assert.Equal(10.25m, product.Cost);
        }
    }
}