using System.ComponentModel.DataAnnotations;
using PointOfSale.Api.Validators;

namespace PointOfSale.Api.Products
{
    public class VolumeProduct : Product
    {
        /// <summary>
        /// The count of product units to what volume price will be applied
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Volume { get; protected internal set; }
        
        /// <summary>
        /// The price of products volume
        /// </summary>
        [RequiredPositiveValue]
        public decimal VolumePrice { get; protected internal set; }

        /// <inheritdoc />
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