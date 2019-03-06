using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Game.Figure;
using Game.Perspective;
using MathNet.Numerics.LinearAlgebra;
using Color = Game.Lightning.Color;
using Vector = Game.Math.Vector;

namespace Game.Render
{
    public class Render
    {
        
        //TODO: zBuffer trhrows System.IndexOutOfRangeException: Index was outside the bounds of the array. when outside of window
        //TODO: make screenWidth and screenHeightchanging apropiate to screen size
        private const int screenWidth = 1097, screenHeight = 819;
        double[,] zBuffer = new double[screenWidth, screenHeight];
        private double phi = 0;
        public void DepthTesting(PictureBox gamePictureBox)
        {
            for (int x = 0; x < zBuffer.GetLength(0); x++)
            {
                for (int y = 0; y < zBuffer.GetLength(1); y++)
                {
                    zBuffer[x, y] = Double.MaxValue;
                }                
            }
            
            
            
        }
        
        public void RenderModels(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData)
        {
            foreach(Model model in gameData.models)
                RenderModel(e, gamePictureBox, gameData, model);
            
            DepthTesting(gamePictureBox);
        }

        
        void RenderModel(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData, Model model)
        {

            phi += 0.1;

//            Vector<double> modelPosition = new DenseVector(new double[] {Cos(phi), Sin(phi), 0});
//            model.modelMatrix = model.Transformate(new DenseVector(new double[] {Cos(phi), Sin(phi), Cos(phi)}), modelPosition, 1, modelPosition);
           //TODO: move all model vectors to Model class
//            Vector modelPosition = new Vector(0, 0, 0);
//            Vector scaleVector = new Vector(5, 5, 0.1);
//            Vector rotationVector = new Vector(0, 0, 1);
            model.rotationAngle = 0;
//            Vector translationVector = modelPosition;
            model.modelMatrix = model.Transform(model.scaleVector, model.rotationVector, model.rotationAngle, model.translationVector);

//Stationary Camera
//            Vector  cameraPosition = new Vector (5.0, 0.0, 0.0);
//            Vector  cameraTarget = new Vector (0, 0.0, 0.0);
//            Vector upAxis = new Vector(0.0, 0.0, -1.0);
            gameData.camera.viewMatrix = gameData.camera.LookAt(gameData.camera.cameraPosition, gameData.camera.cameraPosition + gameData.camera.cameraFront, gameData.camera.upAxis);

//Stationary Tracking Camera
//            Vector<double> cameraPosition = new DenseVector(new[] {3.0, 1.0, 1.0});
//            Vector<double> cameraTarget = modelPosition;
//            Vector<double> upAxis = new DenseVector(new[] {0.0, 0.0, 1.0});
//            Matrix.Matrixes.ViewMatrix = Camera.Camera.LookAt(cameraPosition, cameraTarget, upAxis);

//Moving Associated With Object Camera
//            Vector<double> cameraPosition = modelPosition;
//            Vector<double> cameraTarget = modelPosition;
//            Vector<double> upAxis = new DenseVector(new[] {0.0, 0.0, 1.0});
//            Vector<double> cameraOffset = new DenseVector(new [] {10.0, 0.0, 0.0});
//            Matrix.Matrixes.ViewMatrix = Camera.Camera.LookAt(cameraPosition + cameraOffset, cameraTarget, upAxis);


            DrawModelTriangles(e, gamePictureBox, gameData, model);

        }

        void DrawModelTriangles(PaintEventArgs e, PictureBox gamePictureBox, GameData.GameData gameData, Model model)
        {
            foreach(Triangle triangle in model.triangles)
            {
//                Vector<double> p1 = DenseVector.OfArray(new double[]
//                    { triangle.firstVertex.x, triangle.firstVertex.y, triangle.firstVertex.z, triangle.firstVertex.w });
//                Vector<double> p2 = DenseVector.OfArray(new double[]
//                    { triangle.secondVertex.x, triangle.secondVertex.y, triangle.secondVertex.z, triangle.secondVertex.w });
//                Vector<double> p3 = DenseVector.OfArray(new double[]
//                    { triangle.thirdVertex.x, triangle.thirdVertex.y, triangle.thirdVertex.z, triangle.thirdVertex.w });
                
                
                Vector p1e = Projection.ProjectionMatrix * gameData.camera.viewMatrix * model.modelMatrix * triangle.vertices[0].position;
                Vector p2e = Projection.ProjectionMatrix * gameData.camera.viewMatrix * model.modelMatrix * triangle.vertices[1].position;
                Vector p3e = Projection.ProjectionMatrix * gameData.camera.viewMatrix * model.modelMatrix * triangle.vertices[2].position;
               
                
                double p1_x_prim = p1e.x / p1e.w;
                double p1_y_prim = p1e.y / p1e.w;

                double p2_x_prim = p2e.x / p2e.w;
                double p2_y_prim = p2e.y / p2e.w;

                double p3_x_prim = p3e.x / p3e.w;
                double p3_y_prim = p3e.y / p3e.w;

                p1_x_prim += 1;
                p1_x_prim /= 2;
                p1_x_prim *= gamePictureBox.Width;
                p1_y_prim += 1;
                p1_y_prim /= 2;
                p1_y_prim *= gamePictureBox.Height;

                p2_x_prim += 1;
                p2_x_prim /= 2;
                p2_x_prim *= gamePictureBox.Width;
                p2_y_prim += 1;
                p2_y_prim /= 2;
                p2_y_prim *= gamePictureBox.Height;
                
                p3_x_prim += 1;
                p3_x_prim /= 2;
                p3_x_prim *= gamePictureBox.Width;
                p3_y_prim += 1;
                p3_y_prim /= 2;
                p3_y_prim *= gamePictureBox.Height;


//                System.Drawing.Color triangleColor = Game.Lightning.Lightning.ApplyLightning(gameData, triangle).ToSystemColor();
                //TODO: fix tirangle.verticec[0] because it is not fragPosition probably
                Vector fragPosition = model.modelMatrix * triangle.vertices[1].position;
//                System.Drawing.Color triangleColor = ApplyDiffuseLightning(triangle, fragPosition).ToSystemColor();
                Vector triangleNormal = model.modelMatrix * triangle.vertices[1].normal;
                System.Drawing.Color triangleColor = Lightning.Lightning.ApplyLightning(gameData, triangle, fragPosition, triangleNormal).ToSystemColor();
                
                ScanLineFillVertexSort(p1_x_prim, p1_y_prim, p2_x_prim, p2_y_prim, p3_x_prim, p3_y_prim, triangleColor, e, p3e.z);

//                e.Graphics.DrawLine(Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p2_x_prim, (float)p2_y_prim);
//                e.Graphics.DrawLine(Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p3_x_prim, (float)p3_y_prim);
//                e.Graphics.DrawLine(Pens.Black, (float)p2_x_prim, (float)p2_y_prim, (float)p3_x_prim, (float)p3_y_prim);

//                MyDrawLine(e, Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p2_x_prim, (float)p2_y_prim);
//                MyDrawLine(e, Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p3_x_prim, (float)p3_y_prim);
//                MyDrawLine(e, Pens.Black, (float)p2_x_prim, (float)p2_y_prim, (float)p3_x_prim, (float)p3_y_prim);



            }
        }

     
//        Lightning.Color ApplyLightning(List<LightSource> lightSources, Triangle triangle)
//        {
//            Vector<double> colorVector = Misc.Math.PointwiseMultiply(lightSources[0].light.lightColor.rgb,
//                DenseVector.OfArray(new double[] {triangle.Color.R, triangle.Color.G, triangle.Color.B}));
//            return new Lightning.Color(colorVector);
//        }
        
        
        
        private class Vertex
        {
            public Point point { get; set; }
            public int index { get; set; }

            public Vertex(Point point, int index)
            {
                this.point = point;
                this.index = index;
            }

        }

        public class AETData
        {
            public int yMax { get; set; }
            public double x { get; set; }
            public double mInverse { get; set; }
            public int firstVertexIndex { get; set; }
            public int secondVertexIndex { get; set; }
        }

        public void ScanLineFillVertexSort(double p1_x_prim, double p1_y_prim, double p2_x_prim, double p2_y_prim, double p3_x_prim, double p3_y_prim, System.Drawing.Color color, PaintEventArgs e, double z)
        {
            List<Vertex> polygonVertexes = new List<Vertex>();
            //for (int i = 0; i < 3; i++)
                polygonVertexes.Add(new Vertex(new Point((int)p1_x_prim, (int)p1_y_prim), 0));
                polygonVertexes.Add(new Vertex(new Point((int)p2_x_prim, (int)p2_y_prim), 1));
                polygonVertexes.Add(new Vertex(new Point((int)p3_x_prim, (int)p3_y_prim), 2));

            polygonVertexes = polygonVertexes.OrderBy(v => v.point.Y).ToList();
            int yMin = polygonVertexes[0].point.Y, yMax = polygonVertexes.Last().point.Y;

            List<AETData> AET = new List<AETData>();

            for (int y = yMin + 1; y < yMax; y++)
            {
                List<Vertex> vertexesLyingOnScanLine = polygonVertexes.FindAll(vertex => vertex.point.Y == (y - 1));
                foreach (Vertex vertex in vertexesLyingOnScanLine)
                {
                    int previousVertexIndex = MathMod(vertex.index - 1, polygonVertexes.Count);
                    Vertex previousVertex = polygonVertexes.Find(x => x.index == previousVertexIndex);
                    if (previousVertex.point.Y >= vertex.point.Y)
                    {
                        double mInverse = ((double)previousVertex.point.X - (double)vertex.point.X) / ((double)previousVertex.point.Y - (double)vertex.point.Y);
                        //mInverse = double.IsInfinity(mInverse) ? 0 : mInverse;
                        AET.Add(new AETData { yMax = previousVertex.point.Y, x = vertex.point.X, mInverse = mInverse, firstVertexIndex = previousVertexIndex, secondVertexIndex = vertex.index });
                    }
                    else
                        AET.RemoveAll(x => (x.firstVertexIndex == vertex.index && x.secondVertexIndex == previousVertexIndex) || (x.firstVertexIndex == previousVertexIndex && x.secondVertexIndex == vertex.index));

                    int nextVertexIndex = MathMod(vertex.index + 1, polygonVertexes.Count);
                    Vertex nextVertex = polygonVertexes.Find(x => x.index == nextVertexIndex);
                    if (nextVertex.point.Y >= vertex.point.Y)
                    {
                        double mInverse = ((double)nextVertex.point.X - (double)vertex.point.X) / ((double)nextVertex.point.Y - (double)vertex.point.Y);
                        //mInverse = double.IsInfinity(mInverse) ? 0 : mInverse;
                        AET.Add(new AETData { yMax = nextVertex.point.Y, x = vertex.point.X, mInverse = mInverse, firstVertexIndex = nextVertexIndex, secondVertexIndex = vertex.index });
                    }
                    else
                        AET.RemoveAll(x => (x.firstVertexIndex == vertex.index && x.secondVertexIndex == nextVertexIndex) || (x.firstVertexIndex == nextVertexIndex && x.secondVertexIndex == vertex.index));
                }

                AET.OrderBy(x => x.x);
//                for (int i = 0; i < AET.Count / 2; i++)
//                {
//                    e.Graphics.DrawLine(new Pen(color), new Point((int)AET[2 * i].x, y), new Point((int)AET[2 * i + 1].x, y));
//                }
                for (int i = 0; i < AET.Count / 2; i++)
                {
                    MyDrawLine(e, new Pen(color), new Point((int)AET[2 * i].x, y), new Point((int)AET[2 * i + 1].x, y), z);
                }

                foreach (var aetData in AET)
                {
                    aetData.x += aetData.mInverse;
                    if (double.IsInfinity(aetData.mInverse))
                        aetData.x = polygonVertexes[aetData.secondVertexIndex].point.X;
                }

            }
        }

      

        private static void SetPixel(PaintEventArgs e, Brush brush, Point point)
        {
            e.Graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
        }

        static int MathMod(int a, int b)
        {
            return (System.Math.Abs(a * b) + a) % b;
        }
        
        public void MyDrawLine(PaintEventArgs e, Pen pen,Point p1, Point p2, double z)
        {

//            line(e, p1.X, p1.Y, p2.X, p2.Y, pen.Brush, z);
            e.Graphics.DrawLine(pen, p1, p2);
        }


        public void line(PaintEventArgs e, int x, int y, int x2, int y2, Brush brush, double z)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = System.Math.Abs(w);
            int shortest = System.Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = System.Math.Abs(h);
                shortest = System.Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (x < 0 || x > screenWidth || y < 0 || y > screenHeight)
                {
                    
                }
                else
                {
                    if (z <= zBuffer[x, y])
                    {
                        e.Graphics.FillRectangle(brush, x, y, 1, 1);
                        zBuffer[x, y] = z;
                    }
                }
               
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }



    }
}