using Game.Figure;

namespace Game.Lightning.LightningObject
{
    public class LightSource
    {
        public Model model { get; set; }
        public Light ambientLight { get; set; }
        public Light diffuseLight { get; set; }
        public Light specularLight { get; set; }


        public LightSource() : this(new Model(), new Light(), new Light(), new Light())
        {
        }

        public LightSource(Model model) : this(model, new Light(), new Light(), new Light())
        {
        }

        public LightSource(Model model, Light ambientLight, Light diffuseLight, Light specularLight)
        {
            this.model = model;
            this.ambientLight = ambientLight;
            this.diffuseLight = diffuseLight;
            this.specularLight = specularLight;
        }

        public LightSource(LightSource lightSource) :
            this(lightSource.model, lightSource.ambientLight, lightSource.diffuseLight,
                lightSource.specularLight)
        {
            //TODO Make it deep copy constructor
//            model = lightSource.model;
//            ambientLight = lightSource.ambientLight;
//            diffuseLight = lightSource.diffuseLight;
//            specularLight = lightSource.specularLight;
        }
    }
}