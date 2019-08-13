using System;
using Game.Figure;
using Game.Math;

namespace Game.Shading
{
    public class PhongShading : IShading
    {
        Vector IShading.GetNormalVectorAtGivenPoint(Triangle triangle, double x, double y)
        {
            throw new NotImplementedException();

        }
    }
}