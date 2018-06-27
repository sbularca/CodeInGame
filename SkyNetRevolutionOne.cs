using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeInGame {

    public class SkyNet {

        public static void SkyNetRevolutionOne () {

            //string [] inputs;
            //inputs = Console.ReadLine().Split(' ');
            int N = 4; // int.Parse(inputs [0]); // the total number of nodes in the level, including the gateways
            int L = 4; //int.Parse(inputs [1]); // the number of links
            int E = 1; //int.Parse(inputs [2]); // the number of exit gateways
            
            /*for (int i = 0 ; i < L ; i++) {
                inputs = Console.ReadLine().Split(' ');
                int N1 = int.Parse(inputs [0]); // N1 and N2 defines a link between these nodes
                int N2 = int.Parse(inputs [1]);
            }*/

            int [][] link = new int [][] { new int[]{1, 2}, new int [] {3}, new int [] {3} };
            int [] exits = new int[1];

            /*for (int i = 0 ; i < E ; i++) {
                int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            }*/

            // game loop
 //           while (true) {
                ConsoleKeyInfo key = Console.ReadKey();
                int SI = int.Parse(key.KeyChar.ToString()); // The index of the node on which the Skynet agent is positioned this turn

                int nodeOne = link[0][1];

                Console.WriteLine (nodeOne);

                Console.WriteLine("0 1");
 //           }

            Console.WriteLine("\nPress Ctrl+X to go back to menu.");
            ConsoleKeyInfo cki = Console.ReadKey();
            if ((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X) {
                MainMenu.Main(null);
            }

            SkyNetRevolutionOne();
        }

    }
}