using System;
using System.Windows.Forms;
using Game.GameData;
using GlmNet;


namespace Game
{
    public partial class GameWindow : Form
    {

        DateTime startTime = DateTime.Now;
        GameData.GameData gameData;
        private Render.Render renderer = new Render.Render();
        private GameDataInit gameDataInit = new GameDataInit();
        public GameWindow()
        {
            InitializeComponent();
            
            Init();
            
            
        }

        private void Init()
        {
            gamePictureBox.BackColor = System.Drawing.Color.Black;
            
            gameData = new GameData.GameData();
            
            gameDataInit.InitializeGameObjects(gameData);
            InitializeTimer();
            startTime = DateTime.Now;
        }


        

       
        private void gamePictureBox_Click(object sender, EventArgs e)
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

        private void gamePictureBox_Paint(object sender, PaintEventArgs e)
        {
            renderer.RenderModels(e, gamePictureBox, gameData);
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

       




    }
}
