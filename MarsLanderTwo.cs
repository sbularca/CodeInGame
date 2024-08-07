using System;
using System.Linq;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class MarsLanderTwo {
    public static void Execute() {
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.

        for(int i = 0; i < surfaceN; i++) {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
        }

        // game loop
        while(true) {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).

            // rotate power. rotate is the desired rotation angle. power is the desired thrust power.
            Console.WriteLine("-20 3");
        }
    }

    class Program {
        public static Random random = new Random();
        public const int PopulationSize = 100;
        public const int GeneLength = 100;  // Number of commands in a solution
        public const int MaxGenerations = 1000;
        public const double MutationRate = 0.01;
        public const double Gravity = 3.711;

        static void Main(string[] args) {
            // Initial state: x, y, hSpeed, vSpeed, fuel, rotation, power
            var initialState = new State(2500, 2500, 0, 0, 550, 0, 0);

            var population = new List<Solution>();
            for(int i = 0; i < PopulationSize; i++) {
                population.Add(new Solution(GeneLength));
            }

            for(int generation = 0; generation < MaxGenerations; generation++) {
                foreach(var sol in population) {
                    sol.Evaluate(initialState);
                }

                population = population.OrderByDescending(sol => sol.Fitness).ToList();
                var parents = population.Take(PopulationSize / 2).ToList();

                var newPopulation = new List<Solution>();
                for(int i = 0; i < PopulationSize; i++) {
                    var parent1 = parents[random.Next(parents.Count)];
                    var parent2 = parents[random.Next(parents.Count)];
                    var child = parent1.Crossover(parent2);
                    child.Mutate();
                    newPopulation.Add(child);
                }

                population = newPopulation;

                Console.WriteLine($"Generation {generation}: Best fitness = {population[0].Fitness}");
            }

            var bestSolution = population[0];
            foreach(var gene in bestSolution.Genes) {
                Console.WriteLine($"{gene.Rotation} {gene.Thrust}");
            }
        }
    }

    class State {
        public double X, Y, HSpeed, VSpeed, Fuel, Rotation, Power;

        public State(double x, double y, double hSpeed, double vSpeed, double fuel, double rotation, double power) {
            X = x;
            Y = y;
            HSpeed = hSpeed;
            VSpeed = vSpeed;
            Fuel = fuel;
            Rotation = rotation;
            Power = power;
        }

        public State Clone() {
            return new State(X, Y, HSpeed, VSpeed, Fuel, Rotation, Power);
        }
    }

    class Gene {
        public int Rotation, Thrust;
        public static Random random = new Random();

        public Gene(int rotation, int thrust) {
            Rotation = rotation;
            Thrust = thrust;
        }

        public static Gene RandomGene() {
            return new Gene(random.Next(-15, 16), random.Next(0, 5));
        }
    }

    class Solution {
        public List<Gene> Genes;
        public double Fitness;
        public static Random random = new Random();

        public Solution(int geneLength) {
            Genes = new List<Gene>();
            for(int i = 0; i < geneLength; i++) {
                Genes.Add(Gene.RandomGene());
            }
        }

        public void Evaluate(State initialState) {
            var state = initialState.Clone();
            foreach(var gene in Genes) {
                state.Rotation = Math.Max(-90, Math.Min(90, state.Rotation + gene.Rotation));
                state.Power = Math.Max(0, Math.Min(4, state.Power + gene.Thrust));
                state.Fuel -= state.Power;
                var rad = state.Rotation * (Math.PI / 180);
                state.HSpeed += -Math.Sin(rad) * state.Power;
                state.VSpeed += Math.Cos(rad) * state.Power - Program.Gravity;
                state.X += state.HSpeed;
                state.Y += state.VSpeed;
                if(state.Y <= 0) {
                    break;
                }
            }

            // Fitness: minimize horizontal and vertical speed at landing, stay within landing zone
            Fitness = Math.Max(0, 1000 - (Math.Abs(state.HSpeed) + Math.Abs(state.VSpeed) + Math.Abs(state.X - 2500) + Math.Abs(state.Y)));
        }

        public Solution Crossover(Solution other) {
            var child = new Solution(Genes.Count);
            for(int i = 0; i < Genes.Count; i++) {
                child.Genes[i] = (random.NextDouble() < 0.5) ? Genes[i] : other.Genes[i];
            }
            return child;
        }

        public void Mutate() {
            for(int i = 0; i < Genes.Count; i++) {
                if(Program.random.NextDouble() < Program.MutationRate) {
                    Genes[i] = Gene.RandomGene();
                }
            }
        }
    }
}
