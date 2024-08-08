using System;
using System.Linq;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class MarsLanderTwo {
    static int landingZoneLeft, landingZoneRight, landingZoneY;

    static void Main(string[] args) {
        ReadSurfaceData();

        while(true) {
            var (x, y, hSpeed, vSpeed, fuel, rotate, power) = ReadLanderState();
            var (newRotate, newPower) = CalculateNextMove(x, y, hSpeed, vSpeed);
            Console.WriteLine($"{newRotate} {newPower}");
        }
    }

    static void ReadSurfaceData() {
        int surfaceN = int.Parse(Console.ReadLine());
        int prevX = -1, prevY = -1;
        for(int i = 0; i < surfaceN; i++) {
            var inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]);
            int landY = int.Parse(inputs[1]);
            if(landY == prevY) {
                landingZoneLeft = prevX;
                landingZoneRight = landX;
                landingZoneY = landY;
            }
            prevX = landX;
            prevY = landY;
        }
    }

    static (int x, int y, int hSpeed, int vSpeed, int fuel, int rotate, int power) ReadLanderState() {
        var inputs = Console.ReadLine().Split(' ');
        return (
            int.Parse(inputs[0]), int.Parse(inputs[1]),
            int.Parse(inputs[2]), int.Parse(inputs[3]),
            int.Parse(inputs[4]), int.Parse(inputs[5]), int.Parse(inputs[6])
        );
    }

    static (int rotate, int power) CalculateNextMove(int x, int y, int hSpeed, int vSpeed) {
        int targetX = landingZoneLeft + (landingZoneRight - landingZoneLeft) / 10;
        int rotate = 0;
        int power = 3;

        if(Math.Abs(x - targetX) > 0) {
            rotate = x < targetX ? -30 : 30;
        }

        if(y - landingZoneY < 1000 && Math.Abs(hSpeed) < 20) {
            rotate = 0;
        }

        if(vSpeed > -30) {
            power = 4;
        }

        return (rotate, power);
    }
}
