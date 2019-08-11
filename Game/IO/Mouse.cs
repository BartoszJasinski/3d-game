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
        //TODO check if it is bug free (strange behaviour occurs i think) 
        //TODO make cursor disappear and hold cursor when in focus 
        //TODO: when there is first mouse movement model changes direction of displaying models, models gets displayed upside down, diffuse lightnign in phong shading changes
        //TODO: refactor value of lastX and lastY
        public Vector ProcessMouseMove(MouseEventArgs e)
        {
            if (FirstMouse)
            {
                LastX = e.X;
                LastY = e.Y;
                FirstMouse = false;
            }

            double xoffset = e.X - LastX;
            double yoffset = LastY - e.Y; // reversed since y-coordinates go from bottom to top
            LastX = e.X;
            LastY = e.Y;

            float sensitivity = 0.1f; // change this value to your liking
            xoffset *= sensitivity;
            yoffset *= sensitivity;

            Yaw += xoffset;
            Pitch += yoffset;

            // make sure that when pitch is out of bounds, screen doesn't get flipped
            if (Pitch > 89.0f)
                Pitch = 89.0f;
            if (Pitch < -89.0f)
                Pitch = -89.0f;
            
//            double x = - System.Math.Cos(yaw) * System.Math.Cos(pitch);
//            double z = System.Math.Sin(pitch);
//            double y = - System.Math.Sin(yaw) * System.Math.Cos(pitch);
//            front.x = cos(glm::radians(Yaw)) * cos(glm::radians(Pitch));
//            front.y = sin(glm::radians(Pitch));
//            front.z = sin(glm::radians(Yaw)) * cos(glm::radians(Pitch));

            double radYaw = Math.Math.ConvertDegreesToRadians(Yaw), radPitch = Math.Math.ConvertDegreesToRadians(Pitch);
            double x = Cos(radYaw) * Cos(radPitch);
            double y = Sin(radYaw) * Cos(radPitch);
            double z = Sin(radPitch);

            
            Vector front = new Vector(x, y, z);
            
            return front.Normalize();
        }
    }
}