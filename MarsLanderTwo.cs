using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Dynamic;
using System.Net.Http;
namespace CodeInGame {
    /**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
    class MarsLanderTwo {
        static int landingZoneLeft, landingZoneRight, landingZoneY;
        static int highestPointX, highestPointY;
        static string testData;

        static Random random = new Random();
        static int populationSize = 100;
        static int generationCount = 50;
        static double mutationRate = 0.1;

        static List<(int x, int y)> trajectorySolution = new List<(int x, int y)>();


        public static void Execute() {
            // Redirect standard input to read from a string (for testing purposes)
            testData = @"6
0 1500
1000 2000
2000 500
3500 500
5000 1500
6999 1000";
            Console.SetIn(new StringReader(testData));
            ReadSurfaceData();
            var (x, y, hSpeed, vSpeed, fuel, rotate, power) = (2500, 2700, 0, 0, 550, 0, 0); //ReadLanderState();
            Simulation(x, y, hSpeed, vSpeed, fuel, rotate, power);

            Console.WriteLine("\nPress Ctrl+X to go back to menu.");
            ConsoleKeyInfo cki = Console.ReadKey();
            Console.Clear();
            if((cki.Modifiers & ConsoleModifiers.Control) != 0 && cki.Key == ConsoleKey.X) {
                MainMenu.Main(null);
            }
        }

        static void Simulation(int x, int y, int hSpeed, int vSpeed, int startingFuel, int rotate, int power) {
            var (newRotate, newPower) = (rotate, power);
            List<(int rotate, int power)> instructions = new List<(int rotate, int power)>();
            var landed = false;
            var fuel = startingFuel;
            var interations = 0;
            while(!landed){
                interations++;
                Console.WriteLine($"Iteration: {interations}");
                while(fuel > 0) {
                    fuel--;
                    if(x > landingZoneLeft && x < landingZoneRight && y < landingZoneY) {
                        Console.WriteLine("Landed");
                        trajectorySolution = instructions;
                        landed = true;
                        break;
                    }
                    instructions.Add(CalculateNextMove(x, y, hSpeed, vSpeed));
                    //Console.WriteLine($"{newRotate} {newPower}");
                }
                fuel = startingFuel;
                instructions.Clear();
            }
            Console.WriteLine($"Found solution after {interations} and finished with fuel: {fuel}");
        }

        static void ReadSurfaceData() {
            int surfaceN = int.Parse(Console.ReadLine());
            highestPointY = int.MinValue;

            List<(int x, int y)> surfacePoints = new List<(int x, int y)>();

            for(int i = 0; i < surfaceN; i++) {
                var inputs = Console.ReadLine().Split(' ');
                surfacePoints.Add((int.Parse(inputs[0]), int.Parse(inputs[1])));
            }
            (landingZoneLeft, landingZoneRight, landingZoneY) = FindLandingZone(surfacePoints);

            (highestPointX, highestPointY) = FindHighestCoordinateBetweenShipAndLandingZone(surfacePoints, landingZoneLeft);

            Console.WriteLine($"Highest Point: ({highestPointX}, {highestPointY})");
        }

        static (int left, int right, int y) FindLandingZone(List<(int x, int y)> surfacePoints) {
            for(int i = 0; i < surfacePoints.Count - 1; i++) {
                if(surfacePoints[i].y == surfacePoints[i + 1].y) {
                    landingZoneLeft = surfacePoints[i].x;
                    landingZoneRight = surfacePoints[i + 1].x;
                    landingZoneY = surfacePoints[i].y;
                }
            }
            Console.WriteLine($"Landing Zone: ({landingZoneLeft}, {landingZoneRight}, {landingZoneY})");
            return (landingZoneLeft, landingZoneRight, landingZoneY);
        }

        static (int x, int y) FindHighestCoordinateBetweenShipAndLandingZone(List<(int x, int y)> surfacePoints, int landingZoneLeft) {
            return surfacePoints.Where(point => point.x < landingZoneLeft).OrderByDescending(point => point.y).First();
        }

        static (int coordX, int coorY, int hSpeed, int vSpeed, int fuel, int rotate, int power) ReadLanderState() {
            var inputs = Console.ReadLine().Split(' ');
            return (
                int.Parse(inputs[0]), int.Parse(inputs[1]),
                int.Parse(inputs[2]), int.Parse(inputs[3]),
                int.Parse(inputs[4]), int.Parse(inputs[5]), int.Parse(inputs[6])
            );
        }


        static (int rotate, int power) CalculateNextMove(int x, int y, int hSpeed, int vSpeed) {
            var solution = RunGeneticAlgorithm(x, y, hSpeed, vSpeed);
            return (solution[0], solution[1]);
        }

        static int[] RunGeneticAlgorithm(int x, int y, int hSpeed, int vSpeed) {
            var population = InitializePopulation();

            for(int generation = 0; generation < generationCount; generation++) {
                EvaluateFitness(population, x, y, hSpeed, vSpeed);
                population = Selection(population);
                Crossover(population);
                Mutate(population);
            }

            return population.OrderByDescending(p => p.Fitness).First().Genes;
        }

        static List<Individual> InitializePopulation() {
            var population = new List<Individual>();
            for(int i = 0; i < populationSize; i++) {
                population.Add(new Individual(new int[] { random.Next(-90, 91), random.Next(0, 5) }));
            }
            return population;
        }

        static void EvaluateFitness(List<Individual> population, int x, int y, int hSpeed, int vSpeed) {
            foreach(var individual in population) {
                var (endX, endY, endHSpeed, endVSpeed) = SimulateLanding(x, y, hSpeed, vSpeed, individual.Genes[0], individual.Genes[1]);
                individual.Fitness = CalculateFitness(endX, endY, endHSpeed, endVSpeed);
            }
        }

        static (int x, int y, int hSpeed, int vSpeed) SimulateLanding(int x, int y, int hSpeed, int vSpeed, int rotate, int power) {
            // Simplified simulation for one step
            double angle = rotate * Math.PI / 180;
            int newHSpeed = hSpeed + (int)(Math.Sin(angle) * power);
            int newVSpeed = vSpeed + (int)(Math.Cos(angle) * power) - 3; // Mars gravity
            int newX = x + newHSpeed;
            int newY = y + newVSpeed;
            return (newX, newY, newHSpeed, newVSpeed);
        }

        static double CalculateFitness(int x, int y, int hSpeed, int vSpeed) {
            double distanceToLandingZone = Math.Min(Math.Abs(x - landingZoneLeft), Math.Abs(x - landingZoneRight));
            double heightDifference = Math.Abs(y - landingZoneY);
            double speedPenalty = Math.Abs(hSpeed) + Math.Abs(vSpeed);
            return 1000000 / (distanceToLandingZone + heightDifference + speedPenalty + 1);
        }

        static List<Individual> Selection(List<Individual> population) {
            return population.OrderByDescending(p => p.Fitness).Take(populationSize / 2).ToList();
        }

        static void Crossover(List<Individual> population) {
            var offspring = new List<Individual>();
            while(offspring.Count < populationSize - population.Count) {
                var parent1 = population[random.Next(population.Count)];
                var parent2 = population[random.Next(population.Count)];
                var child = new Individual(new int[] {
                random.Next(2) == 0 ? parent1.Genes[0] : parent2.Genes[0],
                random.Next(2) == 0 ? parent1.Genes[1] : parent2.Genes[1]
            });
                offspring.Add(child);
            }
            population.AddRange(offspring);
        }

        static void Mutate(List<Individual> population) {
            foreach(var individual in population) {
                if(random.NextDouble() < mutationRate) {
                    individual.Genes[0] = random.Next(-90, 91);
                }
                if(random.NextDouble() < mutationRate) {
                    individual.Genes[1] = random.Next(0, 5);
                }
            }
        }


        class Individual {
            public int[] Genes { get; set; }
            public double Fitness { get; set; }
            public Individual(int[] genes) {
                Genes = genes;
            }
        }
    }
}
