using Game.Figure;
using Game.Lightning.LightningModel;

namespace Game.Lightning.LightningObject
{
    public class Lamp : LightSource
    {

        public Lamp()
        {
            
        }

        public Lamp(Model model) : base(model)
        {
            
        }
        
        public Lamp(Model model, Light ambientLight, Light diffuseLight, Light specularLight) : base(model,
            ambientLight, diffuseLight, specularLight)
        {
        }
        
        public Lamp(LightSource lightSource) : base(lightSource.model, lightSource.ambientLight,
            lightSource.diffuseLight, lightSource.specularLight)
        {
        }
        
    }
}