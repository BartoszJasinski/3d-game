using Game.Math;

namespace Game.Perspective
{
    public class Projection
    {
        //TODO: make functions which change ProjectionMatrix like changing FOV, frostum, etc.
        //TODO: move to GameData
        public static Matrix ProjectionMatrix = new Matrix(new double[,] {
            {1.732, 0, 0, 0},
            {0, 1.732, 0, 0},
            {0, 0, -1.02, -2.02},
            {0, 0, -1, 0}});
    }

}