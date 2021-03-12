using System;

namespace PointOfSale.Presentation.Exceptions
{
    public class PointOfSaleException : Exception
    {
        public PointOfSaleException() : base()
        {
        }

        public PointOfSaleException(string message) : base(message)
        {
        }
    }
}