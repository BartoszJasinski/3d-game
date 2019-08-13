using System.Collections.Generic;
using System.Linq;
using Game.Lightning.LightningObject;
using Game.Lightning.LightningModel;
using Game.Lightning;
using Game.Camera;
using Game.Figure;
using Game.IO;
using Game.Math;

namespace Game.GameData
{
    public class GameStateInit
    {
        
        public GameData InitializeGameData()
        {
            GameData gameData = new GameData(CreateModels(), CreateCamera(), CreateCameras(), CreateIllumination(), CreateLightningModel(), CreatePlayer());
//            gameData.player = gameData.models.First();
            AddLightModelsToRenderList(gameData);

            return gameData;
        }
        
        public static Mouse InitializeMouse()
        {
            var initializedMouse = new Mouse {Yaw = 180.0f, Pitch = 0.0f};

            return initializedMouse;
        }
        
        public static Keyboard InitializeKeyboard()
        {
            return new Keyboard();
        }

        private Model CreatePlayer()
        {
            return CreateCone();
//            return CreateSphere();

        }
        
        private static List<Model> CreateModels()
        {
            var models = new List<Model> {};
            
//            models.Add(CreateSphere());
//            models.Add(CreateCone());
            
            return models;
        }
        
        private Cone CreateCone()
        {
            var cone = CreateCone(new Vector(-5, 0, 0, 1), new Vector(1.0, 1.0, 1.0), new Vector(0, 1, 0), 0);
//            cone.translationVector = ;
//            cone.scaleVector = ;
//            cone.rotationVector = ;
//            cone.rotationAngle = 0;
            
            return cone;
        }
        
        private static Cone CreateCone(Vector translationVector, Vector scaleVector, Vector rotationVector, double rotationAngle)
        {
            Cone cone = new Cone();
            cone.translationVector = translationVector;
            cone.scaleVector = scaleVector;
            cone.rotationVector = rotationVector;
            cone.rotationAngle = rotationAngle;
            
            return cone;
        }
        
        private Cone CreateCone(Color color, Vector translationVector, Vector scaleVector, Vector rotationVector, double rotationAngle)
        {
            Cone cone = new Cone(color)
            {
                translationVector = translationVector,
                scaleVector = scaleVector,
                rotationVector = rotationVector,
                rotationAngle = rotationAngle
            };

            return cone;
        }
        
        private Sphere CreateSphere()
        {
            Sphere sphere = new Sphere();
            sphere.translationVector = new Vector(0, 0, 0, 1);;
            sphere.scaleVector = new Vector(1, 1, 1.0);
            sphere.rotationVector = new Vector(0, 0, 1);
            sphere.rotationAngle = 0;
            
            return sphere;
        }
        
        
        private static Camera.Camera CreateCamera()
        {
            return new Camera.Camera(new Vector(5.0, 0.0, 0.0), new Vector(-1.0, 0.0, 0.0), new Vector(0.0, 0.0, -1.0), 1);
        }
        
        private static Cameras CreateCameras()
        {
            return new Cameras(CameraMode.StationaryCamera);
        }
        
        private List<LightSource> CreateIllumination()
        {
            var lightSources = new List<LightSource> { CreateLamp() };
            
            return lightSources;
        }
        
        private static void AddLightModelsToRenderList(GameData gameData)
        {
            foreach (var lightObject in gameData.lightSources)
            {
                gameData.models.Add(lightObject.model);
            }
        }

        private LightSource CreateLamp()
        {
            //TODO when you change x coordinate zBuffer is being drawn wrongly
            //TODO fix, when cube is located near camera like (9.9, 0, 0) game freezes/ have exception or just simply take long to draw one frame
            Vector translationVector = new Vector(2.0, 2.0, 2.0, 1);
            Vector scaleVector = new Vector(1.0, 1.0, 1.0);
            Vector rotationVector = new Vector(0, 1, 0);
            double rotationAngle = 0.0;
            
//            Cone cone = CreateCone(new Color(1.0, 1.0, 1.0), translationVector, scaleVector, rotationVector, rotationAngle);
            Cone cone = CreateCone(translationVector, scaleVector, rotationVector, rotationAngle);
            Light ambientLight = CreateAmbientLight();
            Light diffuseLight = CreateDiffuseLight();
            Light specularLight = CreateSpecularLight();
            
            return new Lamp(cone, ambientLight, diffuseLight, specularLight);
        }

        private static Light CreateAmbientLight()
        {
            Light ambientLight = new Light(new Color(1.0, 1.0, 1.0), 0.1);

            return ambientLight;
        }
        
        private static Light CreateDiffuseLight()
        {
            Light diffuseLight = new Light(new Color(1.0, 1.0, 1.0));
            return diffuseLight;
        }

        private static Light CreateSpecularLight()
        {
            Light specularLight = new Light(new Color(1.0, 1.0, 1.0));
            return specularLight;
        }

        private static ILightningModel CreateLightningModel()
        {
            return new PhongLighting();
        }


    }
}