using System.Collections.Generic;
using Game.Figure;
using Game.Lightning.LightningObject;
using Game.Math;

namespace Game.Lightning.LightningModel
{
    public class PhongLighting : ILightningModel
    {
        //TODO write function which applies(renders) phong lighining on scene
        //TODO: check if whole triangle face is fragment or only single pixels, because it is important in specular lightning, probably one pixel is fragment
        public Color ApplyLightning(GameData.GameData gameData, Triangle triangle, Vector fragPosition, Vector triangleNormal)
        {
            Vector triangleAfterLightningColor = new Vector(0, 0, 0);
            foreach (var lightSource in gameData.lightSources)
            {
                triangleAfterLightningColor += ApplyLightning(gameData, triangle, fragPosition, triangleNormal, lightSource).rgb;
            }
            
            return new Color(triangleAfterLightningColor);
        }
        
        //TODO: delete this function probably
        private Color ApplyLightning(GameData.GameData gameData, Triangle triangle, Vector fragPosition, Vector triangleNormal, LightSource lightSource)
        {
            return new Color((ApplyAmbientLightning(triangle, lightSource) /*+
                ApplyDiffuseLightning(triangle, fragPosition, triangleNormal, lightSource) +
                ApplySpecularLightning(triangle, gameData.camera.cameraPosition, fragPosition,
                    triangleNormal)*/).rgb/*.Normalize(2)*/);
        }

        private Color ApplyAmbientLightning(Triangle triangle, LightSource lightSource)
        {
            //        float ambientStrength = 0.1;
//        vec3 ambient = ambientStrength * lightColor;

//        vec3 result = ambient * objectColor;
//        FragColor = vec4(result, 1.0);
            Vector finalColorVector = new Vector(0, 0, 0);
            Vector colorVector = ApplyAmbientLight(triangle, lightSource.ambientLight);
            finalColorVector = finalColorVector.Add(colorVector);
            
            return new Color(finalColorVector);
        }
        
        //TODO: delete this function probably
        private Vector ApplyAmbientLight(Triangle triangle, Light ambientLight)
        {
            
            Vector ambient = ambientLight.lightStrength * ambientLight.lightColor.rgb;
            
            return ambient.PointwiseMultiply(triangle.color.rgb);
        }
        
        //TODO fix diffuse lightning when mouse is in focus of the window
        private Color ApplyDiffuseLightning(Triangle triangle, Vector fragPosition, Vector triangleNormal, LightSource lightSource)
        {
            //        float ambientStrength = 0.1;
//        vec3 ambient = ambientStrength * lightColor;

//        vec3 result = ambient * objectColor;
//        FragColor = vec4(result, 1.0);
            Vector finalColorVector = new Vector(0, 0, 0);
            Vector colorVector = ApplyDiffuseLight(triangle, fragPosition, triangleNormal, lightSource);
            finalColorVector = finalColorVector.Add(colorVector);
            
            return new Color(finalColorVector);
        }
        
        private Vector ApplyDiffuseLight(Triangle triangle, Vector fragPosition, Vector triangleNormal, LightSource lightSource)
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
            double dot = norm.DotProduct(lightDir);
            double diff = System.Math.Max(dot, 0.0);
            Color diffuse = diff * lightSource.diffuseLight.lightStrength * lightSource.diffuseLight.lightColor;
            Vector col = diffuse.rgb.PointwiseMultiply(triangle.color.rgb);
            
            return col;

        }

        
        private Color ApplySpecularLightning(Triangle triangle, Vector cameraPosition, Vector fragPosition,
            Vector triangleNormal, LightSource lightSource)
        {
            Vector finalColorVector = new Vector(0, 0, 0);
            Vector colorVector = ApplySpecularLight(triangle, cameraPosition, fragPosition, triangleNormal, lightSource.specularLight);
            finalColorVector = finalColorVector.Add(colorVector);
            
            return new Color(finalColorVector);
        }
        
        
        private Vector ApplySpecularLight(Triangle triangle, Vector cameraPosition, Vector fragPosition,
            Vector triangleNormal, Light specularLight)
        {
            
//            float specularStrength = 0.5;
//            vec3 viewDir = normalize(viewPos - FragPos);
//            vec3 lightDir = normalize(lightPos - FragPos);
//            vec3 reflectDir = reflect(-lightDir, norm);  
//            float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
//            vec3 specular = specularStrength * spec * lightColor;  

            Vector lightColor = new Vector(1, 1, 1);            
            Vector lightPos = new Vector(5.0, 0.0, 0.0);
            double specularStrength = 0.5;

            Vector viewDir = (cameraPosition - fragPosition).Normalize();
            Vector lightDir = (lightPos - fragPosition).Normalize();
            Vector reflectDir = (lightDir/*.ResizeVectorToLength(3)*/).ReflectVector(triangleNormal);
            double dot = (viewDir/*.ResizeVectorToLength(3)*/).DotProduct(reflectDir);
            double spec = System.Math.Pow(System.Math.Max(dot, 0.0), 32);

            return specularStrength * spec * lightColor;
        }

    }
}