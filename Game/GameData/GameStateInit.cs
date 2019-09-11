using System.Collections.Generic;
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
            var gameData = new GameData(CreateModels(), CreateCamera(), CreateCameras(), CreateIllumination(),
                CreateLightningModel(), CreatePlayer());
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

        private static Model CreatePlayer()
        {
            return CreateCone();
//            return CreateSphere();
        }

        private static List<Model> CreateModels()
        {
            var models = new List<Model>();

//            models.Add(CreateSphere());
//            models.Add(CreateCone());

            return models;
        }

        private static Cone CreateCone()
        {
            var cone = CreateCone(new Vector(-5, 0, 0, 1), new Vector(1.0, 1.0, 1.0), new Vector(0, 1, 0), 0);

            return cone;
        }

        private static Cone CreateCone(Vector translationVector, Vector scaleVector, Vector rotationVector,
            double rotationAngle)
        {
            var cone = new Cone
            {
                translationVector = translationVector,
                scaleVector = scaleVector,
                rotationVector = rotationVector,
                rotationAngle = rotationAngle
            };

            return cone;
        }

        private Cone CreateCone(Color color, Vector translationVector, Vector scaleVector, Vector rotationVector,
            double rotationAngle)
        {
            var cone = new Cone(color)
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
            var sphere = new Sphere
            {
                translationVector = new Vector(0, 0, 0, 1),
                scaleVector = new Vector(1, 1, 1.0),
                rotationVector = new Vector(0, 0, 1),
                rotationAngle = 0
            };

            return sphere;
        }


        private static Camera.Camera CreateCamera()
        {
            return new Camera.Camera(new Vector(5.0, 0.0, 0.0), new Vector(-1.0, 0.0, 0.0), new Vector(0.0, 0.0, -1.0),
                1);
        }

        private static Cameras CreateCameras()
        {
            return new Cameras(CameraMode.StationaryCamera);
        }

        private static List<LightSource> CreateIllumination()
        {
            var lightSources = new List<LightSource> {CreateLamp()};

            return lightSources;
        }

        private static void AddLightModelsToRenderList(GameData gameData)
        {
            foreach (var lightObject in gameData.lightSources)
            {
                gameData.models.Add(lightObject.model);
            }
        }

        private static LightSource CreateLamp()
        {
            return new Lamp(CreateLightSource());
        }

        private static LightSource CreateLightSource()
        {
            //TODO when you change x coordinate zBuffer is being drawn wrongly
            //TODO fix, when cube is located near camera like (9.9, 0, 0) game freezes/ have exception or just simply take long to draw one frame
            var translationVector = new Vector(2.0, 2.0, 2.0, 1);
            var scaleVector = new Vector(1.0, 1.0, 1.0);
            var rotationVector = new Vector(0, 1, 0);
            const double rotationAngle = 0.0;

//            Cone cone = CreateCone(new Color(1.0, 1.0, 1.0), translationVector, scaleVector, rotationVector, rotationAngle);
            var cone = CreateCone(translationVector, scaleVector, rotationVector, rotationAngle);
            var ambientLight = CreateAmbientLight();
            var diffuseLight = CreateDiffuseLight();
            var specularLight = CreateSpecularLight();
            
            return new LightSource(cone, ambientLight, diffuseLight, specularLight);
        }

        private static Light CreateAmbientLight()
        {
            var ambientLight = new Light(new Color(1.0, 1.0, 1.0), 0.1);

            return ambientLight;
        }

        private static Light CreateDiffuseLight()
        {
            var diffuseLight = new Light(new Color(1.0, 1.0, 1.0));
            return diffuseLight;
        }

        private static Light CreateSpecularLight()
        {
            var specularLight = new Light(new Color(1.0, 1.0, 1.0));
            return specularLight;
        }

        private static ILightningModel CreateLightningModel()
        {
            return new PhongLighting();
        }

        private static Flashlight CreateFlashlight()
        {
            
            var spotDir = new Vector();
            var cutoffAngle = Math.Math.ConvertDegreesToRadians(30);
            var lightSource = CreateLightSource();
            var flashlight = new Flashlight(lightSource, spotDir, cutoffAngle);

            return flashlight;
        }
        
    }
}