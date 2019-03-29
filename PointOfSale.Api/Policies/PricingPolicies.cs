using PointOfSale.Api.Products;

namespace PointOfSale.Api.Policies
{
    public abstract class PricingPolicy : Product
    {
        private readonly Product _product;

        protected PricingPolicy(Product product)
        {
            _product = product;
        }
        
        public override decimal Cost => _product.Cost;
    }

    /// <summary>
    /// Pricing policy for retail
    /// </summary>
    public class UnitPricing : PricingPolicy
    {
        public UnitPricing(Product product) : base(product)
        {
        }
    }
    
    /// <summary>
    /// Pricing policy for wholesale
    /// </summary>
    public class VolumePricing : PricingPolicy
    {
        public VolumePricing(Product product) : base(product)
        {
        }
    }
}