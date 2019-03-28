using PointOfSale.Api.Products;

namespace PointOfSale.Api
{
    public interface IPaymentSystem<T> where T : Product
    {
        void SetPricing(T product);

        T Scan(string id);

        decimal CalculateTotal();
    }
}