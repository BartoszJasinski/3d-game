using System.Collections.Generic;
using Game.Figure;
using Game.Lightning;
using Game.Math;

namespace Game.GameData
{
    public class GameDataInit
    {
        
        public void InitializeGameData(GameData gameData)
        {
            gameData.models = CreateModels();
            gameData.lightSources = CreateIllumination();
            gameData.camera = CreateCamera();
            AddLightModelsToRenderList(gameData);
        }

        private Camera.Camera CreateCamera()
        {
            return new Camera.Camera(new Vector (5.0, 0.0, 0.0), new Vector (0, 0.0, 0.0), new Vector(0.0, 0.0, -1.0));
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
            Cone cone = CreateCone();
            Vector modelPosition = new Vector(0, 0, 0);
            cone.translationVector = modelPosition;
            cone.scaleVector = new Vector(5, 5, 1.0);
            cone.rotationVector = new Vector(0, 0, 1);
            cone.rotationAngle = 0;
            models.Add(cone);
            
            return models;
        }

        private Cone CreateCone()
        {
            return new Cone();
        }
        
        private Sphere CreateSphere()
        {
            return new Sphere();
        }

    }
}