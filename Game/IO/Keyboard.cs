using System.Windows.Forms;
using System.Windows.Input;
using Game.Math;

namespace Game.IO
{
    public class Keyboard
    {
        public Vector ProcessKeyPress(GameData.GameData gameData, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                return gameData.camera.cameraPosition + gameData.camera.cameraSpeed * gameData.camera.cameraFront;
            }
            else if (e.KeyChar == 's')
            {
                return gameData.camera.cameraPosition - gameData.camera.cameraSpeed * gameData.camera.cameraFront;

            }
            else if (e.KeyChar == 'a')
            {
                return gameData.camera.cameraPosition - gameData.camera.cameraSpeed *
                       gameData.camera.cameraFront.CrossProduct(gameData.camera.upAxis).Normalize(2);
            }
            else if (e.KeyChar == 'd')
            {
                return gameData.camera.cameraPosition + gameData.camera.cameraSpeed *
                       gameData.camera.cameraFront.CrossProduct(gameData.camera.upAxis).Normalize(2);
            }

            return gameData.camera.cameraPosition;
        }
    }
}