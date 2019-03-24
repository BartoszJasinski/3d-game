using System.Drawing;
using System.Windows.Forms;

using Game.Math;
using Game.Figure;
using Game.Perspective;

namespace Game.Render
{
    public class Render
    {
        //TODO: create timer so object move with the same speed on computers with differens speed of computation
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
            phi += 0.0;

            model.rotationAngle = phi;
            model.modelMatrix = model.Transform();

            gameData.camera.viewMatrix = gameData.cameras.GetCamera(gameData.camera);

            DrawModelTriangles(e, gamePictureBox, gameData, model);
            
            Debug.Debug.PrintDebugGameData(e.Graphics, gameData);
        }
        
 

        //TODO: implement fragShader and vertexShader
        //TODO: bug with rendering is probably here (because when model is behind it should not be drawn)
        void DrawModelTriangles(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData, Model model)
        {
            foreach(Triangle triangle in model.triangles)
            {
                Vector p1e = Projection.ProjectionMatrix * gameData.camera.viewMatrix * model.modelMatrix * triangle.firstVertex.position;
                Vector p2e = Projection.ProjectionMatrix * gameData.camera.viewMatrix * model.modelMatrix * triangle.secondVertex.position;
                Vector p3e = Projection.ProjectionMatrix * gameData.camera.viewMatrix * model.modelMatrix * triangle.thirdVertex.position;
                
                Algorithms.ProjectedTriangle projectedTriangle = new Algorithms.ProjectedTriangle(p1e, p2e, p3e);
                projectedTriangle = projectedTriangle.ProjectTriangle(gamePictureBox.Width, gamePictureBox.Height);
                
                //TODO: fix tirangle.verticec[0] because it is not fragPosition probably
                Vector fragPosition = model.modelMatrix * triangle.vertices[1].position;
                Vector triangleNormal = model.modelMatrix * triangle.vertices[1].normal;
//                Color triangleColor = Lightning.Lightning.ApplyLightning(gameData, triangle, fragPosition, triangleNormal);
                Color triangleColor = Lightning.Lightning.ApplyLightning(gameData, triangle, fragPosition, triangleNormal);
                
//                ScanLineFillVertexSort(p1_x_prim, p1_y_prim, p2_x_prim, p2_y_prim, p3_x_prim, p3_y_prim, triangleColor, e, p3e.z, triangle, p1e.x, p1e.y, p1e.z, p2e.x, p2e.y, p2e.z, p3e.x, p3e.y, p3e.z);
                //Backface Culling
                if((fragPosition - gameData.camera.cameraPosition).DotProduct(triangleNormal) > 0)
                    algorithms.ScanLineFillVertexSort(e, triangleColor, projectedTriangle);

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