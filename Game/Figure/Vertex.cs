using Game.Math;
using MathNet.Numerics.LinearAlgebra;

namespace Game.Figure
{
    public class Vertex
    {
        public Vector position { get; set; }
        public Vector normal { get; set; }

        public Vertex(Vector position) : this(position, new Vector())
        {
        }

        public Vertex(Vector position, Vector normal)
        {
            this.position = position;
            this.normal = normal;
        }

        public Vertex(double x, double y, double z, double w = 1)
        {
            position = new Vector(x, y, z, w);
        }


        public static Vector operator -(Vertex firstVertex, Vertex secondVertex)
        {
            return firstVertex.position - secondVertex.position;
        }
    }
}