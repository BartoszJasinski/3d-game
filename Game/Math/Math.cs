using static System.Math;

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
            return degrees * (PI / 180);
        }

        
        
    }
}