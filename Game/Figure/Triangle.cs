using System;
using System.Collections.Generic;
using Game.Lightning;
using Game.Math;

namespace Game.Figure
{
    public class Triangle
    {
        public List<Vertex> vertices { get; set; } = new List<Vertex>(NumberOfTriangleVertices);

        public Vertex firstVertex
        {
            get => vertices[0];
            set => vertices[0] = value;
        }

        public Vertex secondVertex
        {
            get => vertices[1];
            set => vertices[1] = value;
        }

        public Vertex thirdVertex
        {
            get => vertices[2];
            set => vertices[2] = value;
        }

        public Vector normal { get; set; }

        public Color color { get; set; }
        private const int NumberOfTriangleVertices = 3;

        public Triangle()
        {
            
        }
        public Triangle(Vertex firstVertex, Vertex secondVertex, Vertex thirdVertex)
        {
            vertices.Add(firstVertex);
            vertices.Add(secondVertex);
            vertices.Add(thirdVertex);
            CalculateNormal();
//            CalculateNormalVectors();
        }

        public Triangle(List<Vertex> vertices)
        {
            if (vertices.Count != NumberOfTriangleVertices)
            {
                throw new ArgumentException("Triangle should have three vertices");
            }

            this.vertices = vertices;
            CalculateNormal();
//            CalculateNormalVectors();
        }

        //TODO https://www.opengl-tutorial.org/beginners-tutorials/tutorial-8-basic-shading/#triangle-normals
        public void CalculateNormalVectors()
        {
            for (var i = 0; i < NumberOfTriangleVertices; i++)
            {
                var firstSide = (vertices[(i + 1) % NumberOfTriangleVertices].position - vertices[i].position)
                    .CastVectorTo3D();
                var secondSide = (vertices[(i + 2) % NumberOfTriangleVertices].position - vertices[i].position)
                    .CastVectorTo3D();

                //TODO normals should have dimenson 3 
                //TODO: check if normal calculating is correct
                //TODO: (unit vector)normalize normal
                vertices[i].normal = /*-*/(firstSide.CrossProduct(secondSide)).Normalize();
            }
        }

        private void CalculateNormal()
        {
//            triangle ( v1, v2, v3 )
//            edge1 = v2-v1
//            edge2 = v3-v1
//            triangle.normal = cross(edge1, edge2).normalize()
            var firstEdge = (secondVertex - firstVertex).CastVectorTo3D();
            var secondEdge = (thirdVertex - firstVertex).CastVectorTo3D();
            normal = firstEdge.CrossProduct(secondEdge).Normalize();
        }
    }
}