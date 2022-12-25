namespace _5;
class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 3, 5, 2, 5, 5, 5, 0 };
        int max = 0;
        foreach(int i in nums){
            if(i > max)
            {
                max = i;
            }
        }
        int count = 0;
        foreach (int i in nums)
        {
            if(i == max)
            {
                count++;
            }
        }

        Console.WriteLine($"max: {max}, count = {count}");

    }
}

