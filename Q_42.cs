using System;

// Trapping rain water

public class TrapRainWater
{
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