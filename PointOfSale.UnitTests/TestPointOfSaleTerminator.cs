using PointOfSale.Api;
using PointOfSale.Api.Products;
using Xunit;

namespace PointOfSale.UnitTests
{
    public class TestPointOfSaleTerminator
    {
        private IPaymentSystem<Product> _terminal;
        
        [Fact]
        public void CanScanProduct()
        {
            // Assert
            _terminal = new PointOfSaleTerminal();
            var product = SellerClient.CreateProduct("A", 1.25m, 3, 3m);
            
            // Act
            _terminal.SetPricing(product);
            var returnedProduct = _terminal.Scan("A");
            
            // Arrange
            Assert.NotNull(returnedProduct);
            Assert.Equal(1.25m, returnedProduct.Price);
        }
        
        [Fact]
        public void CanCalculateTotal()
        {
            // Assert
            _terminal = new PointOfSaleTerminal();
            
            SetUpPricing();
            
            // Act
            _terminal.Scan("A");
            _terminal.Scan("A");
            _terminal.Scan("A");
            _terminal.Scan("A");
            
            var result = _terminal.CalculateTotal();
            
            // Arrange
            Assert.Equal(4.25m, result);
        }
        
        [Fact]
        public void TestAbcdabaSequence()
        {
            // Assert
            _terminal = new PointOfSaleTerminal();
            
            SetUpPricing();
            
            // Act
            _terminal.Scan("A");
            _terminal.Scan("B");
            _terminal.Scan("C");
            _terminal.Scan("D");
            _terminal.Scan("A");
            _terminal.Scan("B");
            _terminal.Scan("A");
            
            var result = _terminal.CalculateTotal();
            
            // Arrange
            Assert.Equal(13.25m, result);
        }
        
        [Fact]
        public void TestCcccccSequence()
        {
            // Assert
            _terminal = new PointOfSaleTerminal();
            
            SetUpPricing();
            
            // Act
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");
            
            var result = _terminal.CalculateTotal();
            
            // Arrange
            Assert.Equal(6m, result);
        }
        
        [Fact]
        public void TestAbcdSequence()
        {
            // Assert
            _terminal = new PointOfSaleTerminal();
            
            SetUpPricing();
            
            // Act
            _terminal.Scan("A");
            _terminal.Scan("B");
            _terminal.Scan("C");
            _terminal.Scan("D");
            
            var result = _terminal.CalculateTotal();
            
            // Arrange
            Assert.Equal(7.25m, result);
        }
        
        private void SetUpPricing()
        {
            _terminal.SetPricing(SellerClient.CreateProduct("A", 1.25m, 3, 3m));
            _terminal.SetPricing(SellerClient.CreateProduct("B", 4.25m));
            _terminal.SetPricing(SellerClient.CreateProduct("C", 1m, 6, 5m));
            _terminal.SetPricing(SellerClient.CreateProduct("D", 0.75m));
        }
    }
}