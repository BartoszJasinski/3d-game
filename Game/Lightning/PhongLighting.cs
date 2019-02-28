using Game.Figure;

namespace Game.Lightning
{
    public class PhongLighting
    {
        
        private LightSource ambientLight { get; set; } = new LightSource(new Light(new Color(1.0,1.0,1.0), 0.1));

        PhongLighting()
        {
            
        }


        //TODO write function which applies(renders) phong lighining on scene
        public void ApplyPhongLightning()
        {
            
        }

        private void ApplyAmbientLightning()
        {
            
        }

        private void ApplyDiffuseLightning()
        {
            
        }

        private void CalculateNormalVectors(Model model)
        {
            
            foreach (var triangle in model.triangles)
            {
                triangle.firstVertex
            }
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