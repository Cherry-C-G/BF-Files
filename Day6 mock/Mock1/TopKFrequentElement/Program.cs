//Given an unsorted integer array nums and an integer k, return the k most frequent elements. The answer can be returned in any order.
//Example 1:
//Input: numbers = [1, 1, 1, 2, 2, 3], k = 2
//Output: [1,2]


//Example 2:
//Input: numbers = [42], k = 1
//Output: [42]

//Please use the below method signature to complete this question:
//int[] findTopFrequentElements(int[] numbers, int k)
using System.Collections.Generic;
using System.Linq;
using System;

namespace TopKFrequentElement
{
    public class Program
    {

              static int[] findTopFrequentElements(int[] numbers, int k)
            {
                Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
                foreach(int number in numbers)
                {
                    if(!frequencyMap.ContainsKey(number))
                    {
                        frequencyMap[number] = 1;
                    }
                    else
                    {
                        frequencyMap[number]++;
                    }

                }
                var sortedFrequency = from entry in frequencyMap orderby entry.Value descending select entry;
                return sortedFrequency.Take(k).Select(x => x.Key).ToArray();
            }
        public static void Main(string[] args)
        {
            int[] numbers1 = { 1, 1, 1, 2, 2, 3 };
            int k1 = 2;
            int[] expected = { 1, 2 };
            int[] output = findTopFrequentElements(numbers1, k1);
            if (output.SequenceEqual(expected))
            {
                Console.WriteLine("passed");
            }
            else
            {
                Console.WriteLine("failed");
            }
        }
    }
}