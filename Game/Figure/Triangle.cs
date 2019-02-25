using Game.Lightning;

namespace Game.Figure
{
    public class Triangle
    {
        public Point3D firstVertex { get; set; }
        public Point3D secondVertex { get; set; }
        public Point3D thirdVertex { get; set; }

        public Color Color = new Color(0.0, 1.0, 0.0);

        public Triangle(Point3D firstVertex, Point3D secondVertex, Point3D thirdVertex)
        {
            this.firstVertex = firstVertex;
            this.secondVertex = secondVertex;
            this.thirdVertex = thirdVertex;
        }
    }


}