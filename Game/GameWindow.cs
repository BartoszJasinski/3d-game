using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Game.Figure;
using Game.Lightning;
using GlmNet;
using static System.Math;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

using Game.Matrix;
using Game.Camera;
using Color = Game.Lightning.Color;


namespace Game
{
    public partial class GameWindow : Form
    {
        double[,] zBuffer;

        double phi = 0;
        DateTime startTime = DateTime.Now;
        GameObjects gameObjects;
        public GameWindow()
        {
            InitializeComponent();
            
            Init();
            
            
        }

        private void Init()
        {
            gamePictureBox.BackColor = System.Drawing.Color.Black;
            
            zBuffer = new double[gamePictureBox.Width, gamePictureBox.Height];

            for(int x = 0; x < zBuffer.GetLength(0); x++)
            for(int y = 0; y < zBuffer.GetLength(1); y++)
                zBuffer[x, y] = Double.MaxValue;
            
            gameObjects = new GameObjects();
            
            InitializeGameObjects(gameObjects);
            InitializeTimer();
            startTime = DateTime.Now;
        }

        private void InitializeGameObjects(GameObjects gameObjects)
        {
            gameObjects.models = CreateModels();
            gameObjects.lightSources = CreateLightSources();
        }

        private List<LightSource> CreateLightSources()
        {
            List<LightSource> lightSources = new List<LightSource> { createLightSource() };

            return lightSources;
        }

        private LightSource createLightSource()
        {
            return new LightSource(new Light());
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            gamePictureBox.Invalidate();
        }

        private void InitializeTimer()
        {
            Timer tm = new Timer {Interval = 1};
            tm.Tick += timerTick;
            gamePictureBox.Invalidate();
            tm.Enabled = true;
            tm.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            gamePictureBox.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            RenderModels(e, gameObjects);
        }

        
        void RenderModels(PaintEventArgs e, GameObjects gameObjects)
        {
            foreach(Model model in gameObjects.models)
                RenderModel(e, gameObjects, model);
        }

        
        void RenderModel(PaintEventArgs e, GameObjects gameObjects, Model model)
        {

            phi += 0.007;
//            Vector<double> modelPosition = new DenseVector(new double[] {Cos(phi), Sin(phi), 0});
//            model.modelMatrix = model.Transformate(new DenseVector(new double[] {Cos(phi), Sin(phi), Cos(phi)}), modelPosition, 1, modelPosition);
            Vector<double> modelPosition = new DenseVector(new double[] {0, 0, 0});
            Vector<double> scaleVector = new DenseVector(new double[] { 5, 5, 1});
            Vector<double> rotationVector = modelPosition;
            double rotationAngle = 10;
            Vector<double> translationVector = modelPosition;
            model.modelMatrix = model.Transformate(scaleVector, rotationVector, rotationAngle, translationVector);

//Stationary Camera
            Vector<double> cameraPosition = new DenseVector(new[] {5, 1.0, 1.0});
            Vector<double> cameraTarget = new DenseVector(new[] {0, 1.0, 1.0});
            Vector<double> upAxis = new DenseVector(new[] {0.0, 0.0, 1.0});
            gameObjects.camera.ViewMatrix = Camera.Camera.LookAt(cameraPosition, cameraTarget, upAxis);

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


            DrawModelTriangles(e, gameObjects, model);

        }

        void DrawModelTriangles(PaintEventArgs e, GameObjects gameObjects, Model model)
        {
            foreach(Triangle triangle in model.triangles)
            {
                Vector<double> p1 = DenseVector.OfArray(new double[]
                    { triangle.firstVertex.x, triangle.firstVertex.y, triangle.firstVertex.z, triangle.firstVertex.w });
                Vector<double> p2 = DenseVector.OfArray(new double[]
                    { triangle.secondVertex.x, triangle.secondVertex.y, triangle.secondVertex.z, triangle.secondVertex.w });
                Vector<double> p3 = DenseVector.OfArray(new double[]
                    { triangle.thirdVertex.x, triangle.thirdVertex.y, triangle.thirdVertex.z, triangle.thirdVertex.w });
                
                
                Vector<double> p1e = Matrix.Matrixes.ProjectionMatrix * gameObjects.camera.ViewMatrix * model.modelMatrix * p1;
                Vector<double> p2e = Matrix.Matrixes.ProjectionMatrix * gameObjects.camera.ViewMatrix * model.modelMatrix * p2;
                Vector<double> p3e = Matrix.Matrixes.ProjectionMatrix * gameObjects.camera.ViewMatrix * model.modelMatrix * p3;
               
                
                double p1_x_prim = p1e[0] / p1e[3];
                double p1_y_prim = p1e[1] / p1e[3];

                double p2_x_prim = p2e[0] / p2e[3];
                double p2_y_prim = p2e[1] / p2e[3];

                double p3_x_prim = p3e[0] / p3e[3];
                double p3_y_prim = p3e[1] / p3e[3];

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


                System.Drawing.Color triangleColor = ApplyLightning(gameObjects.lightSources, triangle).ToSystemColor();
                ScanLineFillVertexSort(p1_x_prim, p1_y_prim, p2_x_prim, p2_y_prim, p3_x_prim, p3_y_prim, triangleColor, e);

                e.Graphics.DrawLine(Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p2_x_prim, (float)p2_y_prim);
                e.Graphics.DrawLine(Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p3_x_prim, (float)p3_y_prim);
                e.Graphics.DrawLine(Pens.Black, (float)p2_x_prim, (float)p2_y_prim, (float)p3_x_prim, (float)p3_y_prim);

            }
        }

        Lightning.Color ApplyLightning(List<LightSource> lightSources, Triangle triangle)
        {
            Vector<double> colorVector = Misc.Math.PointwiseMultiply(lightSources[0].light.lightColor.rgb,
                DenseVector.OfArray(new double[] {triangle.Color.R, triangle.Color.G, triangle.Color.B}));
            return new Lightning.Color(colorVector);
        }

        
        
        void PrintMatrix(mat4 matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        
        
//        void SecondCube(object sender, PaintEventArgs e)
//        {
//            Matrix<double> ModelMatrix = DenseMatrix.OfArray(new double[,] {
//                {Math.Cos(phi), -Math.Sin(phi), 0, 0},
//                {Math.Sin(phi), Math.Cos(phi), 0, 0},
//                {0, 0, 1, 0},
//                {0, 0, 0, 1}});
//
//            Graphics g = e.Graphics;
//            foreach (Triangle triangle in cone.triangles)
//            {
//
//                Vector<double> p1 = DenseVector.OfArray(new double[]
//                    { triangle.firstVertex.x, triangle.firstVertex.y, triangle.firstVertex.z, triangle.firstVertex.w });
//                Vector<double> p2 = DenseVector.OfArray(new double[]
//                    { triangle.secondVertex.x, triangle.secondVertex.y, triangle.secondVertex.z, triangle.secondVertex.w });
//                Vector<double> p3 = DenseVector.OfArray(new double[]
//                    { triangle.thirdVertex.x, triangle.thirdVertex.y, triangle.thirdVertex.z, triangle.thirdVertex.w });
//
//
//                Vector<double> p1e = Matrix.Matrixes.ProjectionMatrix * Matrix.Matrixes.ViewMatrix * ModelMatrix * p1;
//                Vector<double> p2e = Matrix.Matrixes.ProjectionMatrix * Matrix.Matrixes.ViewMatrix * ModelMatrix * p2;
//                Vector<double> p3e = Matrix.Matrixes.ProjectionMatrix * Matrix.Matrixes.ViewMatrix * ModelMatrix * p3;
//
//                double p1_x_prim = p1e[0] / p1e[3];
//                double p1_y_prim = p1e[1] / p1e[3];
//
//                double p2_x_prim = p2e[0] / p2e[3];
//                double p2_y_prim = p2e[1] / p2e[3];
//
//                double p3_x_prim = p3e[0] / p3e[3];
//                double p3_y_prim = p3e[1] / p3e[3];
//
//                p1_x_prim += 1;
//                p1_x_prim /= 2;
//                p1_x_prim *= pictureBox1.Width;
//                p1_y_prim += 1;
//                p1_y_prim /= 2;
//                p1_y_prim *= pictureBox1.Height;
//
//                p2_x_prim += 1;
//                p2_x_prim /= 2;
//                p2_x_prim *= pictureBox1.Width;
//                p2_y_prim += 1;
//                p2_y_prim /= 2;
//                p2_y_prim *= pictureBox1.Height;
//
//                p3_x_prim += 1;
//                p3_x_prim /= 2;
//                p3_x_prim *= pictureBox1.Width;
//                p3_y_prim += 1;
//                p3_y_prim /= 2;
//                p3_y_prim *= pictureBox1.Height;
//
////                ScanLineFillVertexSort(p1_x_prim, p1_y_prim, p2_x_prim, p2_y_prim, p3_x_prim, p3_y_prim, triangle.color, e);
//
//                g.DrawLine(Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p2_x_prim, (float)p2_y_prim);
//                g.DrawLine(Pens.Black, (float)p1_x_prim, (float)p1_y_prim, (float)p3_x_prim, (float)p3_y_prim);
//                g.DrawLine(Pens.Black, (float)p2_x_prim, (float)p2_y_prim, (float)p3_x_prim, (float)p3_y_prim);
//
//            }
//        }




        //    void FillTriangle(Triangle t)
        //{
        //    /*
        //        for x,y
        //        z = interpolaja()
        //        color = GetCoolor()
                
        //    */
        //}
        
        //Pens GetColor()
        //{
            
        //}
        



       

//        List<Triangle> GetSpherePoints()
//        {
//            Random rand = new Random();
//
//            Point3D p1, p2, p3, p4;
//            Triangle triangle;
//            double Angle = 30f / 180 * Math.PI;
//            double R = 0.1;
//            double Alpha = 0;
//            double Beta = 0;
//            double height = 1;
//            double kat = Math.PI / 4;
//            Point3D p0 = new Point3D(1, 1, 1, 1);
//            List<Triangle> triangles = new List<Triangle>();
//            p1 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta));
//            p2 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle));
//
////            p1 = new Point3D(R * Cos(Angle) * Sin(Alpha), R * Sin(Angle) * Cos(Alpha), R/* * Sin(Alpha)*/);
////            p2 = new Point3D(R * Cos(Angle) * Cos(Alpha + Angle), R * Sin(kat) * Cos(Alpha + Angle), R/* * Sin(Alpha + Angle)*/);
//            while (Beta <= Math.PI / 2)
//            {
//                while (Alpha <= Math.PI * 2)
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
//
//            Beta += Angle;
//            Alpha = 0;
//
//            //for (i = 0; i < n; i++)
//            //{
//            //    printf("%f %f\n", x + r * Math.cos(2 * Math.PI * i / n), y + r * Math.sin(2 * Math.PI * i / n));
//            //}
//
//
//            Beta = 0;
//            Alpha = 0;
//            while (Beta >= -Math.PI / 2)
//            {
//                while (Alpha <= Math.PI * 2)
//                {
//                    p3 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta), 1);
//                    p4 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
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

        public class Vertex
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

        static void ScanLineFillVertexSort(double p1_x_prim, double p1_y_prim, double p2_x_prim, double p2_y_prim, double p3_x_prim, double p3_y_prim, System.Drawing.Color color, PaintEventArgs e)
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
                for (int i = 0; i < AET.Count / 2; i++)
                    e.Graphics.DrawLine(new Pen(color), new Point((int)AET[2 * i].x, y), new Point((int)AET[2 * i + 1].x, y));

                for (int i = 0; i < AET.Count; i++)
                {

                    AET[i].x += AET[i].mInverse;
                    if (double.IsInfinity(AET[i].mInverse))
                        AET[i].x = polygonVertexes[AET[i].secondVertexIndex].point.X;
                }

            }
        }



        private static void SetPixel(PaintEventArgs e, Brush brush, Point point)
        {
            e.Graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
        }

        static int MathMod(int a, int b)
        {
            return (Math.Abs(a * b) + a) % b;
        }





    }
}
