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
            
            Vertex firstVertex, secondVertex, thirdVertex;
            Triangle triangle;
            double Angle = 30f / 180 * PI;
            double R = 0.5;
            double Alpha = 0;
            double Beta = 0;
            double height = 1;
            double kat = PI / 4;
            List<Triangle> triangles = new List<Triangle>();
            firstVertex = new Vertex(0, 0, height);

            while (Alpha <= PI * 2)
            {
                secondVertex = new Vertex(R * Cos(Alpha), R * Sin(Alpha), 0);
                thirdVertex = new Vertex(R * Cos(Alpha + Angle), R * Sin(Alpha + Angle), 0);

                triangle = new Triangle(firstVertex, secondVertex, thirdVertex) {color = Lightning.Color.RandomColor()};
                triangles.Add(triangle);
                secondVertex = thirdVertex;
                Alpha += Angle;
            }

            this.triangles = triangles;

            CalculateNormalVectors();
        }

        public Cone(Lightning.Color color)
        {
            Vertex firstVertex, secondVertex, thirdVertex;
            Triangle triangle;
            double Angle = 30f / 180 * PI;
            double R = 0.5;
            double Alpha = 0;
            double Beta = 0;
            double height = 1;
            double kat = PI / 4;
            List<Triangle> triangles = new List<Triangle>();
            firstVertex = new Vertex(0, 0, height);

            while (Alpha <= PI * 2)
            {
                secondVertex = new Vertex(R * Cos(Alpha), R * Sin(Alpha), 0);
                thirdVertex = new Vertex(R * Cos(Alpha + Angle), R * Sin(Alpha + Angle), 0);
                triangle = new Triangle(firstVertex, secondVertex, thirdVertex);
                triangle.color = color;
                triangles.Add(triangle);
                secondVertex = thirdVertex;
                Alpha += Angle;
            }

            this.triangles = triangles;
        }
    }
}