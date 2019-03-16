using System;
using System.Collections.Generic;

using Game.Math;

namespace Game.Camera
{
    
    //TODO: create way of choosing different cameras like (keyboard shortucts or smth else) and nice API to choose cameras 
    //TODO: fix displaying because, in StationaryCamera top of the cone is the highest point, and in StationaryTrackingModelCamera and MovingAssociated with object is the lowest point
    public class Cameras
    {
        Matrix ViewMatrix(CameraMode cameraMode, Camera camera/*,  cameraPosition, cameraTarget,upAxis */)
        {
//            camera.cameraPosition = cameraPosition ?? new DenseVector(new[] {0.0, 0.0, 0.0});
//            camera.cameraTarget = cameraTarget ?? new DenseVector(new[] {0.0, 0.0, 0.0});
//            camera.upAxis = upAxis ?? new DenseVector(new[] {0.0, 0.0, 1.0});

            return camera.LookAt();

        }

        public Matrix GetCamera(Camera camera)
        {
            return StationaryCamera(camera);
//            gameData.camera.viewMatrix = gameData.cameras.StationaryTrackingModelCamera(gameData.camera, model.translationVector);
//            Vector cameraOffset = new Vector(10, 0, 0);
//            gameData.camera.viewMatrix =
//                gameData.cameras.MovingAssociatedWithObjectCamera(gameData.camera, model.translationVector,
//                    cameraOffset);

        }
        
        public Matrix GetCameraWithSpecifiedMode(CameraMode cameraMode)
        {
            //TODO: implement
            throw new NotImplementedException();
        }
        
        public Matrix StationaryCamera(Camera camera)
        {
            //TODO: create stationary camera stationary tracing camera and moveing associated with object camera
            return StationaryCamera(camera, camera.cameraPosition, camera.cameraFront, camera.upAxis);
        }
        
        public Matrix StationaryCamera(Camera camera, Vector cameraPosition, Vector cameraFront, Vector upAxis)
        {
            return camera.LookAt(cameraPosition, cameraPosition + cameraFront, upAxis);
        }

        public Matrix StationaryTrackingModelCamera(Camera camera, Vector modelPosition)
        {
            return StationaryTrackingModelCamera(camera, modelPosition, camera.cameraPosition, camera.cameraFront, camera.upAxis);
        }

        public Matrix StationaryTrackingModelCamera(Camera camera, Vector modelPosition, Vector cameraPosition, Vector cameraFront, Vector upAxis)
        {
//            Vector<double> cameraPosition = new DenseVector(new[] {3.0, 1.0, 1.0});
//            Vector<double> cameraTarget = modelPosition;
//            Vector<double> upAxis = new DenseVector(new[] {0.0, 0.0, 1.0});
            return camera.LookAt(cameraPosition, modelPosition, upAxis);
        }

        public Matrix MovingAssociatedWithObjectCamera(Camera camera, Vector modelPosition, Vector cameraOffset)
        {
            //Moving Associated With Object Camera
//            Vector<double> cameraPosition = modelPosition;
//            Vector<double> cameraTarget = modelPosition;
//            Vector<double> upAxis = new DenseVector(new[] {0.0, 0.0, 1.0});
//            Vector<double> cameraOffset = new DenseVector(new [] {10.0, 0.0, 0.0});
            return MovingAssociatedWithObjectCamera(camera, modelPosition, cameraOffset, camera.cameraPosition, camera.cameraFront, camera.upAxis);
        }
        
        public Matrix MovingAssociatedWithObjectCamera(Camera camera, Vector modelPosition, Vector cameraOffset, Vector cameraPosition, Vector cameraFront, Vector upAxis)
        {
            //Moving Associated With Object Camera
//            Vector<double> cameraPosition = modelPosition;
//            Vector<double> cameraTarget = modelPosition;
//            Vector<double> upAxis = new DenseVector(new[] {0.0, 0.0, 1.0});
//            Vector<double> cameraOffset = new DenseVector(new [] {10.0, 0.0, 0.0});
            return camera.LookAt(modelPosition + cameraOffset, modelPosition, upAxis);
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