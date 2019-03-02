using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Math
{
    public class Matrix
    {

        public Matrix<double> matrix { get; set; }
        
        public Matrix(double[,] matrixElements)
        {
            matrix = DenseMatrix.OfArray(matrixElements);
        }

        private Matrix(Matrix<double> matrix)
        {
            this.matrix = matrix;
        }

        public static implicit operator Matrix<double>(Matrix matrix)
        {
            return matrix.matrix;
        }
     
        public static implicit operator Matrix(Matrix<double> matrix)
        {
            return new Matrix(matrix);
        }

        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            return firstMatrix.matrix * secondMatrix.matrix;
        }
        
        public static Vector operator *(Matrix matrix, Vector vector)
        {
            return matrix.matrix * vector.vector;
        }
        
        public Matrix Inverse()
        {
            return new Matrix(matrix.Inverse());
        }
    }
}