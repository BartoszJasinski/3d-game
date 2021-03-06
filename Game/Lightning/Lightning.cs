using Game.Math;

namespace Game.Lightning
{
    public class Lightning
    {
//        public static Color ApplyLightning(ILightningModel lightningModel, GameData.GameData gameData ,Triangle triangle, Vector fragPosition)
//        {
//            return lightningModel.ApplyLightning(gameData, triangle, fragPosition);
//        }

        public static Color ApplyLightning(GameData.GameData gameData, Color triangleColor, Vector fragPosition, Vector triangleNormal)
        {
            return gameData.lightningModel.ApplyLightning(gameData, triangleColor, fragPosition, triangleNormal);
        }
    }
}
