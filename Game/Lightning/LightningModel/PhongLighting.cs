using System.Collections.Generic;
using Game.Figure;
using Game.Math;

namespace Game.Lightning.LightningModel
{
    public class PhongLighting : ILightningModel
    {
        
        private List<LightSource> ambientLights { get; set; }
        private List<LightSource> diffuseLights { get; set; }
        private List<LightSource> specularLights { get; set; }
        
        public PhongLighting() : this(
            new List<LightSource> {new LightSource(new Light(new Color(1.0, 1.0, 1.0), 1.0))},
            new List<LightSource> {new LightSource(new Light(new Color(1.0, 1.0, 1.0)), new Vector(0.0, 0.0, 0.0))},
            new List<LightSource> {new LightSource(new Light(new Color(1.0, 1.0, 1.0)), new Vector(0.0, 0.0, 0.0))})
        {
            
        }

        public PhongLighting(List<LightSource> ambientLights, List<LightSource> diffuseLights, List<LightSource> specularLights)
        {
            this.ambientLights = ambientLights;
            this.diffuseLights = diffuseLights;
            this.specularLights = specularLights;
        }

        //TODO write function which applies(renders) phong lighining on scene
        //TODO: check if whole triangle face is fragment or only single pixels, because it is important in specular lightning, probably one pixel is fragment
        public Color ApplyLightning(GameData.GameData gameData, Triangle triangle, Vector fragPosition, Vector triangleNormal)
        {
            return new Color((ApplyAmbientLightning(triangle) /*+
                              ApplyDiffuseLightning(triangle, fragPosition, triangleNormal) +*/
                              /*ApplySpecularLightning(triangle, gameData.camera.cameraPosition, fragPosition,
                                  triangleNormal)*/).rgb/*.Normalize(2)*/);
        }

        private Color ApplyAmbientLightning(Triangle triangle)
        {
            //        float ambientStrength = 0.1;
//        vec3 ambient = ambientStrength * lightColor;

//        vec3 result = ambient * objectColor;
//        FragColor = vec4(result, 1.0);
            Vector finalColorVector = new Vector(0, 0, 0);
            foreach (var ambientLight in ambientLights)
            {
                Vector ambient = ambientLight.light.lightStrength * ambientLight.light.lightColor.rgb;
                Vector colorVector = ambient.PointwiseMultiply(new Vector(triangle.color.R, triangle.color.G, triangle.color.B));

               finalColorVector = finalColorVector.Add(colorVector);
            }
            
            return new Color(finalColorVector);
        }



        private Color ApplyDiffuseLightning(Triangle triangle, Vector fragPosition, Vector triangleNormal)
        {
//            vec3 norm = normalize(Normal);
//            vec3 lightDir = normalize(lightPos - FragPos);
//            float diff = max(dot(norm, lightDir), 0.0);
//            vec3 diffuse = diff * lightColor;
            //TODO: implement DropLastValue in Game.Math.Vector
//            fragPosition = new Vector(fragPosition.x, fragPosition.y, fragPosition.z);

            Vector lightPos = new Vector(5.0, 0.0, 0.0);
            Color lightColor = new Color(1.0, 1.0, 1.0);
            //TODO think if norm should be normals[0] or normals[1] or normals[2]
            Vector norm = triangleNormal.Normalize(2);
//            norm = new Vector(norm.x, norm.y, norm.z);
            Vector lightDir = (lightPos - fragPosition).Normalize(2);
            double dot = norm.DotProduct(lightDir);
            double diff = System.Math.Max(dot, 0.0);
            Color diffuse = 10 * diff * lightColor;
            Vector col = diffuse.rgb.PointwiseMultiply(triangle.color.rgb);
            
            return new Color(col);

        }

        
        private Color ApplySpecularLightning(Triangle triangle, Vector cameraPosition, Vector fragPosition,
            Vector triangleNormal)
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

            Vector viewDir = (cameraPosition - fragPosition).Normalize(2);
            Vector lightDir = (lightPos - fragPosition).Normalize(2);
            Vector reflectDir = (lightDir/*.ResizeVectorToLength(3)*/).ReflectVector(triangleNormal);
            double dot = (viewDir/*.ResizeVectorToLength(3)*/).DotProduct(reflectDir);
            double spec = System.Math.Pow(System.Math.Max(dot, 0.0), 32);

            Color specular = new Color(specularStrength * spec * lightColor);
            return specular;
        }
        

    }
}