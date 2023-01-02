//Example 1:
//Input: commands = "UUDL"
//Output: [-1, 1]
 
 
//Example 2:
//Input: commands = "UUULRDUR"
//Output: [1, 3]﻿


using System;
namespace Mock1
{
    public class RobotWalk
    {
         static int[] walk(string commands)
        {
            int[] startingPosition = { 0, 0 };
            foreach(char c in commands)
            {
                if(c == 'U')
                {
                    startingPosition[1]+=1;
                }
                else if(c == 'D')
                {
                    startingPosition[1] -= 1;
                }
                else if (c == 'L')
                {
                    startingPosition[0]-=1;
                }
                else if (c == 'R')
                {
                    startingPosition[0] += 1;
                }
            }
            return startingPosition;
        }
        static void Main(string[] args)
        {
            //int[] Destination = walk("UUDL");
            int[] Destination = walk("UUULRDUR");
            Console.WriteLine($"The Destination is:({Destination[0]},{Destination[1]})");
        }
    }
}