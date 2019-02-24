using System.Collections.Generic;
using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Camera
{
    
    
    public class Cameras
    {
        Matrix<double> ViewMatrix(CameraMode cameraMode, Vector<double> cameraPosition = null, Vector<double> cameraTarget = null, Vector<double> upAxis = null)
        {
            cameraPosition = cameraPosition ?? new DenseVector(new[] {0.0, 0.0, 0.0});
            cameraTarget = cameraTarget ?? new DenseVector(new[] {0.0, 0.0, 0.0});
            upAxis = upAxis ?? new DenseVector(new[] {0.0, 0.0, 1.0});

            return Camera.LookAt(cameraPosition, cameraTarget, upAxis);

        }

        
        
        Dictionary<CameraMode, List<DenseVector>> CamerasList = new Dictionary<CameraMode, List<DenseVector>>
        {
            {CameraMode.StationaryCamera, new List<DenseVector> {new DenseVector(new[] {0.0, 0.0, 0.0}), 
                new DenseVector(new[] {0.0, 0.0, 0.0}),new DenseVector(new[] {0.0, 1.0, 0.0})}},
            
            {CameraMode.StationaryTrackingObjectCamera, new List<DenseVector>{new DenseVector(new[] {0.0, 0.0, 0.0}), 
                new DenseVector(new[] {0.0, 0.0, 0.0}),new DenseVector(new[] {0.0, 1.0, 0.0})}},

            {CameraMode.MovingAssociatedWithObjectCamera, new List<DenseVector> {new DenseVector(new[] {0.0, 0.0, 0.0}), 
                new DenseVector(new[] {0.0, 0.0, 0.0}),new DenseVector(new[] {0.0, 1.0, 0.0})}}
        };
    }
}