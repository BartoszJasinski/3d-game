using System.Windows.Forms;
using Game.Math;

namespace Game.IO
{
    public class Mouse
    {
        public static bool firstMouse = true;
        public static double lastX = 1100 / 2;
        public static double lastY = 820 / 2;
        public static double yaw   = 0.0f;	// yaw is initialized to -90.0 degrees since a yaw of 0.0 results in a direction vector pointing to the right so we initially rotate a bit to the left.
        public static double pitch =  0.0f;
        //TODO check if it is bug free (strange behaviour occurs i think) 
        public void ProcessMouseMove(GameData.GameData gameData, MouseEventArgs e)
        {
            if (firstMouse)
            {
                lastX = e.X;
                lastY = e.Y;
                firstMouse = false;
            }

            double xoffset = e.X - lastX;
            double yoffset = lastY - e.Y; // reversed since y-coordinates go from bottom to top
            lastX = e.X;
            lastY = e.Y;

            float sensitivity = 0.001f; // change this value to your liking
            xoffset *= sensitivity;
            yoffset *= sensitivity;

            yaw += xoffset;
            pitch += yoffset;

            // make sure that when pitch is out of bounds, screen doesn't get flipped
            if (pitch > 89.0f)
                pitch = 89.0f;
            if (pitch < -89.0f)
                pitch = -89.0f;

            Vector front = new Vector();
            front.x = System.Math.Cos(yaw) * System.Math.Cos(pitch);
            front.z = System.Math.Sin(pitch);
            front.y = System.Math.Sin(yaw) * System.Math.Cos(pitch);
            gameData.camera.cameraFront = front.Normalize(2);
        }
    }
}