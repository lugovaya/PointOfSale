using PointOfSale.Api.Products;

namespace PointOfSale.Api
{
    public static class SellerClient
    {
        public static Product CreateProduct(string id, decimal price)
        {
            return new Product
            {
                Id = id,
                Price = price
            };
        }

        public static Product CreateProduct(string id, decimal price, int volume, decimal volumePrice)
        {
            return new VolumeProduct
            {
                Id = id,
                Price = price,
                Volume = volume,
                VolumePrice = volumePrice
            };
        }
    }
}