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
        //TODO change camera to ICamera
        public Camera.Camera camera { get; set; }
        public Camera.Cameras cameras { get; set; }
        public List<ILightningObject> lightObjects { get; set; }
        public ILightningModel lightningModel { get; set; }
        //TODO move ligths list from Phong to GameData

        
        public GameData(List<Model> models, Camera.Camera camera, Cameras cameras, List<ILightningObject> lightObjects,
            ILightningModel lightningModel)
        {
            this.models = models;
            this.camera = camera;
            this.lightObjects = lightObjects;
            this.lightningModel = lightningModel;
            this.cameras = cameras;
        }

        public GameData(): this(new List<Model>(), new Camera.Camera(), new Cameras(), new List<ILightningObject>(), new PhongLighting())
        {
                
        }


  
    }
}