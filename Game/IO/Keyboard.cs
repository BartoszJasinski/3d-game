using System.Windows.Forms;
using System.Windows.Input;
using Game.Camera;
using Game.Math;

namespace Game.IO
{
    public class Keyboard
    {
        public GameData.GameData ProcessKeyPress(GameData.GameData gameData, KeyPressEventArgs e)
        {
            GameData.GameData processedGameData = gameData;
            if (e.KeyChar == 'w')
            {
                processedGameData.camera.cameraPosition = gameData.camera.cameraPosition + gameData.camera.cameraSpeed * gameData.camera.cameraFront;
            }
            else if (e.KeyChar == 's')
            {
                processedGameData.camera.cameraPosition = gameData.camera.cameraPosition - gameData.camera.cameraSpeed * gameData.camera.cameraFront;

            }
            else if (e.KeyChar == 'a')
            {
                processedGameData.camera.cameraPosition = gameData.camera.cameraPosition - gameData.camera.cameraSpeed *
                       gameData.camera.cameraFront.CrossProduct(gameData.camera.upAxis).Normalize();
            }
            else if (e.KeyChar == 'd')
            {
                processedGameData.camera.cameraPosition = gameData.camera.cameraPosition + gameData.camera.cameraSpeed *
                       gameData.camera.cameraFront.CrossProduct(gameData.camera.upAxis).Normalize();
            }
            else if (e.KeyChar == '1')
            {
                gameData.cameras.cameraMode = CameraMode.StationaryCamera;
            }
            else if (e.KeyChar == '2')
            {
                gameData.cameras.cameraMode = CameraMode.StationaryTrackingObjectCamera;
            }
            else if (e.KeyChar == '3')
            {
                gameData.cameras.cameraMode = CameraMode.MovingAssociatedWithObjectCamera;
            }

            return processedGameData;
//            return gameData.camera.cameraPosition;
        }
    }
}