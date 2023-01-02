namespace TopKFrequent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            int[] nums2 = { 1 };

            PrintArr(TopKFrequent(nums, 2));
            Console.WriteLine();
            PrintArr(TopKFrequent(nums2, 1));
            
        }

        public static int[] TopKFrequent(int[] nums, int k)
        {
            //int[] nums = { 1, 1, 1, 2, 2, 3 };
            // group the elements have the same value,
            // the key would be the number itself, the value should be all of the number with same value
            var result = nums.GroupBy(num => num)
            .OrderByDescending(group => group.Count()) // sort the group in descending order based on the number of elements in each group
            .Take(k) 
            .Select(group => group.Key)
            .ToArray();

            return result;
        }

        public static void PrintArr(int[] arr)
        {
            foreach (int number in arr)
            {
                Console.Write(number + " ");
            }
        }
    }
}