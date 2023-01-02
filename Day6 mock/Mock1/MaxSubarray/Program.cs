//Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
//A subarray is a contiguous part of an array.
//Example 1:
//Input: nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
//Output: 6
//Explanation: [4,-1,2,1] has the largest sum = 6.
 
 
//Example 2:
//Input: nums = [1]
//Output: 1


//Example 3:
//Input: nums = [5, 4, -1, 7, 8]
//Output: 23



namespace MaxSubarray
{
    public class Program
    {

        static void Main(string[] args)
        {
            //int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //int[] nums = { 1};
            int[] nums = { 5, 4, -1, 7, 8 };
            int maxSum = int.MinValue;
            int curSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                curSum = Math.Max(curSum + nums[i], nums[i]);
                maxSum = Math.Max(maxSum, curSum);
            }
            Console.WriteLine(maxSum);
        }
    }
}