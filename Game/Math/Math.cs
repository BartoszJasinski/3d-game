using static System.Math;

namespace Game.Math
{
    public static class Math
    {

        public static double ConvertToRange(double oldValue, double oldMin, double oldMax, double newMin, double newMax)
        {
            var oldRange = oldMax - oldMin;
            var newRange = newMax - newMin;
            var newValue = (((oldValue - oldMin) * newRange) / oldRange) + newMin;
            return newValue;
        }
        
        public static double ConvertDegreesToRadians(double degrees)
        {
            return degrees * (PI / 180);
        }

        
        
    }
}