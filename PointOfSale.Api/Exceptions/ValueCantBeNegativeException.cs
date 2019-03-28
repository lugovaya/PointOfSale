using System;

namespace PointOfSale.Api.Exceptions
{
    public class ValueCantBeNegativeException : ArgumentException
    {
        public ValueCantBeNegativeException(string paramName) : base("Value can't be negative", paramName)
        {
            
        }
    }
}