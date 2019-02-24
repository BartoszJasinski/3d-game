using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Math = Game.Misc.Math;

namespace Game.Lightning
{
    public class Color
    {
        public Vector<double> rgb { get; set; }
        public double R => rgb[0];
        public double G => rgb[1];
        public double B => rgb[2];


        // 
        /// <summary>
        /// This function accepts ints in range (0, 255)
        /// </summary>
        public Color(int r, int g, int b)
        {
            const int oldMinColorValue = 0, oldMaxColorValue = 255;
            const double newMinColorValue = 0.0, newMaxColorValue = 1.0;

            if (r < oldMinColorValue || r > oldMaxColorValue || g < oldMinColorValue || g > oldMaxColorValue ||
                b < oldMinColorValue || b > oldMaxColorValue)
                throw new Exception("RGB should be in range (0, 255)");
            
            rgb = DenseVector.OfArray(ConvertRGBToRange(r, g, b, oldMinColorValue, oldMaxColorValue, newMinColorValue,newMaxColorValue));
        }
        
        // 
        /// <summary>
        /// This function accepts doubles in range (0.0, 1.0)
        /// </summary>
        public Color(double r, double g, double b)
        {
            const double minColorValue = 0.0, maxColorValue = 1.0;

            if (r < minColorValue || r > maxColorValue || g < minColorValue || g > maxColorValue || b < minColorValue ||
                b > maxColorValue)
                throw new Exception("RGB should be in range (0.0, 1.0)");
            rgb = DenseVector.OfArray(new double[] { r, g, b });
        }
        
        public Color(Vector<double> rgb)
        {
            this.rgb = rgb ;
        }

        private double[] ConvertRGBToRange(Vector<double> rgb, double oldMin, double oldMax, double newMin,
            double newMax)
        {
            return ConvertRGBToRange(rgb[0], rgb[1], rgb[2], oldMin, oldMax, newMin, newMax);
        }
        private double[] ConvertRGBToRange(double r, double g, double b, double oldMin, double oldMax, double newMin,
            double newMax)
        {
            return new double[]
            {
                Misc.Math.ConvertToRange(r, oldMin, oldMax, newMin, newMax),
                Misc.Math.ConvertToRange(g, oldMin, oldMax, newMin, newMax),
                Misc.Math.ConvertToRange(b, oldMin, oldMax, newMin, newMax)
            };
        }

        public System.Drawing.Color ToSystemColor()
        {
            const double oldMinimalColorValue = 0.0, oldMaximalColorValue = 1.0;
            const int newMinimalColorValue = 0, newMaximalColorValue = 255;
            double[] rgb = ConvertRGBToRange(this.rgb, oldMinimalColorValue, oldMaximalColorValue, newMinimalColorValue,
                newMaximalColorValue);
           
            return System.Drawing.Color.FromArgb((int)rgb[0], (int)rgb[1], (int)rgb[2]);
        }
        
    }
}