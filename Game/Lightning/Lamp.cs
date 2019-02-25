using Game.Figure;

namespace Game.Lightning
{
    public class Lamp: LightSource
    {
        public Model model { get; set; }

        public Lamp()
        {
            
        }

        public Lamp(Model model)
        {
            this.model = model;
        }
    }
}