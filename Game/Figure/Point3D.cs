namespace Game.Figure
{
    public class Point3D
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double w { get; set; }

        // Changed from int -> double
        public Point3D(double x, double y, double z, double w = 1)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        
        

        
    }
}
