using System;
using System.ComponentModel.DataAnnotations;
using PointOfSale.Api.Exceptions;

namespace PointOfSale.Api.Validators
{
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