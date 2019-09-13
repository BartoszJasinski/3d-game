using System.Windows.Forms;
using Game.Math;

using static System.Math;

namespace Game.IO
{
    public class Mouse
    {
        public bool FirstMouse = true;
        //TODO: refactor
        public double LastX = 1100 / 2;
        public double LastY = 820 / 2;
        public double Yaw   = 180.0f;// yaw is initialized to -90.0 degrees since a yaw of 0.0 results in a direction vector pointing to the right so we initially rotate a bit to the left.
        public double Pitch =  0.0f;
        public Vector ProcessMouseMove(MouseEventArgs e)
        {
            if (FirstMouse)
            {
                LastX = e.X;
                LastY = e.Y;
                FirstMouse = false;
            }

            double xoffset = e.X - LastX;
            double yoffset = LastY - e.Y; 
            LastX = e.X;
            LastY = e.Y;

            float sensitivity = 0.1f; 
            xoffset *= sensitivity;
            yoffset *= sensitivity;

            Yaw += xoffset;
            Pitch += yoffset;

            if (Pitch > 89.0f)
                Pitch = 89.0f;
            if (Pitch < -89.0f)
                Pitch = -89.0f;
            
            double radYaw = Math.Math.ConvertDegreesToRadians(Yaw), radPitch = Math.Math.ConvertDegreesToRadians(Pitch);
            double x = Cos(radYaw) * Cos(radPitch);
            double y = Sin(radYaw) * Cos(radPitch);
            double z = Sin(radPitch);

            
            Vector front = new Vector(x, y, z);
            
            return front.Normalize();
        }
    }
}