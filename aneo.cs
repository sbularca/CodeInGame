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
class Aneo {
    public static void Execute() {
        int speedLimit = int.Parse(Console.ReadLine());
        int lightCount = int.Parse(Console.ReadLine());

        bool hasPassed = false;
        Dictionary<int, int> distanceWithDuration = new Dictionary<int, int>();

        for(int i = 0; i < lightCount; i++) {
            string[] inputs = Console.ReadLine().Split(' ');
            int distance = int.Parse(inputs[0]);
            int duration = int.Parse(inputs[1]);

            distanceWithDuration.Add(distance, duration);
        }

        while(speedLimit > 0 && !hasPassed) {
            foreach(var trafficLight in distanceWithDuration) {
                float result = ((((float)trafficLight.Key / 1000) / (float)speedLimit) * 3600) / (float)(trafficLight.Value);

                //increasing the error margin to make sure it doesn't fail on large data entries
                if(Math.Truncate((float)Math.Round(result * 100f) / 100f) % 2 != 0) {
                    hasPassed = false;
                    break;
                }
                else {
                    hasPassed = true;
                }
            }

            if(hasPassed) {
                break;
            }
            else {
                speedLimit--;
            }
        }

        Console.WriteLine(speedLimit);

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}
