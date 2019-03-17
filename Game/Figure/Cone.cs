using System;
using System.Collections.Generic;
using System.Drawing;

using static System.Math;


namespace Game.Figure
{
    public class Cone : Model, IModel
    {

        public Cone()
        {
             Random rand = new Random();

            Vertex p1, p2, p3, p4;
            Triangle triangle;
            double Angle = 30f / 180 * PI;
            double R = 0.1;
            double Alpha = 0;
            double Beta = 0;
            double height = 1;
            double kat = PI / 4;
            Vertex p0 = new Vertex(1, 1, 1, 1);
            List<Triangle> triangles = new List<Triangle>();
            p1 = new Vertex(0, 0, height, 1);
            //p1 = new Point4D(height * Cos(kat) * Sin(Alpha), height * Sin(kat) * Cos(Alpha), height/* * Sin(Alpha)*/, 1);
            //p2 = new Point4D(height * Cos(kat) * Cos(Alpha + Angle), height * Sin(kat) * Cos(Alpha + Angle), height/* * Sin(Alpha + Angle)*/, 1);
            while (Alpha <= PI * 2)
            {

                p3 = new Vertex(R * Cos(Alpha), R * Sin(Alpha), 0, 1);
                p4 = new Vertex(R * Cos(Alpha + Angle), R * Sin(Alpha + Angle), 0, 1);
                //p3 = new Point4D(height * Cos(kat + Angle) * Sin(Alpha), height * Sin(kat + Angle) * Cos(Alpha), height/* * Sin(Beta)*/, 1);
                //p4 = new Point4D(height * Cos(kat + Angle) * Cos(Alpha + Angle), height * Sin(kat + Angle) * Cos(Alpha + Angle), height /** Sin(Beta + Angle)*/, 1);
                //triangle = new Triangle(p1, p2, p3);
                //triangles.Add(triangle);

                
                    triangle = new Triangle(p1, p3, p4);
                    int r = rand.Next(255);
                    int g = rand.Next(255);
                    int b = rand.Next(255);
                    triangle.color = new Lightning.Color(r,g,b);
                    triangles.Add(triangle);
                    //p2 = p3;
                    p3 = p4;
                    Alpha += Angle;
            }
            Beta += Angle;
            Alpha = 0;

            //for (i = 0; i < n; i++)
            //{
            //    printf("%f %f\n", x + r * Math.cos(2 * Math.PI * i / n), y + r * Math.sin(2 * Math.PI * i / n));
            //}


            //Beta = 0;
            //Alpha = 0;
            //while (Beta >= -Math.PI / 2)
            //{
            //    while (Alpha <= Math.PI * 2)
            //    {
            //        p3 = new Point4D(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta), 1);
            //        p4 = new Point4D(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
            //        triangle = new Triangle(p1, p2, p3);
            //        triangles.Add(triangle);
            //        triangle = new Triangle(p2, p3, p4);
            //        triangles.Add(triangle);
            //        p1 = p3;
            //        p2 = p4;
            //        Alpha += Angle;
            //    }
            //    Beta -= Angle;
            //    Alpha = 0;
            //}

            this.triangles = triangles;

        }
        
        public Cone(Lightning.Color color)
        {
            Vertex p1, p2, p3, p4;
            Triangle triangle;
            double Angle = 30f / 180 * PI;
            double R = 0.1;
            double Alpha = 0;
            double Beta = 0;
            double height = 1;
            double kat = PI / 4;
            Vertex p0 = new Vertex(1, 1, 1, 1);
            List<Triangle> triangles = new List<Triangle>();
            p1 = new Vertex(0, 0, height, 1);
            //p1 = new Point4D(height * Cos(kat) * Sin(Alpha), height * Sin(kat) * Cos(Alpha), height/* * Sin(Alpha)*/, 1);
            //p2 = new Point4D(height * Cos(kat) * Cos(Alpha + Angle), height * Sin(kat) * Cos(Alpha + Angle), height/* * Sin(Alpha + Angle)*/, 1);
            while (Alpha <= PI * 2)
            {

                p3 = new Vertex(R * Cos(Alpha), R * Sin(Alpha), 0, 1);
                p4 = new Vertex(R * Cos(Alpha + Angle), R * Sin(Alpha + Angle), 0, 1);
                //p3 = new Point4D(height * Cos(kat + Angle) * Sin(Alpha), height * Sin(kat + Angle) * Cos(Alpha), height/* * Sin(Beta)*/, 1);
                //p4 = new Point4D(height * Cos(kat + Angle) * Cos(Alpha + Angle), height * Sin(kat + Angle) * Cos(Alpha + Angle), height /** Sin(Beta + Angle)*/, 1);
                //triangle = new Triangle(p1, p2, p3);
                //triangles.Add(triangle);

                
                    triangle = new Triangle(p1, p3, p4);
                    triangle.color = color;
                    triangles.Add(triangle);
                    //p2 = p3;
                    p3 = p4;
                    Alpha += Angle;
            }
            Beta += Angle;
            Alpha = 0;

            //for (i = 0; i < n; i++)
            //{
            //    printf("%f %f\n", x + r * Math.cos(2 * Math.PI * i / n), y + r * Math.sin(2 * Math.PI * i / n));
            //}


            //Beta = 0;
            //Alpha = 0;
            //while (Beta >= -Math.PI / 2)
            //{
            //    while (Alpha <= Math.PI * 2)
            //    {
            //        p3 = new Point4D(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta), 1);
            //        p4 = new Point4D(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
            //        triangle = new Triangle(p1, p2, p3);
            //        triangles.Add(triangle);
            //        triangle = new Triangle(p2, p3, p4);
            //        triangles.Add(triangle);
            //        p1 = p3;
            //        p2 = p4;
            //        Alpha += Angle;
            //    }
            //    Beta -= Angle;
            //    Alpha = 0;
            //}

            this.triangles = triangles;

        }
        
        public void AddTriangle(Triangle triangle)
        {
            triangles.Add(triangle);
        }

        public void UpdateCone(List<Triangle> triangles)
        {
            this.triangles = triangles;
        }



//         public List<Triangle> CreateModel()
//         {
//             Random rand = new Random();
//
//            Point3D p1, p2, p3, p4;
//            Triangle triangle;
//            double Angle = 30f / 180 * PI;
//            double R = 0.1;
//            double Alpha = 0;
//            double Beta = 0;
//            double height = 1;
//            double kat = PI / 4;
//            Point3D p0 = new Point3D(1, 1, 1, 1);
//            List<Triangle> triangles = new List<Triangle>();
//            p1 = new Point3D(0, 0, height, 1);
//            //p1 = new Point4D(height * Cos(kat) * Sin(Alpha), height * Sin(kat) * Cos(Alpha), height/* * Sin(Alpha)*/, 1);
//            //p2 = new Point4D(height * Cos(kat) * Cos(Alpha + Angle), height * Sin(kat) * Cos(Alpha + Angle), height/* * Sin(Alpha + Angle)*/, 1);
//            while (Alpha <= PI * 2)
//            {
//
//                p3 = new Point3D(R * Cos(Alpha), R * Sin(Alpha), 0, 1);
//                    p4 = new Point3D(R * Cos(Alpha+ Angle), R * Sin(Alpha + Angle), 0, 1);
//                //p3 = new Point4D(height * Cos(kat + Angle) * Sin(Alpha), height * Sin(kat + Angle) * Cos(Alpha), height/* * Sin(Beta)*/, 1);
//                //p4 = new Point4D(height * Cos(kat + Angle) * Cos(Alpha + Angle), height * Sin(kat + Angle) * Cos(Alpha + Angle), height /** Sin(Beta + Angle)*/, 1);
//                //triangle = new Triangle(p1, p2, p3);
//                //triangles.Add(triangle);
//                  
//                triangle = new Triangle(p1, p3, p4);
//                int r = rand.Next(255);
//                int g = rand.Next(255);
//                int b = rand.Next(255);
//                triangle.Color = new Lightning.Color(r, g, b);
//                triangles.Add(triangle);
//                //p2 = p3;
//                p3 = p4;
//                Alpha += Angle;
//            }
//            Beta += Angle;
//            Alpha = 0;
//
//            //for (i = 0; i < n; i++)
//            //{
//            //    printf("%f %f\n", x + r * Math.cos(2 * Math.PI * i / n), y + r * Math.sin(2 * Math.PI * i / n));
//            //}
//
//
//            //Beta = 0;
//            //Alpha = 0;
//            //while (Beta >= -Math.PI / 2)
//            //{
//            //    while (Alpha <= Math.PI * 2)
//            //    {
//            //        p3 = new Point4D(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta), 1);
//            //        p4 = new Point4D(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
//            //        triangle = new Triangle(p1, p2, p3);
//            //        triangles.Add(triangle);
//            //        triangle = new Triangle(p2, p3, p4);
//            //        triangles.Add(triangle);
//            //        p1 = p3;
//            //        p2 = p4;
//            //        Alpha += Angle;
//            //    }
//            //    Beta -= Angle;
//            //    Alpha = 0;
//            //}
//
//            return triangles;
//         }
    }
}