using System.Collections.Generic;

using Game.Camera;
using Game.Figure;
using Game.Lightning;
using Game.Lightning.LightningModel;
using Game.Lightning.LightningObject;
using Game.Math;

namespace Game.GameData
{
    public class GameDataInit
    {
        
        public GameData InitializeGameData()
        {
            GameData gameData = new GameData(CreateModels(), CreateCamera(), CreateCameras(), CreateIllumination(), new PhongLighting());

            AddLightModelsToRenderList(gameData);

            return gameData;
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
        
        private Cone CreateCone(Color color, Vector translationVector, Vector scaleVector, Vector rotationVector, double rotationAngle)
        {
            Cone cone = new Cone(color);
            cone.translationVector = translationVector;
            cone.scaleVector = scaleVector;
            cone.rotationVector = rotationVector;
            cone.rotationAngle = rotationAngle;
            
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

      
        private Camera.Camera CreateCamera()
        {
            return new Camera.Camera(new Vector (10.0, 0.0, 0.0), new Vector (-1.0, 0.0, 0.0), new Vector(0.0, 0.0, 1.0), 1);
        }
        
        private Cameras CreateCameras()
        {
            return new Cameras();
        }

        private List<ILightningObject> CreateIllumination()
        {
            List<ILightningObject> lightSources = new List<ILightningObject> { CreateLamp() };
            
            return lightSources;
        }
        
        private void AddLightModelsToRenderList(GameData gameData)
        {
            foreach (var lightObject in gameData.lightObjects)
            {
                gameData.models.Add(lightObject.model);
            }
        }

        private ILightningObject CreateLamp()
        {
            Vector translationVector = new Vector(5.0, 0.0, 0.0);
            Vector scaleVector = new Vector(1.0, 1.0, 1.0);
            Vector rotationVector = new Vector(0.0, 0.0, 1.0);;
            double rotationAngle = 0.0;
            
            Cone cone = CreateCone(new Color(1.0, 1.0, 1.0), translationVector, scaleVector, rotationVector, rotationAngle);
            
            return new Lamp(cone, new LightSource(new Light(new Color(1.0, 1.0, 1.0))));
        }
        
        private LightSource CreateLightSource()
        {
            return new LightSource(new Light(new Color(1.0, 1.0, 1.0)));
        }
        
   
        
        


    }
}