using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using System.Reflection;

namespace CodeInGame
{
    public class ShadowsOfBatman
    {
        public static void ShadowsOfBatmanOne()
        {
            string[] inputs;

            inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]); // width of the building.
            int H = int.Parse(inputs[1]); // height of the building.
            int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.

            inputs = Console.ReadLine().Split(' ');
            int Y0 = int.Parse(inputs[0]);
            int X0 = int.Parse(inputs[1]);

            int[,][] board = new int[H, W][];
            int[] currentPosition = new int[2];
            int[] previusPosition = new int[2];

            currentPosition[0] = X0;
            currentPosition[1] = Y0;

            for (int h = 0; h < H; H++)
            {
                for (int w = 0; w < W; w++)
                {
                    board[h, w] = new int[2];
                    board[h, w][0] = h;
                    board[h, w][1] = w;
                }
            }


            // game loop
            while (true)
            {
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
                int height = 0;
                int width = 0;

                string result = "0 0";
                switch (bombDir)
                {
                    case "U":
                        height = Math.Round(currentPosition[0] / 2) as decimal;
                        break;
                    case "UR":
                        break;
                    case "R":
                        break;
                    case "DR":
                        break;
                    case "D":
                        break;
                    case "DL":
                        break;
                    case "L":
                        break;
                    case "UL":
                        break;
                }


                previusPosition[0] = currentPosition[0];
                previusPosition[1] = currentPosition[1];

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");


                // the location of the next window Batman should jump to.
                Console.WriteLine(result);
            }
        }

        public static string GetCoordinates(int H, int W){
            return null;
        }
    }
}