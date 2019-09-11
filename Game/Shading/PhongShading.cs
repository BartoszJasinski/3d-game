using System;
using System.Drawing;
using Game.Figure;
using Game.Math;

namespace Game.Shading
{
    public class PhongShading /* : IShading*/
    {
        public static Vector /*IShading.*/
            GetNormalVectorAtGivenPoint(Triangle triangle, System.Drawing.Point processedPoint)
        {
            Point NabFirstVertex = new Point(triangle.firstVertex.position.x, triangle.firstVertex.position.y);
            Point NabSecondVertex = new Point(triangle.secondVertex.position.x, triangle.secondVertex.position.y);
            Vector Nab = Lerp(triangle.firstVertex.normal, triangle.secondVertex.normal,
                SectionLength(new Point(processedPoint), NabFirstVertex) /
                SectionLength(NabFirstVertex, NabSecondVertex));
//            Vector Nac = Lerp(triangle.firstVertex.normal, triangle.thirdVertex.normal, SectionLength(new Point(), ))
            
            return triangle.normal;
        }

        public static Vector Lerp(Vector a, Vector b, double gradient)
        {
            return a + (gradient * (b - a));
        }

        public static double SectionLength(Point firstVertex, Point secondVertex)
        {
            return System.Math.Pow(System.Math.Pow(firstVertex.x - secondVertex.x, 2) +
                                   System.Math.Pow(firstVertex.y - secondVertex.y, 2), 0.5);
        }

        public class Point
        {
            public double x { get; set; }
            public double y { get; set; }

            public Point(double x, double y)
            {
                x = x;
                y = y;
            }

            public Point(System.Drawing.Point point)
            {
                x = point.X;
                y = point.Y;
            }
        }
    }
}