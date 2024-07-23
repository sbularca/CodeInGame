using System;
using System.Collections.Generic;
using System.Linq;

class GeneticAlgorithm {
    private int populationSize;
    private double mutationRate;
    private double crossoverRate;
    private int generations;
    private List<Individual> population;

    public GeneticAlgorithm(int populationSize, double mutationRate, double crossoverRate, int generations) {
        this.populationSize = populationSize;
        this.mutationRate = mutationRate;
        this.crossoverRate = crossoverRate;
        this.generations = generations;
        this.population = new List<Individual>();
        InitializePopulation();
    }

    public static void Execute() {
        GeneticAlgorithm ga = new GeneticAlgorithm(
            populationSize: 100,
            mutationRate: 0.01,
            crossoverRate: 0.95,
            generations: 100
        );
        ga.Run();
    }

    private void InitializePopulation() {
        for(int i = 0; i < populationSize; i++) {
            population.Add(new Individual());
        }
    }

    public void Run() {
        for(int i = 0; i < generations; i++) {
            List<Individual> newPopulation = new List<Individual>();
            for(int j = 0; j < populationSize; j++) {
                Individual parent1 = SelectParent();
                Individual parent2 = SelectParent();
                Individual child = Crossover(parent1, parent2);
                Mutate(child);
                newPopulation.Add(child);
            }
            population = newPopulation;
        }
        Individual best = population.OrderByDescending(ind => ind.Fitness).First();
        Console.WriteLine("Best solution: " + best);
    }

    private Individual SelectParent() {
        double totalFitness = population.Sum(ind => ind.Fitness);
        double randomValue = new Random().NextDouble() * totalFitness;
        double runningSum = 0;
        foreach(Individual ind in population) {
            runningSum += ind.Fitness;
            if(runningSum >= randomValue) {
                return ind;
            }
        }
        return population.Last();
    }

    private Individual Crossover(Individual parent1, Individual parent2) {
        if(new Random().NextDouble() > crossoverRate) {
            return new Random().Next(2) == 0 ? new Individual(parent1) : new Individual(parent2);
        }
        Individual child = new Individual();
        for(int i = 0; i < child.Genes.Length; i++) {
            child.Genes[i] = new Random().Next(2) == 0 ? parent1.Genes[i] : parent2.Genes[i];
        }
        return child;
    }

    private void Mutate(Individual individual) {
        for(int i = 0; i < individual.Genes.Length; i++) {
            if(new Random().NextDouble() < mutationRate) {
                individual.Genes[i] = individual.Genes[i] == 0 ? 1 : 0;
            }
        }
    }
}

class Individual {
    public int[] Genes { get; private set; }
    public double Fitness { get { return EvaluateFitness(); } }

    public Individual() {
        Genes = new int[10];
        RandomizeGenes();
    }

    public Individual(Individual copyFrom) {
        Genes = (int[])copyFrom.Genes.Clone();
    }

    private void RandomizeGenes() {
        Random random = new Random();
        for(int i = 0; i < Genes.Length; i++) {
            Genes[i] = random.Next(2);
        }
    }

    private double EvaluateFitness() {
        int targetSum = 15;
        int actualSum = Genes.Sum();
        return 1.0 / (1 + Math.Abs(targetSum - actualSum));
    }

    public override string ToString() {
        return string.Join("", Genes) + " (" + Fitness + ")";
    }
}
