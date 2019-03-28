using System.Collections.Generic;
using System.Linq;
using PointOfSale.Api.Exceptions;
using PointOfSale.Api.Products;

namespace PointOfSale.Api
{
    public class PointOfSaleTerminal : IPaymentSystem<Product>
    {
        private readonly IList<Product> _productsBasket = new List<Product>();
        
        public void SetPricing(Product product)
        {
            _productsBasket.Add(product);
        }

        public Product Scan(string id)
        {
            var product = _productsBasket.FirstOrDefault(p => p.Id == id) ?? throw new ProductNotFoundException();
            
            product.Buy();

            return product;
        }

        public decimal CalculateTotal()
        {
            return _productsBasket.Sum(p => p.Cost);
        }
    }
}