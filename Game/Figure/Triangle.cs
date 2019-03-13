using System.Collections.Generic;

using Game.Math;
using Game.Lightning;

namespace Game.Figure
{
    public class Triangle
    {
        public List<Vertex> vertices { get; set; } = new List<Vertex>();
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
        

        public Color Color = new Color(0.0, 1.0, 0.0);
        private const int numberOfTriangleVertices = 3;

        public Triangle(Vertex firstVertex, Vertex secondVertex, Vertex thirdVertex)
        {
            
            vertices.Add(firstVertex);
            vertices.Add(secondVertex);
            vertices.Add(thirdVertex);
            CalculateNormalVectors();
        }

        public Triangle(List<Vertex> vertices) 
        {
            if(vertices.Count != numberOfTriangleVertices)
                throw new ListException("Triangle should have three vertices");
            
            this.vertices = vertices;
            CalculateNormalVectors();
        }
        
        //TODO https://www.opengl-tutorial.org/beginners-tutorials/tutorial-8-basic-shading/#triangle-normals
        public void CalculateNormalVectors()
        {
            for (int i = 0; i < numberOfTriangleVertices; i++)
            {
                Vector firstSide = vertices[(i + 1) % numberOfTriangleVertices].position - vertices[i].position;
                Vector secondSide = vertices[(i + 2) % numberOfTriangleVertices].position - vertices[i].position;
                
                //TODO normals should have dimenson 3 
                vertices[i].normal = firstSide.CrossProduct(secondSide);
            }
            
        }
        

    }


}