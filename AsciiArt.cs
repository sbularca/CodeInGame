using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeInGame
{
    public static class AsciiArt
    {
        public static void AsciiArtSolution()
        {
            int L = 4;
            int H = 5;

            Console.WriteLine("Ascii Art started. Please type a text you want converted in Ascii Art:\n");
            string T = Console.ReadLine().ToUpper();

            string A = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";

            int indexA = 0;
            char[] alphabet = A.ToCharArray(); ;
            char[] word = T.ToCharArray();

            List<List<string>> letterMatrix = new List<List<string>>();

            //create the matrix of letters in asci
            for (int i = 0; i < H; i++)
            {
                string line = null;
                string lineX = GenerateAlphabet(i);
                letterMatrix.Add(new List<string>());

                for (int j = 0; j < lineX.Count(); j += L)
                {
                    letterMatrix[i].Add(lineX.Substring(j, L));
                }

                for (int j = 0; j < word.Length; j++)
                {
                    if (alphabet.Any(a => a == word[j]))
                    {
                        indexA = Array.IndexOf(alphabet, word[j]);
                        // Console.WriteLine(word[i] + " " + indexA);
                    }
                    else
                    {
                        indexA = alphabet.Length - 1;
                    }
                    line = line + letterMatrix[i][indexA];
                }
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPress Ctrl+X to go back to menu.");

            ConsoleKeyInfo cki = Console.ReadKey();
            if ((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X)
            {
                MainMenu.Main(null);
            }
            AsciiArtSolution();
        }

        static string GenerateAlphabet(int index)
        {
            List<string> asci = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                asci.Add(null);
            }

            asci[0] = " #  ##   ## ##  ### ###  ## # # ###  ## # # #   # # ###  #  ##   #  ##   ## ### # # # # # # # # # # ###     ### ";
            asci[1] = "# # # # #   # # #   #   #   # #  #    # # # #   ### # # # # # # # # # # #    #  # # # # # # # # # #   #       # ";
            asci[2] = "### ##  #   # # ##  ##  # # ###  #    # ##  #   ### # # # # ##  # # ##   #   #  # # # # ###  #   #   #       ## ";
            asci[3] = "# # # # #   # # #   #   # # # #  #  # # # # #   # # # # # # #    ## # #   #  #  # # # # ### # #  #  #           ";
            asci[4] = "# # ##   ## ##  ### #    ## # # ###  #  # # ### # # # #  #  #     # # # ##   #  ###  #  # # # #  #  ###      #  ";

            return asci[index];
        }
    }
}
