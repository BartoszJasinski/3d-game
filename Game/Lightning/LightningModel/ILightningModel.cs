using Game.Figure;
using Game.Math;

namespace Game.Lightning.LightningModel
{
    public interface ILightningModel
    {
        Color ApplyLightning(GameData.GameData gameData, Triangle triangle, Vector fragPosition, Vector triangleNormal);
    }
}