using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Math
{
    public class Math
    {

        public static double ConvertToRange(double oldValue, double oldMin, double oldMax, double newMin, double newMax)
        {
            double oldRange = oldMax - oldMin;
            double newRange = newMax - newMin;
            double newValue = (((oldValue - oldMin) * newRange) / oldRange) + newMin;
            return newValue;
        }
        
        public static double ConvertDegreesToRadians(double degrees)
        {
            return degrees * (System.Math.PI / 180);
        }

        
        
    }
}