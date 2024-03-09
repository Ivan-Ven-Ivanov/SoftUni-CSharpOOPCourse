
using System.Text;

namespace _01.ClassBoxData.Models
{
    public class Box
    {
        private const string ArgumentExceptionMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length 
        {
            get => length;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessage, nameof(Length)));
                }

                length = value;
            } 
        }
        public double Width
        {
            get => width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessage, nameof(Width)));
                }

                width = value;
            }
        }
        public double Height
        {
            get => height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessage, nameof(Height)));
                }

                height = value;
            }
        }

        public double LateralSurfaceArea() => (2 * Length * Height) + (2 * Width * Height);

        public double SurfaceArea() => LateralSurfaceArea() + (2 * Length * Width);

        public double Volume() => Length * Width * Height;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Surface Area - {SurfaceArea():F2}");
            stringBuilder.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
            stringBuilder.AppendLine($"Volume - {Volume():F2}");
            
            return stringBuilder.ToString();
        }
    }
}
