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
    private static string [] deck = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

    static void Main(string[] args)
    {
        
        Queue<string> player1Cards = new Queue<string>();
        Queue<string> player2Cards = new Queue<string>();
        List<string> onTableP1 = new List<string>();
        List<string> onTableP2 = new List<string>();
        
        int turns = 0;
        
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
        
        while (player1Cards.Count > 0 && player2Cards.Count > 0)
        {
            onTableP1.Clear();
            onTableP2.Clear();
            
            Repeat:    
            var cp1 = player1Cards.Dequeue(); 
            var cp2 = player2Cards.Dequeue();

            onTableP1.Add(cp1);
            onTableP2.Add(cp2);
            
            if (cp1 == cp2)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (player1Cards.Count <= 0)
                    {
                        Console.WriteLine("PAT");
                        return;
                    }
                    onTableP1.Add(player1Cards.Dequeue());
                }
                
                for (int i = 0; i < 3; i++)
                {
                    if (player2Cards.Count <= 0)
                    {
                        Console.WriteLine("PAT");
                        return;
                    }
                    onTableP2.Add(player2Cards.Dequeue());
                }
                goto Repeat;
            }

            onTableP1.AddRange(onTableP2);
            
            if (Array.IndexOf(deck, cp1) > Array.IndexOf(deck, cp2))
            {
                foreach (var card in onTableP1)
                {
                    player1Cards.Enqueue(card);
                }
            }
            else
            {
                foreach (var card in onTableP1)
                {
                    player2Cards.Enqueue(card);
                }
            }
            
            turns++;
        }

        if (player1Cards.Count == 0)
        {
            Console.WriteLine($"2 {turns}");
            return;
        }

        if (player2Cards.Count == 0)
        {
            Console.WriteLine($"1 {turns}");
        }
    }
}