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
        
        public Color color { get; set; }
        private const int NumberOfTriangleVertices = 3;

        public Triangle(Vertex firstVertex, Vertex secondVertex, Vertex thirdVertex)
        {
            
            vertices.Add(firstVertex);
            vertices.Add(secondVertex);
            vertices.Add(thirdVertex);
            CalculateNormalVectors();
        }

        public Triangle(List<Vertex> vertices) 
        {
            if(vertices.Count != NumberOfTriangleVertices)
                throw new ArgumentException("Triangle should have three vertices");
            
            this.vertices = vertices;
            CalculateNormalVectors();
        }
        
        //TODO https://www.opengl-tutorial.org/beginners-tutorials/tutorial-8-basic-shading/#triangle-normals
        public void CalculateNormalVectors()
        {
            for (int i = 0; i < NumberOfTriangleVertices; i++)
            {
                Vector firstSide = (vertices[(i + 1) % NumberOfTriangleVertices].position - vertices[i].position).CastVectorTo3D();
                Vector secondSide = (vertices[(i + 2) % NumberOfTriangleVertices].position - vertices[i].position).CastVectorTo3D();
                
                //TODO normals should have dimenson 3 
                //TODO: check if normal calculating is correct
                //TODO: (unit vector)normalize normal
                vertices[i].normal = /*-*/(firstSide.CrossProduct(secondSide))/*.Normalize(2)*/;
            }
            
        }
        

    }


}