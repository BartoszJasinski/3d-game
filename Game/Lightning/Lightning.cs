using Game.Figure;
using Game.Math;
using MathNet.Numerics.LinearAlgebra;

namespace Game.Lightning
{
    public class Lightning
    {
//        public static Color ApplyLightning(ILightningModel lightningModel, GameData.GameData gameData ,Triangle triangle, Vector fragPosition)
//        {
//            return lightningModel.ApplyLightning(gameData, triangle, fragPosition);
//        }

        public static Color ApplyLightning(GameData.GameData gameData, Triangle triangle, Vector fragPosition)
        {
            return gameData.lightningModel.ApplyLightning(gameData,triangle, fragPosition);
        }
    }
}
