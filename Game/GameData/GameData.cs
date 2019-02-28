using System.Collections.Generic;
using Game.Figure;
using Game.Lightning;

namespace Game.GameData
{
    public class GameData
    {
        public List<Model> models { get; set; }
        //TODO change camera to ICamera
        public Game.Camera.Camera camera { get; set; }
        public List<LightSource> lightSources { get; set; }
        public ILightningModel lightningModel { get; set; }
        //TODO move ligths list from Phong to GameData

        
        public GameData(List<Model> models, Game.Camera.Camera camera, List<LightSource> lightSources, ILightningModel lightningModel)
        {
            this.models = models;
            this.camera = camera;
            this.lightSources = lightSources;
            this.lightningModel = lightningModel;
        }

        public GameData(): this(new List<Model>(), new Game.Camera.Camera(), new List<LightSource>(), new PhongLighting())
        {
                
        }


  
    }
}