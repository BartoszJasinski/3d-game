using Game.Figure;

namespace Game.Lightning
{
    public class Lightning
    {
        public static Color ApplyLightning(ILightningModel lightningModel, Triangle triangle)
        {
            return lightningModel.ApplyLightning(triangle);
        }
    }
}