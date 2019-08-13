using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Math;
using static System.Math;

namespace Game.Render
{
    public class Algorithms
    {
        //TODO: zBuffer trhrows System.IndexOutOfRangeException: Index was outside the bounds of the array. when outside of window
        //TODO: make screenWidth and screenHeightchanging apropiate to screen size https://stackoverflow.com/questions/7970262/disable-resizing-of-a-windows-forms-form
        //TODO: refactor
        public const int screenWidth = 900, screenHeight = 900;
        double[,] zBuffer = new double[screenWidth, screenHeight];

        public void DepthTesting(PictureBox gamePictureBox)
        {
            for (var x = 0; x < zBuffer.GetLength(0); x++)
            {
                for (var y = 0; y < zBuffer.GetLength(1); y++)
                {
                    zBuffer[x, y] = Double.MaxValue;
                }
            }
        }

        public class ProjectedTriangle
        {
            public bool draw = true;
            public List<Vector> vertices { get; set; } = new List<Vector>(NumberOfTriangleVertices);

            public Vector firstVertex
            {
                get => vertices[0];
                set => vertices[0] = value;
            }

            public Vector secondVertex
            {
                get => vertices[1];
                set => vertices[1] = value;
            }

            public Vector thirdVertex
            {
                get => vertices[2];
                set => vertices[2] = value;
            }


            private const int NumberOfTriangleVertices = 3;

            public ProjectedTriangle(Vector firstVertex, Vector secondVertex, Vector thirdVertex)
            {
                vertices.Add(firstVertex);
                vertices.Add(secondVertex);
                vertices.Add(thirdVertex);
            }

            public ProjectedTriangle(List<Vector> vertices)
            {
                if (vertices.Count != NumberOfTriangleVertices)
                    throw new ArgumentException("Triangle should have three vertices");

                this.vertices = vertices;
            }

            //TODO: maybe you should implement near plane far plane in Frustum Culling
            public bool FrustumCulling(double fVx, double fVy, double fVz, double sVx, double sVy, double sVz,
                double tVx, double tVy, double tVz)
            {
                return true;
                if (((fVx > 1 || fVx < -1) || (fVy > 1 || fVy < -1) || (fVz > 1 || fVz < -1)) &&
                    ((sVx > 1 || sVx < -1) || (sVy > 1 || sVy < -1) || (sVz > 1 || sVz < -1)) &&
                    ((tVx > 1 || tVx < -1) || (tVy > 1 || tVy < -1) || (tVz > 1 || tVz < -1)))
                {
                    return false;
                }

                return true;
            }


            //TODO: refactor
            public Tuple<ProjectedTriangle, bool> ProjectTriangle(int gamePictureBoxWidth, int gamePictureBoxHeight)
            {
                double fVx, fVy, fVz, sVx, sVy, sVz, tVx, tVy, tVz;
                ProjectedTriangle projectedTriangle = this;

                projectedTriangle.firstVertex.x /= projectedTriangle.firstVertex.w;
                projectedTriangle.firstVertex.y /= projectedTriangle.firstVertex.w;
                projectedTriangle.firstVertex.z /= projectedTriangle.firstVertex.w;

                projectedTriangle.secondVertex.x /= projectedTriangle.secondVertex.w;
                projectedTriangle.secondVertex.y /= projectedTriangle.secondVertex.w;
                projectedTriangle.secondVertex.z /= projectedTriangle.secondVertex.w;

                projectedTriangle.thirdVertex.x /= projectedTriangle.thirdVertex.w;
                projectedTriangle.thirdVertex.y /= projectedTriangle.thirdVertex.w;
                projectedTriangle.thirdVertex.z /= projectedTriangle.thirdVertex.w;

                projectedTriangle.firstVertex.x += 1;
                projectedTriangle.firstVertex.x /= 2;
                fVx = projectedTriangle.firstVertex.x;
                projectedTriangle.firstVertex.x *= gamePictureBoxWidth;
                projectedTriangle.firstVertex.y += 1;
                projectedTriangle.firstVertex.y /= 2;
                fVy = projectedTriangle.firstVertex.y;
                projectedTriangle.firstVertex.y *= gamePictureBoxHeight;
                projectedTriangle.firstVertex.z += 1;
                projectedTriangle.firstVertex.z /= 2;
                fVz = projectedTriangle.firstVertex.z;
                projectedTriangle.firstVertex.z *= gamePictureBoxHeight;

                projectedTriangle.secondVertex.x += 1;
                projectedTriangle.secondVertex.x /= 2;
                sVx = projectedTriangle.secondVertex.x;
                projectedTriangle.secondVertex.x *= gamePictureBoxWidth;
                projectedTriangle.secondVertex.y += 1;
                projectedTriangle.secondVertex.y /= 2;
                sVy = projectedTriangle.secondVertex.y;
                projectedTriangle.secondVertex.y *= gamePictureBoxHeight;
                projectedTriangle.secondVertex.z += 1;
                projectedTriangle.secondVertex.z /= 2;
                sVz = projectedTriangle.secondVertex.z;
                projectedTriangle.secondVertex.z *= gamePictureBoxHeight;

                projectedTriangle.thirdVertex.x += 1;
                projectedTriangle.thirdVertex.x /= 2;
                tVx = projectedTriangle.thirdVertex.x;
                projectedTriangle.thirdVertex.x *= gamePictureBoxWidth;
                projectedTriangle.thirdVertex.y += 1;
                projectedTriangle.thirdVertex.y /= 2;
                tVy = projectedTriangle.thirdVertex.y;
                projectedTriangle.thirdVertex.y *= gamePictureBoxHeight;
                projectedTriangle.thirdVertex.z += 1;
                projectedTriangle.thirdVertex.z /= 2;
                tVz = projectedTriangle.thirdVertex.z;
                projectedTriangle.thirdVertex.z *= gamePictureBoxHeight;

                var draw = FrustumCulling(fVx, fVy, fVz, sVx, sVy, sVz, tVx, tVy, tVz);

                return new Tuple<ProjectedTriangle, bool>(projectedTriangle, draw);
            }
        }


//        public ProjectedTriangle ProjectTriangle(int gamePictureBoxWidth, int gamePictureBoxHeight)
//        {
//            ProjectedTriangle projectedTriangle = this;
//                
//            projectedTriangle.firstVertex.x /= projectedTriangle.firstVertex.w;
//            projectedTriangle.firstVertex.y /= projectedTriangle.firstVertex.w;
//
//            projectedTriangle.secondVertex.x /= projectedTriangle.secondVertex.w;
//            projectedTriangle.secondVertex.y /= projectedTriangle.secondVertex.w;
//                
//            projectedTriangle.thirdVertex.x /= projectedTriangle.thirdVertex.w;
//            projectedTriangle.thirdVertex.y /= projectedTriangle.thirdVertex.w;
//
//            projectedTriangle.firstVertex.x += 1;
//            projectedTriangle.firstVertex.x /= 2;
//            projectedTriangle.firstVertex.x *= gamePictureBoxWidth;
//            projectedTriangle.firstVertex.y += 1;
//            projectedTriangle.firstVertex.y /= 2;
//            projectedTriangle.firstVertex.y *= gamePictureBoxHeight;
//                
//            projectedTriangle.secondVertex.x += 1;
//            projectedTriangle.secondVertex.x /= 2;
//            projectedTriangle.secondVertex.x *= gamePictureBoxWidth;
//            projectedTriangle.secondVertex.y += 1;
//            projectedTriangle.secondVertex.y /= 2;
//            projectedTriangle.secondVertex.y *= gamePictureBoxHeight;
//                
//            projectedTriangle.thirdVertex.x += 1;
//            projectedTriangle.thirdVertex.x /= 2;
//            projectedTriangle.thirdVertex.x *= gamePictureBoxWidth;
//            projectedTriangle.thirdVertex.y += 1;
//            projectedTriangle.thirdVertex.y /= 2;
//            projectedTriangle.thirdVertex.y *= gamePictureBoxHeight;
//
//            return projectedTriangle;
//        }
//    }


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

        private class AETData
        {
            public int yMax { get; set; }
            public double x { get; set; }
            public double mInverse { get; set; }
            public int firstVertexIndex { get; set; }
            public int secondVertexIndex { get; set; }
        }

        public void ScanLineFillVertexSort(PaintEventArgs e, Color color, ProjectedTriangle projectedTriangle)
        {
            List<Vertex> polygonVertices = new List<Vertex>();
            //for (int i = 0; i < 3; i++)
            polygonVertices.Add(
                new Vertex(new Point((int) projectedTriangle.firstVertex.x, (int) projectedTriangle.firstVertex.y), 0));
            polygonVertices.Add(new Vertex(
                new Point((int) projectedTriangle.secondVertex.x, (int) projectedTriangle.secondVertex.y), 1));
            polygonVertices.Add(
                new Vertex(new Point((int) projectedTriangle.thirdVertex.x, (int) projectedTriangle.thirdVertex.y), 2));

            polygonVertices = polygonVertices.OrderBy(v => v.point.Y).ToList();
            int yMin = polygonVertices[0].point.Y, yMax = polygonVertices.Last().point.Y;

            List<AETData> AET = new List<AETData>();

            for (int y = yMin + 1; y < yMax; y++)
            {
                List<Vertex> verticesLyingOnScanLine = polygonVertices.FindAll(vertex => vertex.point.Y == (y - 1));
                foreach (Vertex vertex in verticesLyingOnScanLine)
                {
                    int previousVertexIndex = MathMod(vertex.index - 1, polygonVertices.Count);
                    Vertex previousVertex = polygonVertices.Find(x => x.index == previousVertexIndex);
                    if (previousVertex.point.Y >= vertex.point.Y)
                    {
                        double mInverse = (previousVertex.point.X - (double) vertex.point.X) /
                                          (previousVertex.point.Y - (double) vertex.point.Y);
//                        mInverse = double.IsInfinity(mInverse) ? 0 : mInverse;
                        AET.Add(new AETData
                        {
                            yMax = previousVertex.point.Y, x = vertex.point.X, mInverse = mInverse,
                            firstVertexIndex = previousVertexIndex, secondVertexIndex = vertex.index
                        });
                    }
                    else
                        AET.RemoveAll(x =>
                            (x.firstVertexIndex == vertex.index && x.secondVertexIndex == previousVertexIndex) ||
                            (x.firstVertexIndex == previousVertexIndex && x.secondVertexIndex == vertex.index));

                    int nextVertexIndex = MathMod(vertex.index + 1, polygonVertices.Count);
                    Vertex nextVertex = polygonVertices.Find(x => x.index == nextVertexIndex);
                    if (nextVertex.point.Y >= vertex.point.Y)
                    {
                        double mInverse = (nextVertex.point.X - (double) vertex.point.X) /
                                          (nextVertex.point.Y - (double) vertex.point.Y);
//                        mInverse = double.IsInfinity(mInverse) ? 0 : mInverse;
                        AET.Add(new AETData
                        {
                            yMax = nextVertex.point.Y, x = vertex.point.X, mInverse = mInverse,
                            firstVertexIndex = nextVertexIndex, secondVertexIndex = vertex.index
                        });
                    }
                    else
                        AET.RemoveAll(x =>
                            (x.firstVertexIndex == vertex.index && x.secondVertexIndex == nextVertexIndex) ||
                            (x.firstVertexIndex == nextVertexIndex && x.secondVertexIndex == vertex.index));
                }

                AET = AET.OrderBy(x => x.x).ToList();


                foreach (var aetData in AET)
                {
                    aetData.x += aetData.mInverse;
                    if (double.IsInfinity(aetData.mInverse))
                        aetData.x = polygonVertices[aetData.secondVertexIndex].point.X;
                }

                for (int i = 0; i < AET.Count / 2; i++)
                {
                    MyDrawLine(e, new Pen(color), new Point((int) AET[2 * i].x, y),
                        new Point((int) AET[2 * i + 1].x, y), projectedTriangle);
                }
            }
        }


        private static void SetPixel(PaintEventArgs e, Brush brush, Point point)
        {
            e.Graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
        }

        static int MathMod(int a, int b)
        {
            return (Abs(a * b) + a) % b;
        }

        public void MyDrawLine(PaintEventArgs e, Pen pen, Point p1, Point p2, ProjectedTriangle projectedTriangle)
        {
            MyLine(e, p1.X, p1.Y, p2.X, p2.Y, pen.Brush, projectedTriangle);
//            e.Graphics.DrawLine(pen, p1, p2);
        }


        public void MyLine(PaintEventArgs e, int x, int y, int x2, int y2, Brush brush,
            ProjectedTriangle projectedTriangle)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1;
            else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1;
            else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1;
            else if (w > 0) dx2 = 1;
            int longest = Abs(w);
            int shortest = Abs(h);
            if (!(longest > shortest))
            {
                longest = Abs(h);
                shortest = Abs(w);
                if (h < 0) dy2 = -1;
                else if (h > 0) dy2 = 1;
                dx2 = 0;
            }

            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (x < 0 || x >= screenWidth || y < 0 || y >= screenHeight)
                {
                }
                else
                {
                    double z = InterpolateZ(x, y, projectedTriangle);
                    if (z <= zBuffer[x, y])
                    {
                        SetPixel(e, brush, new Point(x, y));
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

        private double InterpolateZ(double x, double y, ProjectedTriangle projectedTriangle)
        {
            double[,] matrixElements = new double[,]
            {
                {projectedTriangle.firstVertex.x, projectedTriangle.secondVertex.x, projectedTriangle.thirdVertex.x},
                {projectedTriangle.firstVertex.y, projectedTriangle.secondVertex.y, projectedTriangle.thirdVertex.y},
                {1, 1, 1}
            };
            Matrix A = new Matrix(matrixElements);
            Vector B = new Vector(x, y, 1);

            Vector coefficients = A.Inverse() * B;

            double z = coefficients[0] * projectedTriangle.firstVertex.z +
                       coefficients[1] * projectedTriangle.secondVertex.z +
                       coefficients[2] * projectedTriangle.thirdVertex.z;

            return z;
        }
    }
}