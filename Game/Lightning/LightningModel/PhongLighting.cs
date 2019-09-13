using Game.Lightning.LightningObject;
using Game.Math;
using static System.Math;

namespace Game.Lightning.LightningModel
{
    //TODO You should invert inclusion LightSources should contain PhongLightning (LightSources should user PhongLighthing internally),now PhongLightning "contains" LightSources 
    public class PhongLighting : ILightningModel
    {
        //TODO write function which applies(renders) phong lighining on scene
        //TODO: check if whole triangle face is fragment or only single pixels, because it is important in specular lightning, probably one pixel is fragment
        public Color ApplyLightning(GameData.GameData gameData, Color color, Vector fragPosition,
            Vector triangleNormal)
        {
            Vector triangleAfterLightningColor = new Vector(0, 0, 0);
            foreach (var lightSource in gameData.lightSources)
            {
                if (lightSource is Flashlight flashlight)
                {
                    if (flashlight.CalculateIfFragmentShouldBeIlluminated(fragPosition))
                    {
                        flashlight.spotDir = gameData.camera.cameraFront;
                        triangleAfterLightningColor +=
                            ApplyLightning(gameData, color, fragPosition, triangleNormal, lightSource).rgb;
                    }
                }
                else
                {
                    triangleAfterLightningColor +=
                        ApplyLightning(gameData, color, fragPosition, triangleNormal, lightSource).rgb;
                }
            }

            return new Color(triangleAfterLightningColor);
        }

        //TODO: delete this function probably
        private Color ApplyLightning(GameData.GameData gameData, Color color, Vector fragPosition,
            Vector triangleNormal, LightSource lightSource)
        {
//            return new Color((ApplyAmbientLightning(triangle, lightSource) /*+
//                ApplyDiffuseLightning(triangle, fragPosition, triangleNormal, lightSource) +
//                ApplySpecularLightning(triangle, gameData.camera.cameraPosition, fragPosition,
//                    triangleNormal)*/).rgb /*.Normalize(2)*/);

            return new Color((ApplyAmbientLightning(color, lightSource) +
                              ApplyDiffuseLightning(color, fragPosition, triangleNormal, lightSource) +
                              ApplySpecularLightning(gameData.camera.cameraPosition, fragPosition,
                                  triangleNormal, lightSource)).rgb.Normalize());


            return new Color(ApplyAmbientLightning(color, lightSource).rgb.Normalize());
//            return new Color(ApplyDiffuseLightning(color, fragPosition, triangleNormal, lightSource).rgb
//                .Normalize());
            return new Color(ApplySpecularLightning(gameData.camera.cameraPosition, fragPosition,
                triangleNormal, lightSource).rgb.Normalize());
        }

        private Color ApplyAmbientLightning(Color color, LightSource lightSource)
        {
            //        float ambientStrength = 0.1;
//        vec3 ambient = ambientStrength * lightColor;

//        vec3 result = ambient * objectColor;
//        FragColor = vec4(result, 1.0);
            Vector finalColorVector = new Vector(0, 0, 0);
            Vector colorVector = ApplyAmbientLight(color, lightSource.ambientLight);
            finalColorVector = finalColorVector.Add(colorVector);

            return new Color(finalColorVector);
        }

        //TODO: delete this function probably
        private Vector ApplyAmbientLight(Color color, Light ambientLight)
        {
            Vector ambient = ambientLight.lightStrength * ambientLight.lightColor.rgb;

            return ambient.PointwiseMultiply(color.rgb);
        }

        //TODO fix diffuse lightning when mouse is in focus of the window
        private Color ApplyDiffuseLightning(Color color, Vector fragPosition, Vector triangleNormal,
            LightSource lightSource)
        {
            //        float ambientStrength = 0.1;
//        vec3 ambient = ambientStrength * lightColor;

//        vec3 result = ambient * objectColor;
//        FragColor = vec4(result, 1.0);
            Vector finalColorVector = new Vector(0, 0, 0);
            Vector colorVector = ApplyDiffuseLight(color, fragPosition, triangleNormal, lightSource);
            finalColorVector = finalColorVector.Add(colorVector);

            return new Color(finalColorVector);
        }

        private Vector ApplyDiffuseLight(Color color, Vector fragPosition, Vector triangleNormal,
            LightSource lightSource)
        {
//            vec3 norm = normalize(Normal);
//            vec3 lightDir = normalize(lightPos - FragPos);
//            float diff = max(dot(norm, lightDir), 0.0);
//            vec3 diffuse = diff * lightColor;
//            fragPosition = new Vector(fragPosition.x, fragPosition.y, fragPosition.z);

            //TODO think if norm should be normals[0] or normals[1] or normals[2]
            Vector norm = triangleNormal.Normalize();
//            norm = new Vector(norm.x, norm.y, norm.z);
            Vector lightDir = (lightSource.model.translationVector - fragPosition).Normalize();
            double dot = -norm.DotProduct(lightDir);
            double diff = Max(dot, 0.0);
            Color diffuse = diff * lightSource.diffuseLight.lightStrength * lightSource.diffuseLight.lightColor;
            Vector col = diffuse.rgb.PointwiseMultiply(color.rgb);

            return col;
        }


        private Color ApplySpecularLightning(Vector cameraPosition, Vector fragPosition,
            Vector triangleNormal, LightSource lightSource)
        {
            Vector finalColorVector = new Vector(0, 0, 0);
            Vector colorVector = ApplySpecularLight(cameraPosition, fragPosition.CastVectorTo3D(),
                triangleNormal.CastVectorTo3D(), lightSource);
            finalColorVector = finalColorVector.Add(colorVector);

            return new Color(finalColorVector);
        }


        private Vector ApplySpecularLight(Vector cameraPosition, Vector fragPosition,
            Vector triangleNormal, LightSource lightSource)
        {
//            float specularStrength = 0.5;
//            vec3 viewDir = normalize(viewPos - FragPos);
//            vec3 lightDir = normalize(lightPos - FragPos);
//            vec3 reflectDir = reflect(-lightDir, norm);  
//            float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
//            vec3 specular = specularStrength * spec * lightColor;  

//            var lightColor = new Vector(1, 1, 1);
//            var lightPos = new Vector(5.0, 0.0, 0.0);
//            const double specularStrength = 0.5;
            var lightColor = lightSource.ambientLight.lightColor.rgb;
            var lightPos = lightSource.model.translationVector.CastVectorTo3D();
            double specularStrength = lightSource.specularLight.lightStrength;

            Vector viewDir = (cameraPosition - fragPosition).Normalize();
            Vector lightDir = (lightPos - fragPosition).Normalize();
            Vector reflectDir = (lightDir /*.ResizeVectorToLength(3)*/).ReflectVector(triangleNormal);
            double dot = (viewDir /*.ResizeVectorToLength(3)*/).DotProduct(reflectDir);
            double spec = Pow(Max(dot, 0.0), 32);

            return (specularStrength * spec * lightColor);
//            double r = Clamp(specularStrength * spec * lightColor.x, 0, 255);
//            double g = Clamp(specularStrength * spec * lightColor.y, 0, 255);
//            double b = Clamp(specularStrength * spec * lightColor.z, 0, 255);
//            return new Vector(r, g, b);
        }

/*        private Vector ApplySpecularLight(Triangle triangle, Vector cameraPosition, Vector fragPosition,
            Vector triangleNormal, Light specularLight)
        {
//            float specularStrength = 0.5;
//            vec3 viewDir = normalize(viewPos - FragPos);
//            vec3 lightDir = normalize(lightPos - FragPos);
//            vec3 reflectDir = reflect(-lightDir, norm);  
//            float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
//            vec3 specular = specularStrength * spec * lightColor;  

            var lightColor = new Vector(1, 1, 1);
            var lightPos = new Vector(5.0, 0.0, 0.0);
            const double specularStrength = 0.5;

            Vector viewDir = (cameraPosition - fragPosition).Normalize();
            Vector lightDir = (lightPos - fragPosition).Normalize();
            Vector reflectDir = (-lightDir /*.ResizeVectorToLength(3)#1#).ReflectVector(triangleNormal);
            double dot = (viewDir /*.ResizeVectorToLength(3)#1#).DotProduct(reflectDir);
            double spec = Pow(Max(dot, 0.0), 32);

            return (specularStrength * spec * lightColor);
//            double r = Clamp(specularStrength * spec * lightColor.x, 0, 255);
//            double g = Clamp(specularStrength * spec * lightColor.y, 0, 255);
//            double b = Clamp(specularStrength * spec * lightColor.z, 0, 255);
//            return new Vector(r, g, b);
        }*/

        private double Clamp(double variableToClamp, double lowerLimit, double upperLimit)
        {
            return Min(Max(variableToClamp, lowerLimit), upperLimit);
        }
    }
}