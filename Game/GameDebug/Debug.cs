using System;
using System.Collections.Generic;
using System.Drawing;
using Game.IO;

namespace Game.GameDebug
{
    public class Debug
    {       
        private static int fontSize = 10;
        private static Point startingPoint = new Point(2, 2);
        private static int spacingBetweenDebugStrings = 4;
        private static List<Point> debugStringPlacementPoints = GetNewPointsListForDebugStringPlacement();
        private static string NoDataMessage = "No Data";
        private static DateTime startTime = DateTime.Now;
        public static void PrintDebugGameData(Graphics graphics, GameData.GameData gameData/*, Mouse mouse*/)
        {
            using (Font myFont = new Font("Arial", fontSize))
            {
                graphics.DrawString("Model Position " + gameData.models[0].translationVector, myFont, Brushes.Red, debugStringPlacementPoints[0]);
                graphics.DrawString("Model Scale " + gameData.models[0].scaleVector, myFont, Brushes.Yellow, debugStringPlacementPoints[1]);
                graphics.DrawString("Model Rotation " + gameData.models[0].rotationVector, myFont, Brushes.Pink, debugStringPlacementPoints[2]);

                graphics.DrawString("Camera Position " + gameData.camera.cameraPosition, myFont, Brushes.Green, debugStringPlacementPoints[3]);
                graphics.DrawString("Camera Front" + gameData.camera.cameraFront, myFont, Brushes.Teal, debugStringPlacementPoints[4]);
                graphics.DrawString("Camera Up Axis" + gameData.camera.upAxis, myFont, Brushes.White, debugStringPlacementPoints[5]);
                graphics.DrawString("Camera Yaw = " + NoDataMessage/*mouse.yaw*/, myFont, Brushes.Lime, debugStringPlacementPoints[6]);
                graphics.DrawString("Camera Pitch = " + NoDataMessage/*mouse.pitch*/, myFont, Brushes.Cyan, debugStringPlacementPoints[7]);
                
                PrintFps(graphics, gameData, myFont);

                graphics.DrawString("First Vertex Normal = " + gameData.player.triangles[0].firstVertex.normal, myFont, Brushes.Cyan, debugStringPlacementPoints[15]);
                graphics.DrawString("Second Vertex Normal = " + gameData.player.triangles[0].secondVertex.normal, myFont, Brushes.Cyan, debugStringPlacementPoints[16]);
                graphics.DrawString("Third Vertex Normal = " + gameData.player.triangles[0].thirdVertex.normal, myFont, Brushes.Cyan, debugStringPlacementPoints[17]);

            }
        }

        private static List<Point> GetNewPointsListForDebugStringPlacement()
        {
            List<Point> debugPoints = new List<Point>();
            for (int i = 0; i < 20; i++)
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

        private static void PrintFps(Graphics graphics, GameData.GameData gameData, Font myFont )
        {
            double fps = CalculateFps();
            graphics.DrawString("FPS = " + fps, myFont, Brushes.Goldenrod, debugStringPlacementPoints[8]);

        }

        private static double CalculateFps()
        {
            double oneSecond = 1000;
            double fps = oneSecond / (DateTime.Now - startTime).Milliseconds;
            startTime = DateTime.Now;

            return fps;
        }
        
    }
}