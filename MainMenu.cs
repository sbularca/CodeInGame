using System;
using System.Linq;
using System.Collections.Generic;
using CodeInGame;
using System.Reflection;

namespace CodeInGame {
    public class MainMenu {
        public static void Main(string[] args) {
            string response = null;
            Console.Clear();
            Console.WriteLine("1 - AsciiArt");
            Console.WriteLine("2 - ChuckNorris");
            Console.WriteLine("3 - MimeTypes");
            Console.WriteLine("4 - Find Defibrilator");
            Console.WriteLine("5 - Find smallest power");
            Console.WriteLine("6 - Find next node");
            Console.WriteLine("7 - SkyNetRevolution One");
            Console.WriteLine("8 - Genetic Algorithm");
            Console.WriteLine("9 - MarsLanderTwo");
            Console.WriteLine("x - Terminate program");

            //FlushKeyboard();
            response = Console.ReadLine();

            switch(response) {
                case "1":
                    Console.WriteLine("Executing " + $"{nameof(AsciiArt.AsciiArtSolution)}");
                    AsciiArt.AsciiArtSolution();
                    break;
                case "2":
                    Console.WriteLine("Executing " + $"{nameof(ChuckNorris.UnarCoding)}");
                    ChuckNorris.UnarCoding();
                    break;
                case "3":
                    Console.WriteLine("Executing " + $"{nameof(MimeTypes.FindMimeType)}");
                    MimeTypes.FindMimeType();
                    break;
                case "4":
                    Console.WriteLine("Executing " + $"{nameof(Defibrilators.FindDefibrilator)}");
                    Defibrilators.FindDefibrilator();
                    break;
                case "5":
                    Console.WriteLine("Executing " + $"{nameof(HorseRacing.FindPowerDiff)}");
                    HorseRacing.FindPowerDiff();
                    break;
                case "6":
                    Console.WriteLine("Executing " + $"{nameof(NoSpoon.ThereIsNoSpoon)}");
                    NoSpoon.ThereIsNoSpoon();
                    break;
                case "7":
                    Console.WriteLine("Executing " + $"{nameof(SkyNet.SkyNetRevolutionOne)}");
                    NoSpoon.ThereIsNoSpoon();
                    break;
                case "8":
                    Console.WriteLine("Executing " + $"{nameof(GeneticAlgorithm)}");
                    GeneticAlgorithm.Execute();
                    break;
                case "9":
                    Console.WriteLine("Executing " + $"{nameof(MarsLanderTwo)}");
                    MarsLanderTwo.Execute();
                    break;
                case "x":
                    Environment.Exit(0);
                    break;
                default:
                    Main(null);
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Main(null);
        }

        public static void FlushKeyboard() {
            while(Console.In.Peek() != -1)
                Console.In.Read();
        }
    }
}
