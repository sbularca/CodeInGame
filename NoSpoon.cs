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
            Height = 3; // row
            Width = 3; //  col
            NodeData = new char [,] {
                    {'0', '.', '0'},
                    {'.', '.', '.'},
                    {'0', '.', '0'}
                };
            Down = "-1 -1 ";
            Right = "-1 -1";
            Result = "No result achieved...";
            CurrentNode = "-1 -1 ";
        }

        public static void ThereIsNoSpoon () {
            noSpoon = new NoSpoon();
            noSpoon.NodeData = noSpoon.Transpose(noSpoon.NodeData);

            for (int i = 0 ; i < noSpoon.Width ; i++) {
                for (int j=0; j<noSpoon.Height; j++){
                    if (noSpoon.isNode(i, j)){
                        noSpoon.CurrentNode = i.ToString() + " " + j.ToString() + " ";
                        noSpoon.Right = noSpoon.CheckRight(i, j);
                        noSpoon.Down = noSpoon.CheckDown(i, j);
                        noSpoon.Result = noSpoon.CurrentNode + noSpoon.Down + noSpoon.Right;
                        Console.WriteLine(noSpoon.Result);
                    }
                }
            }
            
            Console.WriteLine("\nPress Ctrl+X to go back to menu.");
            ConsoleKeyInfo cki = Console.ReadKey();
            if ((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X) {
                MainMenu.Main(null);
            }

            ThereIsNoSpoon();
        }

        string CheckRight (int row, int col) {
            string result = "-1 -1";
            if (col < (noSpoon.Height - 1)){
                for (int i=col+1; i<noSpoon.Height; i++){
                    if (isNode(row, i))
                        return result = row.ToString() + " " + i.ToString();
                }
            }
            return result;
        }

        string CheckDown (int row, int col) {
            string result = "-1 -1 ";
            if (row < (noSpoon.Width - 1)){
                for (int i=col+1; i<noSpoon.Width; i++){
                    if (isNode(i, col))
                        return result = i.ToString() + " " + col.ToString() + " ";
                }
            }
            return result;
        }

        bool isNode(int row, int col){
            if (noSpoon.NodeData[row, col] == '0')
                return true;
            return false;
        }

        char[,] Transpose(char[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);
        
            char[,] result = new char[h, w];
        
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }
        
            return result;
        }
    }
}