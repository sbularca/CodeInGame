using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Workfile {
    public static void Execute() {
        string H1 = Console.ReadLine();
        string H2 = Console.ReadLine();
        string V1 = Console.ReadLine();
        string V2 = Console.ReadLine();

        char[,] grid = new char[12, 12];

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // 1. find what letters are common to in H1 and H2 with V1 and V2
        //    check first letter in H1 - does it exist in V1. if yes, check which next letters exist in V2. if the
        // index of the next later is too close, discard solution. if not, search for a similar solution in H2
        //  after that move to the next letter in H1 following the same process until all letters in H1 have been checked
        // 2. eliminate base bad solutions, where letters are either too close, either too far
    }
}

public class Coord {
    public int vIndex;
    public int hIndex;
}
