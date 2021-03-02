namespace PointOfScale.Domain.Core.Entities
{
    public class Product
    {
        public string Code { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal VolumePrice { get; set; }

        public int VolumeQuantity { get; set; }
    }
}
