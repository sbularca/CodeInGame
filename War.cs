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
class War
{
    public string [] deck = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    public List<string> cardsInPlay = new List<string>();
    
    static void Main(string[] args)
    {
        War sol = new War();
        Queue<string> player1Cards = new Queue<string>();
        Queue<string> player2Cards = new Queue<string>();

        int n = Int32.Parse(Console.ReadLine()); // the number of cards for player 1
        for (int i = 0; i < n; i++)
        {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            player1Cards.Enqueue(cardp1?.Remove(cardp1.Length - 1));
        }
        
        int m = Int32.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            player2Cards.Enqueue(cardp2?.Remove(cardp2.Length - 1));
        }
        

        while (player1Cards.Count > 0 || player2Cards.Count > 0)
        {
            var cp1 = player1Cards.Dequeue();
            var cp2 = player2Cards.Dequeue();
            
            sol.cardsInPlay.AddRange(new List<string>(){cp1, cp2});

            if (cp1 == cp2)
            {
                DoWar();
                break;
            }

            if (FirstGreaterThanSecond(cp1, cp2))
            {
                Console.Error.WriteLine( "Turn won by player 1...");
                foreach (var card in sol.cardsInPlay)
                {
                   player1Cards.Enqueue(card);
                }
            } 
            else
            {
                foreach (var card in sol.cardsInPlay)
                {
                    player2Cards.Enqueue(card);
                }
                sol.cardsInPlay.Clear();
                Console.Error.WriteLine("Turn won by player 2...");    
            }

            foreach (var card in player1Cards)
            {
                Console.Error.WriteLine($"Player 1 card - {card}");
            }
            
            foreach (var card in player2Cards)
            {
                Console.Error.WriteLine($"Player 2 card - {card}");
            }

        }

        // solutions
        // each turn first cards in the list are shown. check who wins. cards removed, cards go to player one list, at the end of the list, winner firs, looser after
        // if war, each player needs a temporary list with 3 cards on the table. forth gets played - reevaluate the result
        // constantly check if the player still has cards
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        if (player1Cards.Count == 0)
        {
            Console.Error.WriteLine("Player 1 Lost");
        } 
        else if (player2Cards.Count == 0)
        {
            Console.Error.WriteLine("Player 2 Lost");
        }
        else
        {
            Console.WriteLine("PAT");
        }
    }

    private static void DoWar()
    {
        Console.Error.WriteLine("This is war!!");
    }

    private static bool FirstGreaterThanSecond(string cp1, string cp2)
    {
        War war = new War();
        return Array.IndexOf(war.deck, cp1) > Array.IndexOf(war.deck, cp2);
    }
}