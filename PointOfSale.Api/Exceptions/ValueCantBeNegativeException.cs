using System;

namespace PointOfSale.Api.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// Occurs when passed value is less than zero
    /// </summary>
    public class ValueCantBeNegativeException : ArgumentException
    {
        public ValueCantBeNegativeException(string paramName) : base("Value can't be negative", paramName)
        {
            
        }
    }
}