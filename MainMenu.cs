using System;
using System.Linq;
using System.Collections.Generic;
using CodeInGame;

public class MainMenu {
    public static void Main (string [] args) {
        string response = null;
        Console.Clear();
        Console.WriteLine("1 - AsciiArt");
        Console.WriteLine("2 - ChuckNorris");
        Console.WriteLine("3 - MimeTypes");
        Console.WriteLine("4 - Find Defibrilator");
        Console.WriteLine("5 - Find smallest power");
        Console.WriteLine("6 - Find next node");
        Console.WriteLine("x - Terminate program");

        //FlushKeyboard();
        response = Console.ReadLine();

        switch (response) {
            case "1":
                AsciiArt.AsciiArtSolution();
                break;
            case "2":
                ChuckNorris.UnarCoding();
                break;
            case "3":
                MimeTypes.FindMimeType();
                break;
            case "4":
                Defibrilators.FindDefibrilator();
                break;
            case "5":
                HorseRacing.FindPowerDiff();
                break;
            case "6":
                NoSpoon.ThereIsNoSpoon();
                break;
            case "x":
                Environment.Exit(0);
                break;
            default:
                Main(null);
                break;
        }
    }

    public static void FlushKeyboard () {
        while (Console.In.Peek() != -1)
            Console.In.Read();
    }
}