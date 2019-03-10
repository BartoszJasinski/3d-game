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
            return new Camera.Camera(new Vector (10.0, 0.0, 0.0), new Vector (-1.0, 0.0, 0.0), new Vector(0.0, 0.0, -1.0), 1);
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
            
            models.Add(CreateSphere());
            models.Add(CreateCone());
            
            return models;
        }

        private Cone CreateCone()
        {
            Cone cone = new Cone();
            Vector modelPosition = new Vector(100, 0, 0);
            cone.translationVector = modelPosition;
            cone.scaleVector = new Vector(1.0, 1.0, 1.0);
            cone.rotationVector = new Vector(0, 0, 1);
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

        
//             List<Triangle> GetSpherePoints()
//        {
//            Point3D p1, p2, p3, p4;
//            Triangle triangle;
//            double Angle = 10f / 180 * Math.PI;
//            double R = 1;
//            double Alpha = 0;
//            double Beta = 0;
//            List<Triangle> triangles = new List<Triangle>();
//
//            while (Beta < Math.PI / 2)
//            {
//                p1 = new Point3D(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta));
//                p2 = new Point3D(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle), R * Sin(Beta + Angle));
//                while (Alpha < Math.PI * 2)
//                {
//                    p3 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta));
//                    p4 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle));
//                    triangle = new Triangle(p1, p2, p3);
//                    triangles.Add(triangle);
//                    triangle = new Triangle(p2, p3, p4);
//                    triangles.Add(triangle);
//                    p1 = p3;
//                    p2 = p4;
//                    Alpha += Angle;
//                }
//                Beta += Angle;
//                Alpha = 0;
//            }
//            Beta = 0;
//            Alpha = 0;
//            while (Beta > -Math.PI / 2)
//            {
//                p1 = new Point3D(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta));
//                p2 = new Point3D(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle), R * Sin(Beta + Angle));
//                while (Alpha < Math.PI * 2)
//                {
//                    p3 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta));
//                    p4 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle));
//                    triangle = new Triangle(p1, p2, p3);
//                    triangles.Add(triangle);
//                    triangle = new Triangle(p2, p3, p4);
//                    triangles.Add(triangle);
//                    p1 = p3;
//                    p2 = p4;
//                    Alpha += Angle;
//                }
//                Beta -= Angle;
//                Alpha = 0;
//            }
//
//            return triangles;
//        }

        
        
        /*
               
             void FillTriangle(triangle t)
             {
                 loop ...
                     x,y = ...
                     z = interpolate
                     color = fragmentShader(x,y,tiangleColor)
                     if(z < ZBuffer[x,y]
                     {
                         setpixel(x,y)
                         ZBuffer[x,y] = z
                     }
             }
     
             Interpolacja z:
             x = a*xA + b*xB +c*xC
             y = a*yA + b*yB + c*yC
             1 = a + b + c
             a,b,c
             z = azA + bzB + czC
              */


    }
}