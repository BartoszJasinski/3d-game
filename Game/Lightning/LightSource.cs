using Game.Math;

namespace Game.Lightning
{
    public class LightSource
    {
        public Light light { get; set; }
        public Vector position { get; set; }
        
        public LightSource() : this(new Light(), new Vector(0, 0, 0 ))
        {
            
        }
        
        public LightSource(Light light) : this(light, new Vector(0, 0, 0))
        {
            
        }    
        
        public LightSource(Light light, Vector position )
        {
            this.light = light;
            this.position = position;
        }    
    }
}