using System.ComponentModel.DataAnnotations;
using PointOfSale.Api.Validators;

namespace PointOfSale.Api.Products
{
    public class VolumeProduct : Product
    {
        [Range(1, int.MaxValue)]
        public int Volume { private get; set; }
        
        [RequiredPositiveValue]
        public decimal VolumePrice { private get; set; }

        public override decimal Cost
        {
            get
            {
                var discountTimes = Count / Volume;
                var reminder = Count % Volume;
                return discountTimes * VolumePrice + reminder * Price;
            }
        }
    }
}