using MathNet.Numerics.LinearAlgebra;

namespace Game.Lightning
{
  public class Light
  {
    public Color lightColor { get; set; }
    public double lightStrength { get; set; }

    public Light() : this(new Color(1.0, 1.0, 1.0), 1.0)
    {
      
    }
    
    public Light(Color lightColor, double lightStrength = 1.0)
    {
      this.lightColor = lightColor;
      this.lightStrength = lightStrength;
    }
    
    
    
  }
}