using PointOfSale.Api.Products;

namespace PointOfSale.Api
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

    public class UnitPricing : PricingPolicy
    {
        public UnitPricing(Product product) : base(product)
        {
        }
    }
    
    public class VolumePricing : PricingPolicy
    {
        public VolumePricing(VolumeProduct product) : base(product)
        {
        }
    }
}