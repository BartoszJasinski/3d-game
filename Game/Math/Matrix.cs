using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Math
{
    //TODO: Implement and refactor all occurrences of Matrix<double> → Game.Math.Matrix
    public class Matrix
    {
        public Matrix<double> matrix { get; set; }
        
//        public double x
//        {
//            get => vector[0];
//            set => vector[0] = value;
//        }
//        
//        public double y
//        {
//            get => vector[1];
//            set => vector[1] = value;
//        }
//        
//        public double z
//        {
//            get => vector[2];
//            set => vector[2] = value;
//        }
//        
//        public double w
//        {
//            get => vector[3];
//            set => vector[3] = value;
//        }
//
//        public Matrix(): this(new DenseVector(new double[] { 0.0, 0.0, 0.0, 0.0 }))
//        {
//            
//        }
//        
//        public Vector(double x, double y, double z): this(new DenseVector(new double[] {x, y, z}))
//        {
//            
//        }
//        
//        public Vector(double x, double y, double z, double w): this(new DenseVector(new double[] {x, y, z, w}))
//        {
//            
//        }
//        
//        public Vector(Vector<double> vector)
//        {
//            this.vector = vector;
//        }
//        
//        
//        
//        public double this[int i]
//        {
//            get => vector[i];
//            set => vector[i] = value;
//        }
//
//        public static implicit operator Vector<double>(Vector vector)
//        {
//            return vector.vector;
//        }
//     
//        public static implicit operator Vector(Vector<double> vector)
//        {
//            return new Vector(vector);
//        }
//        
//        
//        public static Vector operator -(Vector firstVector, Vector secondVector)
//        {
//            return firstVector.vector - secondVector.vector;
//        }
//
//        public Vector Normalize(double dimension)
//        {
//            return new Vector(vector.Normalize(dimension));
//        }
//        
//        public Vector CrossProduct(Vector secondVector)
//        {
////            if ((firstVector.Count != 3 || secondVector.Count != 3))
////            {
////                string message = "Vectors must have a length of 3.";
////                throw new Exception(message);
////            }
//            
//            Vector crossProduct = new DenseVector(3);
//            crossProduct[0] = y * secondVector.z - z * secondVector.y;
//            crossProduct[1] = -x * secondVector.z + z * secondVector.x;
//            crossProduct[2] = x * secondVector.y - y * secondVector.x;
//
//            return crossProduct;
//        }
//        
//        //TODO: implement
//        public Vector DropLastValue(Vector<double> vector)
//        {
//            Vector<double> resultVec = vector;
//            return resultVec;
//        }
    }
}