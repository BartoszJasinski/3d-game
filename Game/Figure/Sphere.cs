using System;
using System.Collections.Generic;
using Game.Lightning;
using static System.Math;

namespace Game.Figure
{
    class Sphere : Model, IModel
    {
        public Sphere()
        {

//            this.triangles = triangles;
            triangles = GetSpherePoints();
            CalculateNormalVectors();
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
            Vertex p1, p2, p3, p4;
            Triangle triangle;
            double Angle = 30f / 180 * PI;
            double R = 1;
            double Alpha = 0;
            double Beta = 0;
            List<Triangle> triangles = new List<Triangle>();

            while (Beta < PI / 2)
            {
                p1 = new Vertex(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta));
                p2 = new Vertex(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle),
                    R * Sin(Beta + Angle));
                while (Alpha < PI * 2)
                {
                    p3 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta),
                        R * Sin(Beta));
                    p4 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta + Angle),
                        R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle));
                    triangle = new Triangle(p1, p2, p3);
                    Color.RandomColor();

                    triangle.color = new Color(0, 0, 255);
                    triangles.Add(triangle);
                    triangle = new Triangle(p2, p3, p4);
                    Color.RandomColor();
                    triangle.color = new Color(0, 255, 0);
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
            while (Beta > -PI / 2)
            {
                p1 = new Vertex(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta));
                p2 = new Vertex(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle),
                    R * Sin(Beta + Angle));
                while (Alpha < PI * 2)
                {
                    p3 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta),
                        R * Sin(Beta));
                    p4 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta + Angle),
                        R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle));
                    triangle = new Triangle(p1, p2, p3);
                    Color.RandomColor();
                    triangle.color = new Color(255, 255, 255);
                    triangles.Add(triangle);

                    triangle = new Triangle(p2, p3, p4);
                    Color.RandomColor();
                    triangle.color = new Color(255, 0, 0);
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


        List<Triangle> GetSphere()
        {
            Vertex p1, p2, p3, p4;
            Triangle triangle;
            double Angle = 10f / 180 * PI;
            double R = 1;
            double Alpha = 0;
            double Beta = 0;
            List<Triangle> triangles = new List<Triangle>();

            while (Beta < PI / 2)
            {
                p1 = new Vertex(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta));
                p2 = new Vertex(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle),
                    R * Sin(Beta + Angle));
                while (Alpha < PI * 2)
                {
                    p3 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta),
                        R * Sin(Beta));
                    p4 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta + Angle),
                        R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle));
                    triangle = new Triangle(p1, p2, p3);
                    triangle.color = new Color(0, 0, 255);
                    triangles.Add(triangle);
                    triangle = new Triangle(p2, p3, p4);
                    triangle.color = new Color(0, 255, 0);
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
            while (Beta > -PI / 2)
            {
                p1 = new Vertex(R * Cos(Alpha) * Cos(Beta), R * Sin(Alpha) * Cos(Beta), R * Sin(Beta));
                p2 = new Vertex(R * Cos(Alpha) * Cos(Beta + Angle), R * Sin(Alpha) * Cos(Beta + Angle),
                    R * Sin(Beta + Angle));
                while (Alpha < PI * 2)
                {
                    p3 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta), R * Sin(Alpha + Angle) * Cos(Beta),
                        R * Sin(Beta));
                    p4 = new Vertex(R * Cos(Alpha + Angle) * Cos(Beta + Angle),
                        R * Sin(Alpha + Angle) * Cos(Beta + Angle), R * Sin(Beta + Angle));
                    triangle = new Triangle(p1, p2, p3);
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

            return triangles;
        }



    }
}