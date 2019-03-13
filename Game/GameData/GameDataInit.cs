using System.Collections.Generic;
using Game.Figure;
using Game.Lightning;
using Game.Math;

namespace Game.GameData
{
    public class GameDataInit
    {
        
        public GameData InitializeGameData()
        {
            GameData gameData = new GameData(CreateModels(), CreateCamera(), CreateIllumination(), new PhongLighting());
           
            return gameData;
        }

        private Camera.Camera CreateCamera()
        {
            return new Camera.Camera(new Vector (10.0, 0.0, 0.0), new Vector (-1.0, 0.0, 0.0), new Vector(0.0, 0.0, 1.0), 1);
        }

        private void AddLightModelsToRenderList(GameData gameData)
        {
            foreach (var lightSource in gameData.lightSources)
            {
//                lightSource.model
            }
        }


        private List<LightSource> CreateIllumination()
        {
            List<LightSource> lightSources = new List<LightSource> { CreateLamp() };

            return lightSources;
        }
        
        
        private Lamp CreateLamp()
        {
            return new Lamp(new Cone(), new LightSource(new Light(new Color(1.0, 1.0, 1.0))));
        }
        
        private LightSource CreateLightSource()
        {
            return new LightSource(new Light(new Color(1.0, 1.0, 1.0)));
        }
        
        private List<Model> CreateModels()
        {
            List<Model> models = new List<Model> {};
            
//            models.Add(CreateSphere());
            models.Add(CreateCone());
            
            return models;
        }

        private Cone CreateCone()
        {
            Cone cone = new Cone();
            Vector modelPosition = new Vector(0, 0, 0);
            cone.translationVector = modelPosition;
            cone.scaleVector = new Vector(2.0, 2.0, 1.0);
            cone.rotationVector = new Vector(0, 1, 0);
            cone.rotationAngle = 0;
            return cone;
        }
        
        private Sphere CreateSphere()
        {
            Sphere sphere = new Sphere();
            Vector modelPosition = new Vector(0, 0, 0);
            sphere.translationVector = modelPosition;
            sphere.scaleVector = new Vector(1, 1, 1.0);
            sphere.rotationVector = new Vector(0, 0, 1);
            sphere.rotationAngle = 0;
            return sphere;
        }

        
        


    }
}