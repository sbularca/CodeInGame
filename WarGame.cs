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
class WarGame
{
    static void Main(string[] args)
    {
        string [] deck = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        Queue<string> cardsPlayer1 = new Queue<string>();
        Queue<string> cardsPlayer2 = new Queue<string>();

        int turns = 0;
        
        int n = Int32.Parse(Console.ReadLine()); // the number of cards for player 1
        for (int i = 0; i < n; i++)
        {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            cardsPlayer1.Enqueue(cardp1?.Remove(cardp1.Length - 1));
        }
        
        int m = Int32.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            cardsPlayer2.Enqueue(cardp2?.Remove(cardp2.Length - 1));
        }
        
        while (cardsPlayer1.Count > 0 && cardsPlayer2.Count > 0)
        {
            List<string> playedPlayer1 = new List<string>();
            List<string> playedPlayer2 = new List<string>();
            
            // Goto/repeat is the fastest option
            Repeat:
            var cp1 = cardsPlayer1.Dequeue();
            playedPlayer1.Add(cp1);
            
            var cp2 = cardsPlayer2.Dequeue();
            playedPlayer2.Add(cp2);
            
            if (cp1 == cp2)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (cardsPlayer1.Count <= 0)
                    {
                        Console.WriteLine("PAT");
                        return;
                    }
                    
                    playedPlayer1.Add(cardsPlayer1.Dequeue());
                }
                
                for (int i = 0; i < 3; i++)
                {
                    if (cardsPlayer2.Count <= 0)
                    {
                        Console.WriteLine("PAT");
                        return;
                    }
                    
                    playedPlayer2.Add(cardsPlayer2.Dequeue());
                }
                goto Repeat;
            }
            
            // Add all cards in one list for easy enqueuing
            playedPlayer1.AddRange(playedPlayer2);
            
            if (Array.IndexOf(deck, cp1) > Array.IndexOf(deck, cp2))
            {
                foreach (var card in playedPlayer1)
                {
                    cardsPlayer1.Enqueue(card);
                }
            }
            else
            {
                foreach (var card in playedPlayer1)
                {
                    cardsPlayer2.Enqueue(card);
                }
            }
            
            turns++;
        }

        if (cardsPlayer1.Count == 0)
        {
            Console.WriteLine($"2 {turns}");
            return;
        }

        if (cardsPlayer2.Count == 0)
        {
            Console.WriteLine($"1 {turns}");
        }
    }
}