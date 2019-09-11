using Game.Math;

namespace Game.Lightning.LightningObject
{
    public class Flashlight : LightSource
    {
        private Vector spotDir { get; set; }
        private double cutoffAngle { get; set; }

        public Flashlight(LightSource lightSource, Vector spotDir, double cutoffAngle): base(lightSource)
        {
            this.spotDir = spotDir;
            this.cutoffAngle = cutoffAngle;
        }

        public bool CalculateIfFragmentShouldBeIlluminated(Vector fragmentPosition)
        {
            Vector lightDir = model.translationVector - fragmentPosition;
            double theta = lightDir.DotProduct(-spotDir.Normalize());


            return theta > cutoffAngle;
//            if (theta > _cutoffAngle)
//            {
//                
//            }
//            else
//            {
//                System.Console.WriteLine("Object is not in spotlight");
//            }
//                vec3 lightDir = normalize(light.position - FragPos);
//            float theta = dot(lightDir, normalize(-light.direction));
//    
//            if(theta > light.cutOff) 
//            {       
//                // do lighting calculations
//            }
//            else  // else, use ambient light so scene isn't completely dark outside the spotlight.
//                color = vec4(light.ambient * vec3(texture(material.diffuse, TexCoords)), 1.0);
        }
    }
}