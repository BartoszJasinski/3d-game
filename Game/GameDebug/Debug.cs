using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game.Debug
{
    public class Debug
    {       
        private static int fontSize = 10;
        private static Point startingPoint = new Point(2, 2);
        private static int spacingBetweenDebugStrings = 4;
        private static List<Point> debugStringPlacementPoints = GetNewPointsListForDebugStringPlacement();

        public static void PrintDebugGameData(Graphics graphics, GameData.GameData gameData)
        {
            using (Font myFont = new Font("Arial", fontSize))
            {
                graphics.DrawString("Model Position " + gameData.models[0].translationVector, myFont, Brushes.Red, debugStringPlacementPoints[0]);
                graphics.DrawString("Model Scale " + gameData.models[0].scaleVector, myFont, Brushes.Yellow, debugStringPlacementPoints[1]);
                graphics.DrawString("Model Rotation " + gameData.models[0].rotationVector, myFont, Brushes.Pink, debugStringPlacementPoints[2]);

                graphics.DrawString("Camera Position " + gameData.camera.cameraPosition, myFont, Brushes.Green, debugStringPlacementPoints[3]);
                graphics.DrawString("Camera Front" + gameData.camera.cameraFront, myFont, Brushes.Blue, debugStringPlacementPoints[4]);
                graphics.DrawString("Camera Up Axis" + gameData.camera.upAxis, myFont, Brushes.White, debugStringPlacementPoints[5]);

            }
        }

        private static List<Point> GetNewPointsListForDebugStringPlacement()
        {
            List<Point> debugPoints = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                debugPoints.Add(GetNewPointForDebugStringPlacement());
            }

            return debugPoints;
        }


        private static Point GetNewPointForDebugStringPlacement()
        {
            Point debugPoint = startingPoint;
            startingPoint = new Point(startingPoint.X, startingPoint.Y + (fontSize + spacingBetweenDebugStrings));
            
            return debugPoint;
        }
        
        
    }
}