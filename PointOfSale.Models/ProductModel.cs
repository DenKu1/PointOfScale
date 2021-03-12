namespace PointOfSale.Models
{
    public class ProductModel
    {
        public string Code { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal VolumePrice { get; set; }

        public int VolumeQuantity { get; set; }
    }
}
