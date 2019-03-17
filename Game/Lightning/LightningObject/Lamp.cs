using Game.Figure;
using Game.Lightning.LightningModel;

namespace Game.Lightning.LightningObject
{
    public class Lamp : ILightningObject
    {

        public Lamp() : base()
        {
            this.model = new Cone();
        }

        public Lamp(Model model) : base()
        {
            this.model = model;
        }

        public Lamp(Model model, LightSource lightSource)
        {
            this.model = model;
            this.light = lightSource.light;
        }
    }
}