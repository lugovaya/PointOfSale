using System.ComponentModel.DataAnnotations;
using PointOfSale.Api.Validators;

namespace PointOfSale.Api.Products
{
    public class ProductItem : Product
    {
        public ProductItem(string id, decimal unitPrice) : this(id, unitPrice, 1, unitPrice)
        {
        }
        
        public ProductItem(string id, decimal unitPrice, int volume, decimal volumePrice)
        {
            Id = id;
            Price = unitPrice;
            Volume = volume;
            VolumePrice = volumePrice;
        }
        
        [Range(1, int.MaxValue)]
        protected internal  int Volume { get; }
        
        [RequiredPositiveValue]
        protected internal  decimal VolumePrice { get; }
    }
}