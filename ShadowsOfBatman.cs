using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using System.Reflection;
using System.Transactions;

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
            int X0 = int.Parse(inputs[0]);
            int Y0 = int.Parse(inputs[1]);

            int[] currentPosition = new int[2];
            int[] prevUpPos = new int[2];
            int[] prevDownPos = new int[2];
            int[] prevLeftPos = new int[2];
            int[] prevRightPos = new int[2];


            prevUpPos[0] = prevDownPos[0] = currentPosition[0] = X0;
            prevUpPos[1] = 0;
            prevDownPos[1] = H;
            prevLeftPos[1] = prevRightPos[1] = currentPosition[1] = Y0;
            prevLeftPos[0] = 0;
            prevRightPos[0] = W;

            string result = "0 0";

            // game loop
            while (true)
            {
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
                Console.Error.WriteLine(bombDir);
                int height = H;
                int width = W;

                switch (bombDir)
                {
                    case "U":
                        float coord = currentPosition[1] - (SpecialCase(currentPosition[1], prevUpPos[1]) / 2);
                        height = (int)Math.Round(coord);
                        width = currentPosition[0];
                        prevDownPos[1] = currentPosition[1];
                        prevDownPos[0] = currentPosition[0];
                        prevLeftPos[0] = currentPosition[0];
                        prevLeftPos[1] = currentPosition[1];
                        prevRightPos[0] = currentPosition[0];
                        prevRightPos[1] = currentPosition[1];
                        break;
                    case "UR":
                        coord = currentPosition[1] - (SpecialCase(currentPosition[1], prevUpPos[1]) / 2);
                        height = (int)Math.Round(coord);
                        coord = currentPosition[0] + (SpecialCase(prevRightPos[0], currentPosition[0]) / 2);
                        width = (int)Math.Round(coord);
                        prevDownPos[1] = currentPosition[1];
                        prevDownPos[0] = currentPosition[0];
                        prevLeftPos[0] = currentPosition[0];
                        prevLeftPos[1] = currentPosition[1];
                        break;
                    case "R":
                        coord = currentPosition[0] + (SpecialCase(prevRightPos[0], currentPosition[0]) / 2);
                        height = currentPosition[1];
                        width = (int)Math.Round(coord);
                        prevLeftPos[0] = currentPosition[0];
                        prevLeftPos[1] = currentPosition[1];
                        prevDownPos[1] = currentPosition[1];
                        prevDownPos[0] = currentPosition[0];
                        prevUpPos[1] = currentPosition[1];
                        prevUpPos[0] = currentPosition[0];
                        break;
                    case "DR":
                        coord = currentPosition[1] + (SpecialCase(prevDownPos[1], currentPosition[1]) / 2);
                        height = (int)Math.Round(coord);
                        coord = currentPosition[0] + (SpecialCase(prevRightPos[0], currentPosition[0]) / 2);
                        width = (int)Math.Round(coord);
                        prevUpPos[1] = currentPosition[1];
                        prevUpPos[0] = currentPosition[0];
                        prevLeftPos[0] = currentPosition[0];
                        prevLeftPos[1] = currentPosition[1];
                        break;
                    case "D":
                        coord = currentPosition[1] + (SpecialCase(prevDownPos[1], currentPosition[1]) / 2);
                        height = (int)Math.Round(coord);
                        width = currentPosition[0];
                        prevUpPos[1] = currentPosition[1];
                        prevUpPos[0] = currentPosition[0];
                        prevLeftPos[0] = currentPosition[0];
                        prevLeftPos[1] = currentPosition[1];
                        prevRightPos[0] = currentPosition[0];
                        prevRightPos[1] = currentPosition[1];
                        break;
                    case "DL":
                        coord = currentPosition[1] + (SpecialCase(prevDownPos[1], currentPosition[1]) / 2);
                        height = (int)Math.Round(coord);
                        coord = currentPosition[0] - (SpecialCase(currentPosition[0], prevLeftPos[0]) / 2);
                        width = (int)Math.Round(coord);
                        prevUpPos[1] = currentPosition[1];
                        prevUpPos[0] = currentPosition[0];
                        prevRightPos[0] = currentPosition[0];
                        prevRightPos[1] = currentPosition[1];
                        break;
                    case "L":
                        coord = currentPosition[0] - (SpecialCase(currentPosition[0], prevLeftPos[0]) / 2);
                        height = currentPosition[1];
                        width = (int)Math.Round(coord);
                        prevRightPos[0] = currentPosition[0];
                        prevRightPos[1] = currentPosition[1];
                        prevDownPos[1] = currentPosition[1];
                        prevDownPos[0] = currentPosition[0];
                        prevUpPos[1] = currentPosition[1];
                        prevUpPos[0] = currentPosition[0];
                        break;
                    case "UL":
                        coord = currentPosition[1] - (SpecialCase(currentPosition[1], prevUpPos[1]) / 2);
                        height = (int)Math.Floor(coord);
                        coord = currentPosition[0] - (SpecialCase(currentPosition[0], prevLeftPos[0]) / 2);
                        width = (int)Math.Round(coord);
                        prevRightPos[0] = currentPosition[0];
                        prevRightPos[1] = currentPosition[1];
                        prevDownPos[0] = currentPosition[0];
                        prevDownPos[1] = currentPosition[1];
                        break;
                }


                result = width + " " + height;
                currentPosition[0] = width;
                currentPosition[1] = height;

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");


                // the location of the next window Batman should jump to.
                Console.WriteLine(result);
            }
        }

        static int SpecialCase(int x, int y)
        {
            if ((x - y) == 0)
                return 2;
            else
                return (x - y);
        }
    }
}