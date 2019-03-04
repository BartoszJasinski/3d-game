using System;
using System.Windows.Forms;
using Game.GameData;
using Game.IO;


namespace Game
{
    public partial class GameWindow : Form
    {

        DateTime startTime = DateTime.Now;
        GameData.GameData gameData;
        private Render.Render renderer = new Render.Render();
        private GameDataInit gameDataInit = new GameDataInit();
        Keyboard keyboard = new Keyboard();
        public GameWindow()
        {
            InitializeComponent();
            
            Init();
            
            
        }

        private void Init()
        {
            gamePictureBox.BackColor = System.Drawing.Color.Black;
            
            gameData = new GameData.GameData();
            
            gameDataInit.InitializeGameData(gameData);
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

        private void gamePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
//            gamePictureBox.BackColor = System.Drawing.Color.Yellow;
//            e.X
        }

        private void GameWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            gameData.camera.cameraPosition = keyboard.ProcessKeyPress(gameData, e);
           
        }








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
