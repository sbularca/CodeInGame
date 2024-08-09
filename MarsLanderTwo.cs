using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Dynamic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class MarsLanderTwo {
    static int landingZoneLeft, landingZoneRight, landingZoneY;
    static int highestPointX, highestPointY;
    static string testData;


    public static void Execute() {
        // Redirect standard input to read from a string (for testing purposes)
        testData = @"7
0 100
1000 500
2000 1500
3000 1000
4000 1000
5000 1600
6000 500";
        Console.SetIn(new StringReader(testData));
        ReadSurfaceData();
        while(true) {
            var (x, y, hSpeed, vSpeed, fuel, rotate, power) = ReadLanderState();
            var (newRotate, newPower) = CalculateNextMove(x, y, hSpeed, vSpeed);
            Console.WriteLine($"{newRotate} {newPower}");
        }
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

        (highestPointX, highestPointY) = FindHighestCoordinateBetweenShipAndLandingZone(surfacePoints, landingZoneLeft, landingZoneY);

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

    static (int x, int y) FindHighestCoordinateBetweenShipAndLandingZone(List<(int x, int y)> surfacePoints, int landingZoneLeft, int landingZoneRight) {
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
        int targetX = landingZoneLeft + (landingZoneRight - landingZoneRight) / 10;
        int rotate = 0;
        int power = 3;

        if(x < targetX - 100) {
            rotate = -15;
        }
        else if(x > targetX + 100) {
            rotate = 15;
        }
        else {
            rotate = 0;
        }

        if(vSpeed < -30) {
            power = 4;
        }
        else if(vSpeed > -10) {
            power = 2;
        }
        else {
            power = 3;
        }


        if(y < highestPointY + 100) {
            power = 4;
        }

        if(x < targetX) {
            rotate = -15;
        }
        else if(x > targetX) {
            rotate = 15;
        }

        if(vSpeed < -30) {
            power = 4;
        }
        else if(vSpeed > -10) {
            power = 2;
        }
        else {
            power = 3;
        }

        return (rotate, power);
    }
}
