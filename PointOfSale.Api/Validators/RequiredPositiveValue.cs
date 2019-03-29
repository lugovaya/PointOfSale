using System.ComponentModel.DataAnnotations;
using PointOfSale.Api.Exceptions;

namespace PointOfSale.Api.Validators
{
    /// <inheritdoc />
    /// <summary>
    /// Checks that provided value is positive,
    /// otherwise - throws <exception cref="T:PointOfSale.Api.Exceptions.ValueCantBeNegativeException">ValueCantBeNegativeException</exception>
    /// </summary>
    public class RequiredPositiveValue : RangeAttribute
    {
        public RequiredPositiveValue() : base(0, double.MaxValue)
        {
        }

        public override bool IsValid(object value)
        {
            if (!base.IsValid(value))
                throw new ValueCantBeNegativeException(nameof(value));

            return true;
        }
    }
}