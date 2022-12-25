namespace _6;
class Program
{
    static int findNum(int[] nums)
    {
        int res = nums[0];

        for(int i = 1; i < nums.Length; i++)
        {
            res ^= nums[i];
        }
        return res;
    }

    static void Main(string[] args)
    {
        int[] nums = {4, 1, 2, 1, 2 };

        Console.WriteLine(findNum(nums));
    }
}

