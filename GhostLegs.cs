using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class GhostLegs
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);

        char[,] lines = new char[H,W];

        for (int i = 0; i < H; i++)
        {
            char[] chars = new char[W];
            chars = Console.ReadLine().ToCharArray();
            Console.Error.WriteLine(chars.Length);
            for (int j = 0; j < W; j++)
            {
                lines[H, j] = chars[j];
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        foreach (var item in lines)
        {
            Console.Error.WriteLine(item);
        
        }

    }
}