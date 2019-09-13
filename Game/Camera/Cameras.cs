using System;
using System.Collections.Generic;
using System.Linq;
using Game.Math;

namespace Game.Camera
{
    //TODO: implement and test other cameras
    //TODO: create way of choosing different cameras like (keyboard shortucts or smth else) and nice API to choose cameras 
    //TODO: fix displaying because, in StationaryCamera top of the cone is the highest point, and in StationaryTrackingModelCamera and MovingAssociated with object is the lowest point
    public class Cameras
    {
        public CameraMode cameraMode { get; set; }

        public Cameras(CameraMode cameraMode)
        {
            this.cameraMode = cameraMode;
        }
        Matrix ViewMatrix(CameraMode cameraMode, Camera camera)
        {

            return camera.LookAt();

        }

        //TODO: maybe refactor to use List
        public Matrix GetCamera(GameData.GameData gameData)
        {
            if (cameraMode == CameraMode.StationaryCamera)
            {
                return StationaryCamera(gameData.camera);
            }

            if (cameraMode == CameraMode.StationaryTrackingObjectCamera)
            {
                //TODO: refactor First()
                return StationaryTrackingModelCamera(gameData.camera, gameData.models.First().translationVector);
            }

            if(cameraMode == CameraMode.MovingAssociatedWithObjectCamera)
            {
                //TODO: refactor First()
                Vector cameraOffset = new Vector(10, 0, 0);
                return MovingAssociatedWithObjectCamera(gameData.camera, gameData.models.First().translationVector,
                    cameraOffset);
            }

            return StationaryCamera(gameData.camera);

        }

        public Matrix GetCameraWithSpecifiedMode(CameraMode cameraMode)
        {
            throw new NotImplementedException();
        }
        
        public Matrix StationaryCamera(Camera camera)
        {
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
            return camera.LookAt(cameraPosition, modelPosition, upAxis);
        }
        
        public Matrix MovingAssociatedWithObjectCamera(Camera camera, Vector modelPosition, Vector cameraOffset)
        {
            return MovingAssociatedWithObjectCamera(camera, modelPosition, cameraOffset, camera.cameraPosition, camera.cameraFront, camera.upAxis);
        }
        
        public Matrix MovingAssociatedWithObjectCamera(Camera camera, Vector modelPosition, Vector cameraOffset, Vector cameraPosition, Vector cameraFront, Vector upAxis)
        {
            return camera.LookAt(modelPosition.CastVectorTo3D() + cameraOffset, modelPosition, upAxis);
        }
        
    }
}