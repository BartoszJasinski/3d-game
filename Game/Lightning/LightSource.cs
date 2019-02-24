using MathNet.Numerics.LinearAlgebra;

namespace Game.Lightning
{
    public class LightSource
    {
        public Light light { get; set; }

        public LightSource()
        {
            
        }
        
        public LightSource(Light light)
        {
            this.light = light;
        }    
    }
}