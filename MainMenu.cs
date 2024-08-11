using System;
using System.Linq;
using System.Collections.Generic;
using CodeInGame;
using System.Reflection;

namespace CodeInGame {
    public class MainMenu {
        public static void Main(string[] args) {
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
            var response = Console.ReadKey();

            switch(response.Key) {
                case ConsoleKey.D1:
                    Console.WriteLine("Executing " + $"{nameof(AsciiArt.AsciiArtSolution)}");
                    AsciiArt.AsciiArtSolution();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Executing " + $"{nameof(ChuckNorris.UnarCoding)}");
                    ChuckNorris.UnarCoding();
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Executing " + $"{nameof(MimeTypes.FindMimeType)}");
                    MimeTypes.FindMimeType();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("Executing " + $"{nameof(Defibrilators.FindDefibrilator)}");
                    Defibrilators.FindDefibrilator();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("Executing " + $"{nameof(HorseRacing.FindPowerDiff)}");
                    HorseRacing.FindPowerDiff();
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine("Executing " + $"{nameof(NoSpoon.ThereIsNoSpoon)}");
                    NoSpoon.ThereIsNoSpoon();
                    break;
                case ConsoleKey.D7:
                    Console.WriteLine("Executing " + $"{nameof(SkyNet.SkyNetRevolutionOne)}");
                    NoSpoon.ThereIsNoSpoon();
                    break;
                    case ConsoleKey.D8:
                    Console.WriteLine("Executing " + $"{nameof(GeneticAlgorithm)}");
                    GeneticAlgorithm.Execute();
                    break;
                case ConsoleKey.D9:
                    Console.WriteLine("Executing " + $"{nameof(MarsLanderTwo)}");
                    MarsLanderTwo.Execute();
                    break;
                case ConsoleKey.X:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to continue...");
        }

        public static void FlushKeyboard() {
            while(Console.In.Peek() != -1)
                Console.In.Read();
        }
    }
}
