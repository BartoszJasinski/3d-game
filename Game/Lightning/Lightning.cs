using Game.Math;

namespace Game.Lightning
{
    public class Lightning
    {

        public static Color ApplyLightning(GameData.GameData gameData, Color triangleColor, Vector fragPosition, Vector triangleNormal)
        {
            return gameData.lightningModel.ApplyLightning(gameData, triangleColor, fragPosition, triangleNormal);
        }
    }
}
