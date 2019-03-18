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
            GameData gameData = new GameData(CreateModels(), CreateCamera(), CreateCameras(), CreateIllumination(), CreateLightningModel());

//            AddLightModelsToRenderList(gameData);

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
        
        private ILightningModel CreateLightningModel()
        {
            List<LightSource> ambientLights = CreateAmbientLights();
            List<LightSource> diffuseLights = CreateDiffuseLights();
            List<LightSource> specularLights = CreateSpecularLights();

            return new PhongLighting(ambientLights, diffuseLights, specularLights);
        }

        private List<LightSource> CreateAmbientLights()
        {
            List<LightSource> ambientLights = new List<LightSource>();
            ambientLights.Add(CreateAmbientLight());

            return ambientLights;
        }

        private LightSource CreateAmbientLight()
        {
            Light light = new Light(new Color(1.0, 1.0, 1.0), 1.0);
            Vector position = new Vector(5, 0, 0);
            LightSource ambientLight = new LightSource(light, position);

            return ambientLight;
        }
        
        
        private List<LightSource> CreateDiffuseLights()
        {
            List<LightSource> diffuseLights = new List<LightSource>();
            diffuseLights.Add(new LightSource(new Light(new Color(1.0, 1.0, 1.0)), new Vector(0.0, 0.0, 0.0)));

            return diffuseLights;
        }


        private List<LightSource> CreateSpecularLights()
        {
            List<LightSource> specularLights = new List<LightSource>();
            specularLights.Add(new LightSource(new Light(new Color(1.0, 1.0, 1.0)), new Vector(0.0, 0.0, 0.0)));

            return specularLights;
        }
        


    }
}