using System.Collections.Generic;

using Game.Math;
using Game.Lightning;

namespace Game.Figure
{
    public class Triangle
    {
        public List<Vector> vertices { get; set; } = new List<Vector>();

        public List<Vector> normals { get; set; } = new List<Vector>();
//        public Vector<double> firstVertexNormal { get; set; }
//        public Vector<double> secondVertexNormal { get; set; }
//        public Vector<double> thirdVertexNormal { get; set; }
        
        public Color Color = new Color(0.0, 1.0, 0.0);
        private const int numberOfTriangleVertices = 3;

        public Triangle(Vector firstVertex, Vector secondVertex, Vector thirdVertex)
        {
            
            vertices.Add(firstVertex);
            vertices.Add(secondVertex);
            vertices.Add(thirdVertex);
            CalculateNormalVectors();
        }

        public Triangle(List<Vector> vertices) 
        {
            if(vertices.Count != numberOfTriangleVertices)
                throw new ListException("Triangle should have three vertices");
            
            this.vertices = vertices;
        }
        
        public void CalculateNormalVectors()
        {
            for (int i = 0; i < numberOfTriangleVertices; i++)
            {
                Vector firstSide = vertices[(i + 1) % numberOfTriangleVertices] - vertices[i];
                Vector secondSide = vertices[(i + 2) % numberOfTriangleVertices] - vertices[i];
                
                //TODO normals should have dimenson 3 
                normals.Add(firstSide.CrossProduct(secondSide));
            }
            
        }
        

    }


}