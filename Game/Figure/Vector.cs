using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Game.Figure
{
    public class Vector
    {
        private Vector<double> vector { get; set; }
        
        public double x
        {
            get => vector[0];
            set => vector[0] = value;
        }
        
        public double y
        {
            get => vector[1];
            set => vector[1] = value;
        }
        
        public double z
        {
            get => vector[2];
            set => vector[2] = value;
        }
        
        public double w
        {
            get => vector[3];
            set => vector[3] = value;
        }

        public Vector(): this(new DenseVector(new double[] { 0.0, 0.0, 0.0, 0.0 }))
        {
            
        }

        public Vector(double x, double y, double z, double w): this(new DenseVector(new double[] {x, y, z, w}))
        {
            
        }
        
        public Vector(Vector<double> vector)
        {
            this.vector = vector;
        }
        
        
        
        public double this[int i]
        {
            get => vector[i];
            set => vector[i] = value;
        }

        public static implicit operator Vector<double>(Vector vector)
        {
            return vector.vector;
        }
     
        public static implicit operator Vector(Vector<double> vector)
        {
            return new Vector(vector);
        }
        
        

        
    }
}
