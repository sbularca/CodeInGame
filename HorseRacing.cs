using System;
using System.Collections.Generic;

namespace CodeInGame {
    public class HorseRacing {
        public static void FindPowerDiff() {
            int N = 1000; ///int.Parse(Console.ReadLine());
            int[] numbers = new int[N];
            List<int> differences = new List<int>();
            int max = numbers[N - 1];


            for(int i = 0; i < N; i++) {
                Random rnd = new Random();
                int pi = rnd.Next(0, 999999);
                Console.Write(pi + ", ");
                numbers[i] = pi;
            }

            Array.Sort(numbers);

            for(int i = 0; i < N - 1; i++) {

                differences.Add(numbers[i + 1] = numbers[i]);
            }

            differences.Sort();

            Console.WriteLine();
            Console.WriteLine(differences[0]);

            Console.WriteLine("\nPress Ctrl+X to go back to menu.");

            ConsoleKeyInfo cki = Console.ReadKey();
            if((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X) {
                MainMenu.Main(null);
            }

            FindPowerDiff();
        }
    }
}
