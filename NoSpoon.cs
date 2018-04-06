using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeInGame {

    public class NoSpoon {

        public int Height;
        public int Width;
        public char [,] NodeData;
        public string Down;
        public string Right;
        public string Result;

        public static NoSpoon noSpoon;

        public NoSpoon () {
            Height = 3;
            Width = 3;
            NodeData = new char [,] {
                    {'0', '.', '0'},
                    {'.', '0', '0'},
                    {'.', '.', '.'}
                };
            Down = "-1, -1";
            Right = "-1, -1";
            Result = "No result achieved...";
        }

        public static void ThereIsNoSpoon () {
            noSpoon = new NoSpoon();

            /*for (int i = 0 ; i < height ; i++) {
                string line = Console.ReadLine(); // width characters, each either 0 or .
            }*/

            Console.WriteLine(noSpoon.Result);

            ConsoleKeyInfo cki = Console.ReadKey();
            if ((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X) {
                MainMenu.Main(null);
            }

            ThereIsNoSpoon();
        }

        bool CheckRight (int row, int col) {
            for (int i = 0 ; i < noSpoon.Height ; i++) {
                if (noSpoon.NodeData [i, col] == '0')
                    noSpoon.Down = i + " " + col;
            }
            return false;
        }

        bool CheckDown (int row, int col) {
            return false;
        }
    }
}