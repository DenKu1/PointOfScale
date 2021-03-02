using System;

namespace PointOfScale.Presentation.Exceptions
{
    public class PointOfScaleException : Exception
    {
        public PointOfScaleException() : base()
        {
        }

        public PointOfScaleException(string message) : base(message)
        {
        }
    }
}