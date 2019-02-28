using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Lightning
{
    public class LightSource
    {
        public Light light { get; set; }
        public Vector<double> position { get; set; }
        
        public LightSource() : this(new Light(), DenseVector.OfArray(new double[] { 0, 0, 0 }))
        {
            
        }
        
        public LightSource(Light light) : this(light, DenseVector.OfArray(new double[] { 0, 0, 0 }))
        {
            
        }    
        
        public LightSource(Light light, Vector<double> position )
        {
            this.light = light;
            this.position = position;
        }    
    }
}