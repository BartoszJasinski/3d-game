using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Math
{
    public class Vector
    {
        public int Count => vector.Count;
        public Vector<double> vector { get; set; }
        
        public double x
        {
            get => vector[0];
            set => vector[0] = value;
        }
        
        public double y
        {
            get => vector[1];
            set => vector[1] = value;
        }
        
        public double z
        {
            get => vector[2];
            set => vector[2] = value;
        }
        
        public double w
        {
            get => vector[3];
            set => vector[3] = value;
        }

        public Vector(): this(new DenseVector(new double[] { 0.0, 0.0, 0.0, 0.0 }))
        {
            
        }

        public Vector(double[] vectorElements) : this(DenseVector.OfArray(vectorElements))
        {
        }
            

        public Vector(double x, double y, double z): this(new DenseVector(new double[] {x, y, z, 1}))
        {
            
        }
        
        public Vector(double x, double y, double z, double w): this(new DenseVector(new double[] {x, y, z, w}))
        {
            
        }
        
        public Vector(Vector<double> vector)
        {
            this.vector = vector;
        }
        
        
        
        public double this[int i]
        {
            get => vector[i];
            set => vector[i] = value;
        }


        
        public Vector CrossProduct(Vector secondVector)
        {
//            if ((firstVector.Count != 3 || secondVector.Count != 3))
//            {
//                string message = "Vectors must have a length of 3.";
//                throw new Exception(message);
//            }
            
            Vector crossProduct = new DenseVector(3);
            crossProduct.x = y * secondVector.z - z * secondVector.y;
            crossProduct.y = -x * secondVector.z + z * secondVector.x;
            crossProduct.z = x * secondVector.y - y * secondVector.x;

            return crossProduct;
        }
        

        
        public Vector PointwiseMultiply(Vector secondVector)
        {
//            if (Count != secondVector.Count)
//                throw new ArgumentException("Vectors should have the same number of elements");

            Vector resultVector = new Vector();
            int resultVectorSize = System.Math.Min(Count, secondVector.Count);
            for (int i = 0; i < resultVectorSize; i++)
                resultVector[i] = vector[i] * secondVector[i];

            return resultVector;
        }
        public Vector  ReflectVector(Vector reflectionVector)
        {
            Vector resultVector = this - 2 * (this * reflectionVector) * reflectionVector;

            return resultVector;
        }
        
        //TODO: implement
        public Vector ResizeVectorToLength(int lengthOfNewVector)
        {
            double[] resultVectorElements = new double[lengthOfNewVector];
            for (int i = 0; i < lengthOfNewVector; i++)
                resultVectorElements[i] = vector[i];
            
            Vector<double> resultVec = new Vector(resultVectorElements);
            
            return resultVec;
        }
        public static implicit operator Vector<double>(Vector vector)
        {
            return vector.vector;
        }
             
        public static implicit operator Vector(Vector<double> vector)
        {
            return new Vector(vector);
        }
        
        
        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            return firstVector.vector - secondVector.vector;
        }
        
        public static Vector operator *(double multipliedNumber, Vector secondVector)
        {
            return multipliedNumber * secondVector.vector;
        }

        public static double operator *(Vector firstVector, Vector secondVector)
        {
            return firstVector.vector * secondVector.vector;
        }
        
        public Vector Normalize(double dimension)
        {
            return new Vector(vector.Normalize(dimension));
        }
        
        public Vector Add(Vector secondVector)
        {
            return new Vector(vector.Add(secondVector));
        }

        public double DotProduct(Vector secondVector)
        {
            return vector.DotProduct(secondVector);
        }
    }
}