namespace PointOfScale.Domain.Core.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal CalculatePrice()
        {
            if (Product.VolumeQuantity != 0)
            {
                return Quantity / Product.VolumeQuantity * Product.VolumePrice
                + Quantity % Product.VolumeQuantity * Product.RetailPrice;
            }
            else
            {
                return Product.RetailPrice * Quantity;
            }
        }
    }
}
