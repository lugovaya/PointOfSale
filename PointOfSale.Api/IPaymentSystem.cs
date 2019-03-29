using PointOfSale.Api.Products;

namespace PointOfSale.Api
{
    /// <summary>
    /// Common API interface for price calculation of provided products
    /// </summary>
    /// <typeparam name="T">Derived from <see cref="Product"/></typeparam>
    public interface IPaymentSystem<T> where T : Product
    {
        /// <summary>
        /// Sets up pricing policy for the product
        /// </summary>
        void SetPricing(T product);

        /// <summary>
        /// Get the product by provided identifier
        /// </summary>
        T Scan(string id);

        /// <summary>
        /// Calculates the total cost of all products in a basket
        /// </summary>
        decimal CalculateTotal();
    }
}