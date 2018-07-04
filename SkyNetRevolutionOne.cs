using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeInGame {

    public class SkyNet {

        public static void SkyNetRevolutionOne () {

            string [] inputs;
            inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs [0]); // the total number of nodes in the level, including the gateways
            int L = int.Parse(inputs [1]); // the number of links
            int E = int.Parse(inputs [2]); // the number of exit gateways

            Node<bool> [] vertexes = new Node<bool>[N];
            for (int i = 0; i<N; i++)
            {
                vertexes[i] = new Node<bool>();
            }

            for (int i = 0 ; i < L ; i++) {
                inputs = Console.ReadLine().Split(' ');
                int N1 = int.Parse(inputs [0]); // N1 and N2 defines a link between these nodes
                int N2 = int.Parse(inputs [1]);
                vertexes[N1].links.Add(N2);
            }

            for (int i = 0 ; i < E ; i++) {
                int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
                vertexes[EI].data = true;
            }

            // game loop
            while (true) {
                int agentIndex = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

                if (vertexes[agentIndex].links.Count > 0)
                {
                    string linkToCut = SearchTree(vertexes.ToList(), vertexes[agentIndex], agentIndex);
                    
                    if (linkToCut!=null)
                        Console.WriteLine(linkToCut);
                }
                
            }

            Console.WriteLine("\nPress Ctrl+X to go back to menu.");
            ConsoleKeyInfo cki = Console.ReadKey();
            if ((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X) {
                MainMenu.Main(null);
            }

            SkyNetRevolutionOne();
        }

        private static string SearchTree (List<Node<bool>> vertexes, Node<bool> node, int agentIndex) {

            string linkToCut = null;
            List<Node<bool>> nextNodesSet = new List<Node<bool>>();
            nextNodesSet.Add(node);

            while (nextNodesSet.Count > 0) {
                for (int i = 0 ; i < nextNodesSet.Count ; i++) {

                    if (nextNodesSet [i].links.Count > 0) {
                        for (int j = 0 ; j < nextNodesSet [i].links.Count ; j++) {

                            int nodeIndex = nextNodesSet [i].links [j];

                            if (HasGateway(nextNodesSet [j])) {
                                linkToCut = agentIndex +" " + nodeIndex;
                                return linkToCut;
                            }
                            agentIndex = nodeIndex;
                            nextNodesSet.Add(vertexes [nodeIndex]);
                            nextNodesSet.Remove(nextNodesSet [i]);
                        }
                    }
                }
            }
            return null;
        }

        private static bool HasGateway(Node<bool> node)
        {   
            if (node.data)
                return true;
            return false;
        }

    }

    public class Node <T> {
        public T data;
        public List<int> links;
    }

}