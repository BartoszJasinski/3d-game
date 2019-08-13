using Game.Figure;
using Game.Math;

namespace Game.Shading
{
    public class FlatShading : IShading
    {
        public Vector GetNormalVectorAtGivenPoint(Triangle triangle, double x, double y)
        {
            return triangle.normal;
        }
    }
}