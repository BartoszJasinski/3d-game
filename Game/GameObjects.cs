using System.Collections.Generic;
using Game.Figure;
using Game.Lightning;

namespace Game
{
    public class GameObjects
    {
        public List<Model> models { get; set; }
        public Camera.Camera camera { get; set; }
        public List<LightSource> lightSources { get; set; }

        public GameObjects(List<Model> models, Camera.Camera camera, List<LightSource> lightSources)
        {
            this.models = models;
            this.camera = camera;
            this.lightSources = lightSources;
        }

        public GameObjects(): this(new List<Model>(), new Camera.Camera(), new List<LightSource>())
        {
                
        }
        
        
    }
}