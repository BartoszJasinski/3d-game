using System;
using System.Drawing;
using System.Windows.Forms;

using Game.Math;
using Game.Figure;
using Game.GameDebug;
using Game.IO;
using Game.Perspective;

namespace Game.Render
{
    public class Render
    {
        private Algorithms algorithms = new Algorithms();
  
        private double phi;

        public void RenderModels(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData)
        {

            foreach(Model model in gameData.models)
                RenderModel(e, gamePictureBox, gameData, model);

            algorithms.DepthTesting(gamePictureBox);

        }

        void RenderModel(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData, Model model)
        {
            phi += 0.05;

            model.rotationAngle = phi;
            model.rotationVector = new Vector(0, 0, 1);
            gameData.player.translationVector.z = System.Math.Cos(phi);
            gameData.player.translationVector.y = System.Math.Sin(phi);
            model.modelMatrix = model.Transform();

            gameData.camera.viewMatrix = gameData.cameras.GetCamera(gameData);

            DrawModelTriangles(e, gamePictureBox, gameData, model);
            
            Debug.PrintDebugGameData(e.Graphics, gameData);
        }

        public bool BackfaceCulling(Vector fragPosition, Vector cameraPosition, Vector triangleNormal)
        {
            return true;
            return ((fragPosition.CastVectorTo3D() - cameraPosition).CastVectorTo3D().DotProduct(triangleNormal.CastVectorTo3D()) > 0);
        }
        
        void DrawModelTriangles(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData, Model model)
        {
            foreach(Triangle triangle in model.triangles)
            {
                Vector fragPosition = model.modelMatrix * triangle.vertices[2].position;
                Vector triangleNormal = model.modelMatrix * triangle.firstVertex.normal.Cast3DVectorTo4D();
                //Backface Culling
                if (BackfaceCulling(fragPosition, gameData.camera.cameraPosition, triangleNormal))
                {
                    Vector p1e = Projection.ProjectionMatrix * gameData.camera.viewMatrix * model.modelMatrix *
                                 triangle.firstVertex.position;
                    Vector p2e = Projection.ProjectionMatrix * gameData.camera.viewMatrix * model.modelMatrix *
                                 triangle.secondVertex.position;
                    Vector p3e = Projection.ProjectionMatrix * gameData.camera.viewMatrix * model.modelMatrix *
                                 triangle.thirdVertex.position;

                    Algorithms.ProjectedTriangle projectedTriangle = new Algorithms.ProjectedTriangle(p1e, p2e, p3e, triangle.color);
                    Tuple<Algorithms.ProjectedTriangle, bool> returnedValue = projectedTriangle.ProjectTriangle(gamePictureBox.Width, gamePictureBox.Height);
                    projectedTriangle = returnedValue.Item1;
                    
                    if (returnedValue.Item2)
                    {
                        var col =
                            Lightning.Lightning.ApplyLightning(gameData, triangle.color, fragPosition, triangleNormal);
                        Color triangleColor = col;

                        algorithms.ScanLineFillVertexSort(e, projectedTriangle, gameData, triangleColor);
                    }
                    

                }


            }
            
        }

    }
}