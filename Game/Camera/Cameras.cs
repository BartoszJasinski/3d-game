using System.Collections.Generic;
using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Camera
{
    
    
    public class Cameras
    {
        Matrix<double> ViewMatrix(CameraMode cameraMode, Camera camera/*,  cameraPosition, cameraTarget,upAxis */)
        {
//            camera.cameraPosition = cameraPosition ?? new DenseVector(new[] {0.0, 0.0, 0.0});
//            camera.cameraTarget = cameraTarget ?? new DenseVector(new[] {0.0, 0.0, 0.0});
//            camera.upAxis = upAxis ?? new DenseVector(new[] {0.0, 0.0, 1.0});

            return camera.LookAt();

        }

        
        //TODO: refactor List<DeneseVector> → List<Game.Figure.Vector>
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