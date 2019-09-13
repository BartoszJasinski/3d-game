using System.Collections.Generic;
using Game.Camera;
using Game.Figure;
using Game.Lightning;
using Game.Lightning.LightningModel;
using Game.Lightning.LightningObject;

namespace Game.GameData
{
    public class GameData
    {
        public List<Model> models { get; set; }
        public Camera.Camera camera { get; set; }
        public Cameras cameras { get; set; }
        public List<LightSource> lightSources { get; set; }
        public ILightningModel lightningModel { get; set; }
        public Model player { get; set; }
        
        public GameData(List<Model> models, Camera.Camera camera, Cameras cameras, List<LightSource> lightSources,
            ILightningModel lightningModel, Model player)
        {
            this.models = models;
            this.camera = camera;
            this.lightSources = lightSources;
            this.lightningModel = lightningModel;
            this.cameras = cameras;
            this.player = player;
            
            models.Add(player);
        }


  
    }
}