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
class Solution
{
    static void Main(string[] args)
    {
        List<string> player1Queue = new List<string>();
        List<string> player2Queue = new List<string>();
        
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        for (int i = 0; i < n; i++)
        {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            player1Queue.Add(cardp1);
        }
        
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            player2Queue.Add(cardp2);
        }

        // solutions
        // each turn checks who wins. if win, cards go to player one list, at the end of the list, winner firs, looser after
        // if war, each player needs a temporary list with 3 cards on the table. forth gets played - reevaluate the result
        // constantly check if the player still has cards
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        Console.WriteLine("PAT");
    }
}