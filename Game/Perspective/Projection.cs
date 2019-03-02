using Game.Math;

namespace Game.Perspective
{
    public class Projection
    {
        //TODO: make functions which change ProjectionMatrix like changing FOV, frostum, etc.
        public static Matrix ProjectionMatrix = new Matrix(new double[,] {
            {2.414, 0, 0, 0},
            {0, 2.414, 0, 0},
            {0, 0, -1.02, -2.02},
            {0, 0, -1, 0}});
    }
}