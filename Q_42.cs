using System;

// Trapping rain water

public class TrapRainWater
{

    public int Trap(int[] height) 
    {
        int amount = 0;

        int[] lBoundaries = new int[height.Length];
        int[] rBoundaries = new int[height.Length];

        lBoundaries[0] = height[0];

        for(int x = 1; x < height.Length; x++)
        {
            lBoundaries[x] = Math.Max(lBoundaries[x-1], height[x]);
        }

        lBoundaries[height.Length-1] = height[height.Length-1];

        for(int x = height.Length - 2; x >= 0; x--)
        {
            rBoundaries[x] = Math.Max(rBoundaries[x+1], height[x]);
        }

        for(int x = 1; x < height.Length-1; x++)
        {
            amount += Math.Min(lBoundaries[x], rBoundaries[x]) - height[x];
        }

        return amount;
    }

    public int TrapBruteForce(int[] height) 
    {
        int amount = 0;
        int currentGapLength = 0;      
        
        for(int x = 0; x < height.Length; x++)
        {
            int currentLeftBoundary = 0, currentRightBoundary = 0;
            
            for(int y = x; y >= 0; y--)
            {
                currentLeftBoundary = Math.Max(currentLeftBoundary, height[y]);
            }
            
            for(int y = x; y < height.Length; y++)
            {
                currentRightBoundary = Math.Max(currentRightBoundary, height[y]);
            }
            
            Console.WriteLine("currentLeftBoundary: " + currentLeftBoundary + " currentRightBoundary: " + currentRightBoundary + " height[x]: " + height[x]);
            
            amount += Math.Min(currentLeftBoundary, currentRightBoundary) - height[x];
        }
        
        return amount;
    }
}