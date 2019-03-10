using System;
using static System.Math;
using System.Collections.Generic;

using Game.Math;

namespace Game.Figure
{
    class Sphere: Model, IModel
    {

        public Sphere()
        {
            Random rand = new Random();
            Vertex p1, p2, p3, p4;
            Triangle triangle;
            double Angle = 30f / 180 * PI;
            double R = 0.5;
            double Alpha = 0;
            double Beta = 0;
            List<Triangle> triangles = new List<Triangle>();
            p1 = new Vertex(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta), 1);
            p2 = new Vertex(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
            while (Beta <= PI / 2)
            {
                while (Alpha <= PI * 2)
                {
                    p3 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta), 1);
                    p4 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
                    triangle = new Triangle(p1, p2, p3);
                    int r = rand.Next(255);
                    int g = rand.Next(255);
                    int b = rand.Next(255);
                    triangle.Color = new Lightning.Color(r, g, b);
                    triangles.Add(triangle);
                    triangle = new Triangle(p2, p3, p4);
                    triangles.Add(triangle);
                    p1 = p3;
                    p2 = p4;
                    Alpha += Angle;
                }
                Beta += Angle;
                Alpha = 0;
            }
            
            Beta = 0;
            Alpha = 0;

            while (Beta >= -PI / 2)
            {
                while (Alpha <= PI * 2)
                {
                    p3 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta), 1);
                    p4 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
                    triangle = new Triangle(p1, p2, p3);
                    int r = rand.Next(255);
                    int g = rand.Next(255);
                    int b = rand.Next(255);
                    triangle.Color = new Lightning.Color(r, g, b);
                    triangles.Add(triangle);
                    triangle = new Triangle(p2, p3, p4);
                    triangles.Add(triangle);
                    p1 = p3;
                    p2 = p4;
                    Alpha += Angle;
                }
                Beta -= Angle;
                Alpha = 0;
            }

//                      this.triangles = triangles;
            this.triangles = GetSpherePoints();
            
        }
        
        public void AddTriangle(Triangle triangle)
        {
            triangles.Add(triangle);
        }

        public void UpdateSphere(List<Triangle> triangles)
        {
            this.triangles = triangles;
        }


        List<Triangle> GetSpherePoints()
        {
            Random rand = new Random();
            Vertex p1, p2, p3, p4;
            Triangle triangle;
            double Angle = 10f / 180 * System.Math.PI;
            double R = 1;
            double Alpha = 0;
            double Beta = 0;
            List<Triangle> triangles = new List<Triangle>();

            while (Beta < System.Math.PI / 2)
            {
                p1 = new Vertex(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta));
                p2 = new Vertex(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle), R * Sin(Beta + Angle));
                while (Alpha < System.Math.PI * 2)
                {
                    p3 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta));
                    p4 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle));
                    triangle = new Triangle(p1, p2, p3);
                    int r = rand.Next(255);
                    int g = rand.Next(255);
                    int b = rand.Next(255);
                    triangle.Color = new Lightning.Color(0, 0, 255);
                    triangles.Add(triangle);
                    triangle = new Triangle(p2, p3, p4);
                    r = rand.Next(255);
                    g = rand.Next(255);
                    b = rand.Next(255);
                    triangle.Color = new Lightning.Color(0, 255, 0);
                    triangles.Add(triangle);
                    p1 = p3;
                    p2 = p4;
                    Alpha += Angle;
                }
                Beta += Angle;
                Alpha = 0;
            }
            Beta = 0;
            Alpha = 0;
            while (Beta > -System.Math.PI / 2)
            {
                p1 = new Vertex(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta));
                p2 = new Vertex(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle), R * Sin(Beta + Angle));
                while (Alpha < System.Math.PI * 2)
                {
                    p3 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta));
                    p4 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle));
                    triangle = new Triangle(p1, p2, p3);
                    int r = rand.Next(255);
                    int g = rand.Next(255);
                    int b = rand.Next(255);
                    triangle.Color = new Lightning.Color(255, 255, 255);
                    triangles.Add(triangle);
                    triangle = new Triangle(p2, p3, p4);
                    r = rand.Next(255);
                    g = rand.Next(255);
                    b = rand.Next(255);
                    triangle.Color = new Lightning.Color(255, 0, 0);
                    triangles.Add(triangle);
                    p1 = p3;
                    p2 = p4;
                    Alpha += Angle;
                }
                Beta -= Angle;
                Alpha = 0;
            }

            return triangles;
        }


        //FIXME some edges are not drawn on the screen
//        public List<Triangle> CreateModel()
//        {
//            Point3D p1, p2, p3, p4;
//            Triangle triangle;
//            double Angle = 30f / 180 * PI;
//            double R = 0.5;
//            double Alpha = 0;
//            double Beta = 0;
//            List<Triangle> triangles = new List<Triangle>();
//            p1 = new Point3D(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta), 1);
//            p2 = new Point3D(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
//            while (Beta <= PI / 2)
//            {
//                while (Alpha <= PI * 2)
//                {
//                    p3 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta), 1);
//                    p4 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
//                    triangle = new Triangle(p1, p2, p3);
//                    triangles.Add(triangle);
////                    triangle = new Triangle(p2, p3, p4);
////                    triangles.Add(triangle);
//                    p1 = p3;
//                    p2 = p4;
//                    Alpha += Angle;
//                }
//                Beta += Angle;
//                Alpha = 0;
//            }
//            
//            Beta = 0;
//            Alpha = 0;
//            
//            while (Beta >= -PI / 2)
//            {
//                while (Alpha <= PI * 2)
//                {
//                    p3 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta), R * Sin(Beta), 1);
//                    p4 = new Point3D(R * Cos(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle), 1);
//                    triangle = new Triangle(p1, p2, p3);
//                    triangles.Add(triangle);
////                    triangle = new Triangle(p2, p3, p4);
////                    triangles.Add(triangle);
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
