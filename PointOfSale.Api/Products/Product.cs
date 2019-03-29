using System.ComponentModel.DataAnnotations;
using PointOfSale.Api.Validators;

namespace PointOfSale.Api.Products
{
    public class Product
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        [Required]
        public string Id { get; protected internal set; }
        
        /// <summary>
        /// The price of product unit
        /// </summary>
        [RequiredPositiveValue]
        public decimal Price { get; protected internal set; }
        
        /// <summary>
        /// Bought products count
        /// </summary>
        [RequiredPositiveValue] 
        public int Count { get; private set; }

        /// <summary>
        /// Increases the count when product is bought
        /// </summary>
        public virtual void Buy() => ++Count;

        /// <summary>
        /// Calculates the total cost of the product
        /// </summary>
        public virtual decimal Cost => Count * Price;
    }
}