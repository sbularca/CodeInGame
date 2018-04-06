using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeInGame
{
    public static class ChuckNorris
    {
        public static void UnarCoding()
        {
            Console.Write("Introduce the text to be converted: ");
            string MESSAGE = Console.ReadLine();
            string output = string.Empty;
            string msgBinary = string.Empty;
            int ctrl = 0;

            byte[] bytes = Console.InputEncoding.GetBytes(MESSAGE);

            foreach (byte b in bytes)
            {
                msgBinary = msgBinary + Convert.ToString(b, 2).PadLeft(7, '0'); ;
            }

            Console.Write("Text introduced: " + MESSAGE);
            Console.Write("\nBinary represention: " + msgBinary);

            foreach (char c in msgBinary)
            {
                switch (c)
                {
                    case '1':
                        if (ctrl == 0) { ctrl = 1; output = "0 "; }
                        output = ctrl == 1 ? output + "0" : output + " " + "0 " + "0";
                        ctrl = 1;
                        break;
                    case '0':
                        if (ctrl == 0) { ctrl = 2; output = "00 "; }
                        output = ctrl == 2 ? output + "0" : output + " " + "00 " + "0";
                        ctrl = 2;
                        break;
                }
            }

            Console.WriteLine("\nEncrypted text: " + output);
            Console.WriteLine("\nPress Ctrl+X to go back to menu.");

            ConsoleKeyInfo cki = Console.ReadKey();
            if ((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X)
            {
                MainMenu.Main(null);
            }

            UnarCoding();
        }
    }
}