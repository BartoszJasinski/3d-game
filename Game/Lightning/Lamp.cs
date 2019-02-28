using Game.Figure;

namespace Game.Lightning
{
    public class Lamp: LightSource
    {
        public Model model { get; set; }

        public Lamp(): base()
        {
            this.model = new Cone();
        }

        public Lamp(Model model): base()
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