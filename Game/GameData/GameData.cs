using System.Collections.Generic;
using Game.Camera;
using Game.Figure;
using Game.Lightning;
using Game.Lightning.LightningModel;
using Game.Lightning.LightningObject;

namespace Game.GameData
{
    //TODO make additional classes (or refactor functions) which encapsulate data so in different processing classes like (lightnig, ScanLine) you dont have to pass whole gamedata object
    public class GameData
    {
        public List<Model> models { get; set; }
        public Camera.Camera camera { get; set; }
        public Cameras cameras { get; set; }
        public List<LightSource> lightSources { get; set; }
        public ILightningModel lightningModel { get; set; }

        
        public GameData(List<Model> models, Camera.Camera camera, Cameras cameras, List<LightSource> lightSources,
            ILightningModel lightningModel)
        {
            this.models = models;
            this.camera = camera;
            this.lightSources = lightSources;
            this.lightningModel = lightningModel;
            this.cameras = cameras;
        }

//        public GameData(): this(new List<Model>(), new Camera.Camera(), new Cameras(), new List<ILightningObject>(), new PhongLighting())
//        {
//                
//        }


  
    }
}