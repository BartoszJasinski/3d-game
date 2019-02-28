using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Misc
{
    public class Math
    {
        public static Vector CrossProduct(Vector<double> firstVector, Vector<double> secondVector)
        {
//            if ((firstVector.Count != 3 || secondVector.Count != 3))
//            {
//                string message = "Vectors must have a length of 3.";
//                throw new Exception(message);
//            }
            
            Vector crossProduct = new DenseVector(3);
            crossProduct[0] = firstVector[1] * secondVector[2] - firstVector[2] * secondVector[1];
            crossProduct[1] = -firstVector[0] * secondVector[2] + firstVector[2] * secondVector[0];
            crossProduct[2] = firstVector[0] * secondVector[1] - firstVector[1] * secondVector[0];

            return crossProduct;
        }

        public static double ConvertToRange(double oldValue, double oldMin, double oldMax, double newMin, double newMax)
        {
            double oldRange = oldMax - oldMin;
            double newRange = newMax - newMin;
            double newValue = (((oldValue - oldMin) * newRange) / oldRange) + newMin;
            return newValue;
        }

        public static Vector<double> PointwiseMultiply(Vector<double> firstVector, Vector<double> secondVector)
        {
            if (firstVector.Count != secondVector.Count)
                throw new Exception("Vectors should have the same number of elements");

            Vector<double> resultVector = Vector<double>.Build.Dense(firstVector.Count);

            for (int i = 0; i < firstVector.Count; i++)
                resultVector[i] = firstVector[i] * secondVector[i];

            return resultVector;
        }
        
        
    }
}