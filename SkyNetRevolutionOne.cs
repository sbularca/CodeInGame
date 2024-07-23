using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeInGame {

    public class SkyNet {

        public static void SkyNetRevolutionOne() {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
            int L = int.Parse(inputs[1]); // the number of links
            int E = int.Parse(inputs[2]); // the number of exit gateways

            Node<int>[] nodes = new Node<int>[N];
            for(int i = 0; i < N; i++) {
                nodes[i] = new Node<int>();
                nodes[i].data = i;
            }

            for(int i = 0; i < L; i++) {
                inputs = Console.ReadLine().Split(' ');
                int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
                int N2 = int.Parse(inputs[1]);
                nodes[N1].links.Add(N2);
                nodes[N2].links.Add(N1);
            }

            for(int i = 0; i < E; i++) {
                int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
                nodes.FirstOrDefault(x => x.data == EI).hasData = true;
                Console.Error.WriteLine(EI);
            }

            Console.WriteLine("\nPress Ctrl+X to go back to menu.");

            // game loop
            while(true) {
                int agentNode = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
                int indexOfAgentNode = Array.IndexOf(nodes, nodes.FirstOrDefault(x => x.data == agentNode));

                if(nodes[indexOfAgentNode].links.Count > 0) {
                    string linkToCut = null;

                    int valueOfAgentNode = nodes[indexOfAgentNode].data;

                    Console.Error.WriteLine("Agent node index is:" + indexOfAgentNode);

                    for(int i = 0; i < nodes[indexOfAgentNode].links.Count; i++) {
                        int valueOfNodeToCheck = nodes[indexOfAgentNode].links[i];
                        linkToCut = valueOfNodeToCheck + " " + valueOfAgentNode;

                        Console.Error.WriteLine("Node checked is: " + valueOfNodeToCheck);
                        if(nodes.FirstOrDefault(x => x.data == valueOfNodeToCheck).hasData) {
                            Console.Error.WriteLine("Gateway is:" + valueOfNodeToCheck);
                            //Console.WriteLine(linkToCut);
                            break;
                        }
                    }
                    Console.WriteLine(linkToCut);
                }

                ConsoleKeyInfo cki = Console.ReadKey();
                if((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X) {
                    MainMenu.Main(null);
                }
                else
                    SkyNetRevolutionOne();
            }
        }
    }

    public class Node<T> {
        public T data;
        public bool hasData = false;
        public List<int> links = new List<int>();
    }

}
