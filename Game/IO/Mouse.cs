using System.Windows.Forms;
using Game.Math;

namespace Game.IO
{
    public class Mouse
    {
        public bool firstMouse = true;
        //TODO: refactor
        public double lastX = 1100 / 2;
        public double lastY = 820 / 2;
        public double yaw   = 180.0f;	// yaw is initialized to -90.0 degrees since a yaw of 0.0 results in a direction vector pointing to the right so we initially rotate a bit to the left.
        public double pitch =  0.0f;
        //TODO check if it is bug free (strange behaviour occurs i think) 
        //TODO make cursor disappear and hold cursor when in focus 
        //TODO: when there is first mouse movement model changes direction of displaying models, models gets displayed upside down, diffuse lightnign in phong shading changes
        //TODO: refactor value of lastX and lastY
        public Vector ProcessMouseMove(MouseEventArgs e)
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

            float sensitivity = 0.1f; // change this value to your liking
            xoffset *= sensitivity;
            yoffset *= sensitivity;

            yaw += xoffset;
            pitch += yoffset;

            // make sure that when pitch is out of bounds, screen doesn't get flipped
            if (pitch > 89.0f)
                pitch = 89.0f;
            if (pitch < -89.0f)
                pitch = -89.0f;
            
//            double x = - System.Math.Cos(yaw) * System.Math.Cos(pitch);
//            double z = System.Math.Sin(pitch);
//            double y = - System.Math.Sin(yaw) * System.Math.Cos(pitch);
//            front.x = cos(glm::radians(Yaw)) * cos(glm::radians(Pitch));
//            front.y = sin(glm::radians(Pitch));
//            front.z = sin(glm::radians(Yaw)) * cos(glm::radians(Pitch));

            double radYaw = Math.Math.ConvertDegreesToRadians(yaw), radPitch = Math.Math.ConvertDegreesToRadians(pitch);
            double x = System.Math.Cos(radYaw) * System.Math.Cos(radPitch);
            double y = System.Math.Sin(radYaw) * System.Math.Cos(radPitch);
            double z = System.Math.Sin(radPitch);

            
            Vector front = new Vector(x, y, z);
            
            return front.Normalize();
        }
    }
}