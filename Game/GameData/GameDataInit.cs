using System.Collections.Generic;
using Game.Figure;
using Game.Lightning;

namespace Game.GameData
{
    public class GameDataInit
    {
        public void InitializeGameObjects(GameData gameData)
        {
            gameData.models = CreateModels();
            gameData.lightSources = CreateIllumination();
            AddLightModelsToRenderList(gameData);
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
            List<Model> models = new List<Model> { CreateCone() };
//            gameObjects.models.Add(CreateSphere());
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