using Game.Math;

namespace Game.Lightning.LightningModel
{
    public interface ILightningModel
    {
        Color ApplyLightning(GameData.GameData gameData, Color triangleColor, Vector fragPosition, Vector triangleNormal);
    }
}