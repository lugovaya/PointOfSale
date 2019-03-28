using System.ComponentModel.DataAnnotations;
using PointOfSale.Api.Validators;

namespace PointOfSale.Api.Products
{
    public class Product
    {
        [Required]
        protected internal string Id { get; set; }
        
        [RequiredPositiveValue]
        protected internal decimal Price { get; set; }
        
        [RequiredPositiveValue] protected int Count { get; private set; }

        public virtual void Buy() => ++Count;

        public virtual decimal Cost => Count * Price;
    }
}