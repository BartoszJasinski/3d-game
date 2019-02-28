using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Math = Game.Misc.Math;


namespace Game.Camera
{
    public class Camera
    {
    
        private Vector<double> initCameraPosition;
        private Vector<double> initCameraTarget;
        private Vector<double> upAxis;
        public Matrix<double> ViewMatrix { get; set; }
    
        public static Matrix<double> LookAt(Vector<double> cameraPosition, Vector<double> cameraTarget, Vector<double> upAxis)
        {
            Vector<double> direction = (cameraPosition - cameraTarget).Normalize(2);
//            direction.Normalize(2);
//            Vector<double> up = upAxis.Normalize(2);
            
            Vector<double> left = Misc.Math.CrossProduct(direction, upAxis).Normalize(2);
            Vector<double> up = Misc.Math.CrossProduct(left, direction);
            
//            Matrix<double> ViewMatrix = DenseMatrix.OfArray(new double[,] {
//                {right[0], right[1], right[2], 0},
//                {upAxis[0], upAxis[1], upAxis[2], 0},
//                {cameraTarget[0], cameraTarget[1], cameraTarget[2], 0},
//                {0, 0, 0, 1}}) * 
//                DenseMatrix.OfArray(new double[,] {
//                {1, 0, 0, - cameraPosition[0]},
//                {0, 1, 0, - cameraPosition[1]},
//                {0, 0, 1, - cameraPosition[2]},
//                {0, 0, 0, 1}});

//            Matrix<double> ViewMatrix = DenseMatrix.OfArray(new double[,]
//            {
////                -left[0] * cameraPosition[0] - left[1] * cameraPosition[1] - left[2] * cameraPosition[2]
//                {left[0], left[1], left[2], cameraPosition.DotProduct(left)},
//                {up[0], up[1], up[2], up.DotProduct(cameraPosition)},
//                {-direction[0], -direction[1], -direction[2], direction.DotProduct(cameraPosition)},
//                {0, 0, 0, 1}
//            });



            Vector<double> UpVector = upAxis.Normalize(2);
            Vector<double> zAxis = (cameraPosition - cameraTarget).Normalize(2);
            Vector<double> xAxis = Misc.Math.CrossProduct(UpVector, zAxis).Normalize(2);
            Vector<double> yAxis = Misc.Math.CrossProduct(zAxis, xAxis).Normalize(2);
            
            Matrix<double> ViewMatrix = DenseMatrix.OfArray(new double[,]
            {
                {xAxis[0], yAxis[0], zAxis[0], cameraPosition[0]},
                {xAxis[1], yAxis[1], zAxis[1], cameraPosition[1]},
                {xAxis[2], yAxis[2], zAxis[2], cameraPosition[2]},
                {0, 0, 0, 1}
            });

            ViewMatrix = ViewMatrix.Inverse();
            return ViewMatrix;

        }
    }
}