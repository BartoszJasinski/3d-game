using System.Collections.Generic;
using static System.Math;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

using Game.Lightning;
using Vector = Game.Math.Vector;


namespace Game.Figure
{
    public class Model
    {
        public List<Triangle> triangles { get; set; }
        
        public Matrix<double> modelMatrix { get; set; } = DenseMatrix.OfArray(new double[,]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        });

        public Color color { get; set; }
        
        public Matrix<double> Scale(Vector scalingVector)
        {
            Matrix<double> scalingMatrix = DenseMatrix.OfArray(new double[,]
            {
                {scalingVector.x, 0, 0, 0},
                {0, scalingVector.y, 0, 0},
                {0, 0, scalingVector.z, 0},
                {0, 0, 0, 1}
            });

            return scalingMatrix;
        }
        
//        public Matrix<double> Scale(Matrix<double> modelMatrix, Vector<double> scalingVector)
//        {
//            Matrix<double> scalingMatrix = DenseMatrix.OfArray(new double[,]
//            {
//                {scalingVector[0], 0, 0, 0},
//                {0, scalingVector[1], 0, 0},
//                {0, 0, scalingVector[2], 0},
//                {0, 0, 0, 1}
//            });
//
//            Matrix<double> scaledmatrix = modelMatrix * scalingMatrix;
//            return scaledmatrix;
//        }

        public Matrix<double> Rotate(Vector rotationVector, double rotationAngle)
        {
            double rotCos = Cos(rotationAngle), rotSin = Sin(rotationAngle);
            double Rx = rotationVector[0], Ry = rotationVector[1], Rz = rotationVector[2];
            double RxRy = Rx * Ry, RxRz = Rx * Rz, RyRx = Ry * Rx, RyRz = Ry * Rz, RzRx = Rz * Rx, RzRy = Rz * Ry;
            
            Matrix<double> rotationMatrix = DenseMatrix.OfArray(new double[,]
            {
                {rotCos + Pow(Rx, 2) * (1 - rotCos), RxRy * (1 - rotCos) - Rz * rotSin, RxRz * (1 - rotCos) + Ry * rotSin, 0},
                {RyRx * (1 - rotCos) + Rz * rotSin, rotCos + Pow(Ry, 2) * (1 - rotCos), RyRz * (1 - rotCos) - Rx * rotSin, 0},
                {RzRx * (1 - rotCos) - Ry * rotSin, RzRy * (1 - rotCos) + Rx * rotSin, rotCos + Pow(Rz, 2) * (1 - rotCos), 0},
                {0, 0, 0, 1}
            });

            return rotationMatrix;
        }
        
//        public Matrix<double> Rotate(Matrix<double> modelMatrix, Vector<double> rotationVector, double rotationAngle)
//        {
//            double rotCos = Cos(rotationAngle), rotSin = Sin(rotationAngle);
//            double Rx = rotationVector[0], Ry = rotationVector[1], Rz = rotationVector[2];
//            double RxRy = Rx * Ry, RxRz = Rx * Rz, RyRx = Ry * Rx, RyRz = Ry * Rz, RzRx = Rz * Rx, RzRy = Rz * Ry;
//            
//            Matrix<double> rotationMatrix = DenseMatrix.OfArray(new double[,]
//            {
//                {rotCos + Pow(Rx, 2) * (1 - rotCos), RxRy * (1 - rotCos) - Rz * rotSin, RxRz * (1 - rotCos) + Ry * rotSin, 0},
//                {RyRx * (1 - rotCos) + Rz * rotSin, rotCos + Pow(Ry, 2) * (1 - rotCos), RyRz * (1 - rotCos) - Rx * rotSin, 0},
//                {RzRx * (1 - rotCos) - Ry * rotSin, RzRy * (1 - rotCos) + Rx * rotSin, rotCos + Pow(Rz, 2) * (1 - rotCos), 0},
//                {0, 0, 0, 1}
//            });
//            
//            Matrix<double> rotatedMatrix = modelMatrix * rotationMatrix;
//            return rotationMatrix;
//        }
        
        public Matrix<double> Translate(Vector translationVector)
        {
            Matrix<double> translationMatrix = DenseMatrix.OfArray(new double[,]
            {
                {1, 0, 0, translationVector[0]},
                {0,1,0,translationVector[1]},
                {0,0,1,translationVector[2]},
                {0,0,0,1}
            });

            return translationMatrix;
        }
        
//        public Matrix<double> Translate(Matrix<double> modelMatrix, Vector<double> translationVector)
//        {
//            Matrix<double> translationMatrix = DenseMatrix.OfArray(new double[,]
//            {
//                {1, 0, 0, translationVector[0]},
//                {0,1,0,translationVector[1]},
//                {0,0,1,translationVector[2]},
//                {0,0,0,1}
//            });
//            
//            Matrix<double> translatedModelMatrix = modelMatrix * translationMatrix;
//            return translatedModelMatrix;
//        }

        public Matrix<double> Transform(Vector scaleVector, Vector rotationVector, 
            double rotationAngle, Vector translationVector)
        {
            
            
            return modelMatrix = Translate(translationVector) * Rotate(rotationVector, rotationAngle) *
                                 Scale(scaleVector);
            
        }
    }
}