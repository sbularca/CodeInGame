using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeInGame
{
    public class MimeTypes
    {
        public static void FindMimeType()
        {
            //nt N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
            //int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

            Console.Write("Number of elements = ");
            int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
            Console.Write("Number of files = ");
            int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

            Dictionary<string, string> extList = new Dictionary<string, string>();

            if (N > 0 && N < 10000 && Q > 0 && Q < 10000)
            {

                for (int i = 0; i < N; i++)
                {
                    Console.Write("File Extension & mime/type - ");
                    string[] inputs = Console.ReadLine().Split(' ');
                    string EXT = inputs[0]; // file extension
                    string MT = inputs[1]; // MIME type.

                    Console.WriteLine(inputs[0]);

                    if (EXT.Length < 11 && MT.Length < 51 && EXT.Length > 0 && MT.Length > 0 && !EXT.Contains(' ') && !MT.Contains(' '))
                        extList.Add(EXT.ToLower(), MT);
                }

                for (int i = 0; i < Q; i++)
                {
                    string fileInput = Console.ReadLine().ToLower(); // One file name per line.
                    string fileExt = null;

                    if (fileInput.Length < 257 && fileInput.Length > 0 && !fileInput.Contains(' '))
                    {
                        if (fileInput.Contains('.'))
                        {
                            if (!fileInput.Substring(fileInput.Length - 1).Contains('.'))
                            {
                                string[] temp = fileInput.Split('.');
                                fileExt = temp[temp.Length - 1];
                                Console.WriteLine(fileExt);
                            }

                        }
                        try
                        {
                            Console.WriteLine(extList.First(kvp => kvp.Key == fileExt).Value);
                        }
                        catch
                        {
                            Console.WriteLine("UNKNOWN");
                        }

                    }
                }

            }

            Console.WriteLine("\nPress Ctrl+X to go back to menu.");

            ConsoleKeyInfo cki = Console.ReadKey();
            if ((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X)
            {
                MainMenu.Main(null);
            }

            FindMimeType();
        }
    }
}