using System.Collections.Generic;
using System.Linq;
using PointOfSale.Api.Exceptions;
using PointOfSale.Api.Products;

namespace PointOfSale.Api
{
    /// <inheritdoc />
    /// <summary>
    /// Implements the logic in terms of PointOfSaleTerminal 
    /// </summary>
    public class PointOfSaleTerminal : IPaymentSystem<Product>
    {
        private readonly IList<Product> _productsBasket = new List<Product>();
        
        /// <inheritdoc />
        public void SetPricing(Product product)
        {
            _productsBasket.Add(product);
        }

        /// <inheritdoc />
        public Product Scan(string id)
        {
            var product = _productsBasket.FirstOrDefault(p => p.Id == id) ?? throw new ProductNotFoundException();
            
            product.Buy();

            return product;
        }

        /// <inheritdoc />
        public decimal CalculateTotal()
        {
            return _productsBasket.Sum(p => p.Cost);
        }
    }
}