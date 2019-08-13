using Game.Figure;
using Game.Math;

namespace Game.Shading
{
    public interface IShading
    {
        Vector GetNormalVectorAtGivenPoint(Triangle triangle, double x, double y);

    }
}