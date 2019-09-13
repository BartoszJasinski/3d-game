using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using static System.Math;


namespace Game.Math
{
    public class Vector
    {
        public int count => vector.Count;
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

        public double this[int i]
        {
            get => vector[i];
            set => vector[i] = value;
        }

        public Vector() : this(new DenseVector(new double[] {0.0, 0.0, 0.0, 0.0}))
        {
        }

        public Vector(double[] vectorElements) : this(DenseVector.OfArray(vectorElements))
        {
        }


        public Vector(double x, double y, double z) : this(new DenseVector(new[] {x, y, z}))
        {
        }

        public Vector(double x, double y, double z, double w) : this(new DenseVector(new[] {x, y, z, w}))
        {
        }

        public Vector(Vector<double> vector)
        {
            this.vector = vector;
        }

        public Vector CrossProduct(Vector secondVector)
        {
            const int numberOfElementsIn3DVector = 3;
            if ((count != numberOfElementsIn3DVector || secondVector.count != numberOfElementsIn3DVector))
            {
                const string message = "Vectors must have a length of 3";
                throw new ArgumentException(message);
            }

            var xCoordinate = y * secondVector.z - z * secondVector.y;
            var yCoordinate = z * secondVector.x - x * secondVector.z;
            var zCoordinate = x * secondVector.y - y * secondVector.x;

            var crossProduct = new Vector(xCoordinate, yCoordinate, zCoordinate);

            return crossProduct;
        }

        public Vector PointwiseMultiply(Vector secondVector)
        {
            if (count != secondVector.count)
            {
                throw new ArgumentException("Vectors should have the same number of elements");
            }

            var resultVectorSize = Min(count, secondVector.count);
            var resultVectorElementsArray = new double[resultVectorSize];
            var resultVector = new Vector(0, 0, 0);

            for (var i = 0; i < resultVectorSize; i++)
                resultVector[i] = vector[i] * secondVector[i];


            return resultVector;
        }

        public Vector ReflectVector(Vector reflectionVector)
        {
            var resultVector = this - 2 * (this * reflectionVector) * reflectionVector;

            return resultVector;
        }

        public Vector ResizeVectorToLength(int lengthOfNewVector)
        {
            double[] resultVectorElements = new double[lengthOfNewVector];
            for (int i = 0; i < lengthOfNewVector; i++)
                resultVectorElements[i] = vector[i];

            Vector<double> resultVec = new Vector(resultVectorElements);

            return resultVec;
        }

        public Vector CastVectorTo3D()
        {
            const int numberOfElementsIn3DVector = 3;

            return ResizeVectorToLength(numberOfElementsIn3DVector);
        }

        public Vector Cast3DVectorTo4D(double w = 1)
        {
            if (vector.Count != 3)
                throw new ArgumentException("Vector is not 3D vector");

            return new Vector(x, y, z, w);
        }

        public static implicit operator Vector<double>(Vector vector)
        {
            return vector.vector;
        }

        public static implicit operator Vector(Vector<double> vector)
        {
            return new Vector(vector);
        }

        public static Vector operator +(Vector firstVector, Vector secondVector)
        {
            return firstVector.vector + secondVector.vector;
        }


        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            return firstVector.vector - secondVector.vector;
        }

        public static Vector operator -(Vector vector)
        {
            return new Vector(-vector.vector);
        }

        public static Vector operator *(double multipliedNumber, Vector secondVector)
        {
            return multipliedNumber * secondVector.vector;
        }


        public static Vector operator *(Vector secondVector, double multipliedNumber)
        {
            return secondVector.vector * multipliedNumber;
        }

        public static double operator *(Vector firstVector, Vector secondVector)
        {
            return firstVector.vector * secondVector.vector;
        }

        public static bool operator ==(Vector firstVector, Vector secondVector)
        {
            if (firstVector.count != secondVector.count)
            {
                throw new ArgumentException("Vectors have different dimensions");
            }

            return (Abs(firstVector.x - secondVector.x) < 0.0000001 &&
                    Abs(firstVector.y - secondVector.y) < 0.0000001 &&
                    Abs(firstVector.z - secondVector.z) < 0.0000001);

        }

        public static bool operator !=(Vector firstVector, Vector secondVector)
        {
            return !(firstVector == secondVector);
        }


        public Vector Normalize(double dimension = 2)
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

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
    }
}