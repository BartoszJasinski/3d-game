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
        //TODO: create timer so object move with the same speed on computers with differens speed of computation
        private Algorithms algorithms = new Algorithms();
  
        private double phi;

        public void RenderModels(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData/*, Mouse mouse*/) //DEBUG mouse DELETE mouse arguement after dubugging
        {

            foreach(Model model in gameData.models)
                RenderModel(e, gamePictureBox, gameData, model/*, mouse*/);

            algorithms.DepthTesting(gamePictureBox);

        }

        void RenderModel(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData, Model model/*, Mouse mouse*/) //DEBUG mouse DELETE mouse arguement after dubugging
        {
            phi += 0.05;

            model.rotationAngle = phi;
            model.rotationVector = new Vector(0, 0, 1);
//            model.translationVector.z = phi;
//            gameData.player.translationVector.z = phi;
            model.modelMatrix = model.Transform();

            gameData.camera.viewMatrix = gameData.cameras.GetCamera(gameData);

            DrawModelTriangles(e, gamePictureBox, gameData, model);
            
            Debug.PrintDebugGameData(e.Graphics, gameData/*, mouse*/);
        }

        //TODO: check later if it is correct (normal vectors may have bad ornientation) and uncomment
        public bool BackfaceCulling(Vector fragPosition, Vector cameraPosition, Vector triangleNormal)
        {
            return true;
            return (fragPosition.CastVectorTo3D() - cameraPosition).CastVectorTo3D().DotProduct(triangleNormal.CastVectorTo3D()) > 0;
        }
        
        //TODO: implement fragShader and vertexShader
        //TODO: bug with rendering is probably here (because when model is behind it should not be drawn)
        void DrawModelTriangles(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData, Model model)
        {
            foreach(Triangle triangle in model.triangles)
            {
                //TODO: fix tirangle.verticec[0] because it is not fragPosition probably
                //TODO: maybe fragposiotion should be 3D vector
                Vector fragPosition = model.modelMatrix * triangle.vertices[1].position;
//                Vector triangleNormal = model.modelMatrix * triangle.vertices[1].normal.Cast3DVectorTo4D();
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

//                    Algorithms.ProjectedTriangle projectedTriangle = new Algorithms.ProjectedTriangle(p1e, p2e, p3e);
//                    projectedTriangle = projectedTriangle.ProjectTriangle(gamePictureBox.Width, gamePictureBox.Height);
                    Algorithms.ProjectedTriangle projectedTriangle = new Algorithms.ProjectedTriangle(p1e, p2e, p3e);
                    //TODO: refactor
                    Tuple<Algorithms.ProjectedTriangle, bool> returnedValue = projectedTriangle.ProjectTriangle(gamePictureBox.Width, gamePictureBox.Height);
                    projectedTriangle = returnedValue.Item1;
                    
                    //TODO: refactor
                    if (returnedValue.Item2)
                    {
//                        Color triangleColor =
//                            Lightning.Lightning.ApplyLightning(gameData, triangle, fragPosition, triangleNormal);
                        var col =
                            Lightning.Lightning.ApplyLightning(gameData, triangle, fragPosition, triangleNormal);
                        Color triangleColor = col;

                        algorithms.ScanLineFillVertexSort(e, triangleColor, projectedTriangle);
                    }
                    

                }

//                e.Graphics.DrawLine(Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p2_x_prim, (float)p2_y_prim);
//                e.Graphics.DrawLine(Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p3_x_prim, (float)p3_y_prim);
//                e.Graphics.DrawLine(Pens.Black, (float)p2_x_prim, (float)p2_y_prim, (float)p3_x_prim, (float)p3_y_prim);

//                MyDrawLine(e, Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p2_x_prim, (float)p2_y_prim);
//                MyDrawLine(e, Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p3_x_prim, (float)p3_y_prim);
//                MyDrawLine(e, Pens.Black, (float)p2_x_prim, (float)p2_y_prim, (float)p3_x_prim, (float)p3_y_prim);


            }
            
        }

    }
}