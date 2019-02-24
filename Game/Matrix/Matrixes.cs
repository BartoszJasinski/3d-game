using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Matrix
{
    public class Matrixes
    {
//        public static Matrix<double> ViewMatrix = DenseMatrix.OfArray(new double[,] {
//            {0, 1, 0, -0.5},
//            {0, 0, 1, -0.5},
//            {1, 0, 0, -3},
//            {0, 0, 0, 1}});

//TODO you should probably move ProjectionMatrix to Camera class
        public static Matrix<double> ProjectionMatrix = DenseMatrix.OfArray(new double[,] {
            {2.414, 0, 0, 0},
            {0, 2.414, 0, 0},
            {0, 0, -1.02, -2.02},
            {0, 0, -1, 0}});

//        public static Matrix<double> ModelMatrix = DenseMatrix.OfArray(new double[,] {
//            {1, 0, 0, 0},
//            {0, 1, 0, 0},
//            {0, 0, 1, 0},
//            {0, 0, 0, 1}});
    }
}