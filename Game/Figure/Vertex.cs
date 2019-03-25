using Game.Math;
using MathNet.Numerics.LinearAlgebra;

namespace Game.Figure
{
    public class Vertex
    {
        public Vector position { get; set; }
        public Vector normal { get; set; }

        //TODO: maybe delete this constructor (it is not used)
//        public Vertex(Vector position) : this(position, new Vector())
//        {
//            
//        }

        //TODO: maybe delete this constructor (it is not used)
//        public Vertex(Vector position, Vector normal)
//        {
//            this.position = position;
//            this.normal = normal;
//        }

        public Vertex(double x, double y, double z) : this(x, y, z, 1)
        {
            
        }
        
        public Vertex(double x, double y, double z, double w)
        {
            position = new Vector(x, y, z, w);
        }

        
    }
}