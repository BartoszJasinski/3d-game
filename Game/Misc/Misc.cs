using System;

using GlmNet;

namespace Game.Misc
{
    public class Misc
    {
        void PrintMatrix(mat4 matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
    }
}