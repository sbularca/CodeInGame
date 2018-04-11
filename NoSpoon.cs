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
        public string CurrentNode;

        public static NoSpoon noSpoon;

        public NoSpoon () {
            Height = 2; // row
            Width = 2; //  col
            NodeData = new char [,] {
                    {'0', '0'},
                    {'0', '.'}
                };
            Down = "-1 -1";
            Right = "-1 -1 ";
            Result = "No result achieved...";
            CurrentNode = "-1 -1 ";
        }

        public static void ThereIsNoSpoon () {
            noSpoon = new NoSpoon();

            for (int i = 0 ; i < noSpoon.Height ; i++) {
                for (int j=0; j<noSpoon.Width; j++){
                    if (noSpoon.isNode(i, j)){
                        noSpoon.CurrentNode = j.ToString() + " " + i.ToString() + " ";
                        noSpoon.Right = noSpoon.CheckRight(i, j);
                        noSpoon.Down = noSpoon.CheckDown(i, j);
                        noSpoon.Result = noSpoon.CurrentNode + noSpoon.Right + noSpoon.Down;
                        Console.WriteLine(noSpoon.Result);
                    }
                }
            }

            ConsoleKeyInfo cki = Console.ReadKey();
            if ((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X) {
                MainMenu.Main(null);
            }

            ThereIsNoSpoon();
        }

        string CheckRight (int row, int col) {
            string result = "-1 -1 ";
            if (col < (noSpoon.Width - 1)){
                for (int i=col+1; i<noSpoon.Width; i++){
                    if (isNode(row, i))
                        result = i.ToString() + " " + row.ToString() + " ";
                }
            }
            return result;
        }

        string CheckDown (int row, int col) {
            string result = "-1 -1";
            if (row < (noSpoon.Height - 1)){
                for (int i=col+1; i<noSpoon.Height; i++){
                    if (isNode(i, col))
                        result = col.ToString() + " " + i.ToString();
                }
            }
            return result;
        }

        bool isNode(int row, int col){
            if (noSpoon.NodeData[row, col] == '0')
                return true;
            return false;
        }
    }
}