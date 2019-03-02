using System.Collections.Generic;

using Game.Math;

namespace Game.Camera
{
    
    
    public class Cameras
    {
        Matrix ViewMatrix(CameraMode cameraMode, Camera camera/*,  cameraPosition, cameraTarget,upAxis */)
        {
//            camera.cameraPosition = cameraPosition ?? new DenseVector(new[] {0.0, 0.0, 0.0});
//            camera.cameraTarget = cameraTarget ?? new DenseVector(new[] {0.0, 0.0, 0.0});
//            camera.upAxis = upAxis ?? new DenseVector(new[] {0.0, 0.0, 1.0});

            return camera.LookAt();

        }

        Dictionary<CameraMode, List<Vector>> CamerasList = new Dictionary<CameraMode, List<Vector>>
        {
            {CameraMode.StationaryCamera, new List<Vector> {new Vector(0.0, 0.0, 0.0), 
                new Vector(0.0, 0.0, 0.0),new Vector(0.0, 1.0, 0.0)}},
            
            {CameraMode.StationaryTrackingObjectCamera, new List<Vector>{new Vector(0.0, 0.0, 0.0), 
                new Vector(0.0, 0.0, 0.0),new Vector(0.0, 1.0, 0.0)}},

            {CameraMode.MovingAssociatedWithObjectCamera, new List<Vector> {new Vector(0.0, 0.0, 0.0), 
                new Vector(0.0, 0.0, 0.0),new Vector(0.0, 1.0, 0.0)}}
        };
    }
}