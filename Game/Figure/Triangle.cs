using System.Collections.Generic;

using MathNet.Numerics.LinearAlgebra;

using Game.Lightning;

namespace Game.Figure
{
    public class Triangle
    {
        public List<Vector<double>> vertices { get; set; } = new List<Vector<double>>();
//        public Vector<double> firstVertex { get; set; }
//        public Vector<double> secondVertex { get; set; }
//        public Vector<double> thirdVertex { get; set; }

        public List<Vector<double>> normals { get; set; } = new List<Vector<double>>();
//        public Vector<double> firstVertexNormal { get; set; }
//        public Vector<double> secondVertexNormal { get; set; }
//        public Vector<double> thirdVertexNormal { get; set; }
        
        public Color Color = new Color(0.0, 1.0, 0.0);
        private const int numberOfTriangleVertices = 3;

        public Triangle(Vector<double> firstVertex, Vector<double> secondVertex, Vector<double> thirdVertex)
        {
            
            vertices.Add(firstVertex);
            vertices.Add(secondVertex);
            vertices.Add(thirdVertex);
            CalculateNormalVectors();
        }

        public Triangle(List<Vector<double>> vertices) 
        {
            if(vertices.Count != numberOfTriangleVertices)
                throw new ListException("Triangle should have three vertices");
            
            this.vertices = vertices;
        }
        
        public void CalculateNormalVectors()
        {
            for (int i = 0; i < numberOfTriangleVertices; i++)
            {
                Vector<double> firstSide = vertices[(i + 1) % numberOfTriangleVertices] - vertices[i];
                Vector<double> secondSide = vertices[(i + 2) % numberOfTriangleVertices] - vertices[i];
                
                //TODO normals should have dimenson 3 
                normals.Add(Misc.Math.CrossProduct(firstSide, secondSide));
            }
            
        }
        

    }


}