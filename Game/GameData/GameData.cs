using System.Collections.Generic;
using Game.Figure;
using Game.Lightning;

namespace Game.GameData
{
    public class GameData
    {
        public List<Model> models { get; set; }
        public Game.Camera.Camera camera { get; set; }
        public List<LightSource> lightSources { get; set; }

        public GameData(List<Model> models, Game.Camera.Camera camera, List<LightSource> lightSources)
        {
            this.models = models;
            this.camera = camera;
            this.lightSources = lightSources;
        }

        public GameData(): this(new List<Model>(), new Game.Camera.Camera(), new List<LightSource>())
        {
                
        }


  
    }
}