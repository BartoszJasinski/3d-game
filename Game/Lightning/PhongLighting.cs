using System;
using System.Collections.Generic;

using Game.Figure;
using Game.Math;

namespace Game.Lightning
{
    public class PhongLighting : ILightningModel
    {
        
        private List<LightSource> ambientLights { get; set; }
        private List<LightSource> diffuseLights { get; set; }
        
        public PhongLighting() : this(new List<LightSource> {new LightSource(new Light(new Color(1.0, 1.0, 1.0), 0.9))},
            new List<LightSource>
            {
                new LightSource((new Light(new Color(1.0, 1.0, 1.0))),
                    new Vector(0.0, 0.0, 0.0))
            })
        {
            
        }

        public PhongLighting(List<LightSource> ambientLights, List<LightSource> diffuseLights)
        {
            this.ambientLights = ambientLights;
            this.diffuseLights = diffuseLights;
        }

        //TODO write function which applies(renders) phong lighining on scene
        public Color ApplyLightning(Triangle triangle)
        {
            return ApplyAmbientLightning(triangle);
//            return ApplyDiffuseLightning(triangle);
//            ApplySpecularLightning();
        }

        private Color ApplyAmbientLightning(Triangle triangle)
        {
            Vector finalColorVector = new Vector(0, 0, 0);
            foreach (var ambientLight in ambientLights)
            {
                Vector ambient = ambientLight.light.lightStrength * ambientLight.light.lightColor.rgb;
                Vector colorVector = ambient.PointwiseMultiply(new Vector(triangle.Color.R, triangle.Color.G, triangle.Color.B));

               finalColorVector = finalColorVector.Add(colorVector);
            }
            
            return new Color(finalColorVector);
        }

        private Color ApplyDiffuseLightning(Triangle triangle)
        {
            throw new NotImplementedException();
        }

       

        private void ApplySpecularLightning()
        {
            
        }
        
        
//        float ambientStrength = 0.1;
//        vec3 ambient = ambientStrength * lightColor;

//        vec3 result = ambient * objectColor;
//        FragColor = vec4(result, 1.0);
    }
}