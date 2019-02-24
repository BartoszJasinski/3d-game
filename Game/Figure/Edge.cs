namespace Lab4GK.Figure
{
    class Edge
    {
        public Point3D firstPoint { get; set; }
        public Point3D secondPoint { get; set; }

        public Edge(Point3D firstPoint, Point3D secondPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }
    }
}
