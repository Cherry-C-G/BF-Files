//1.Given a list of int
//int[] arr1 = new int[] { 3, 9, 2, 8, 6, 5, 3, 2, 2 };
//a)	Using LINQ, Find the number and its square of an array which is more than 20
//The output should look like this:
//b)	Using LINQ, display the number and frequency of number from given array
//The output should look like this:
//Number 9   appears 1   times
//Number	8	appears	1	times
//Number	6	appears	1	times
//Number	5	appears	1	times




namespace Wk2Day1HW
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Find the number and its square of an array which is more than 20
            int[] arr1 = new int[] { 3, 9, 2, 8, 6, 5, 3, 2, 2 };
            var numbers = from n in arr1
                          where n * n > 20
                          select new { Number = n, Square = n * n };
            Console.WriteLine("Numbers and their squares:");
            foreach (var number in numbers)
            {
                Console.WriteLine($"Number: {number.Number}, Square: {number.Square}");
            }
            Console.WriteLine();

            // Display the number and frequency of number from given array
            var frequencies = from n in arr1
                              group n by n into g
                              select new { Number = g.Key, Frequency = g.Count() };
            Console.WriteLine("Numbers and their frequencies:");
            foreach (var frequency in frequencies)
            {
                Console.WriteLine($"Number: {frequency.Number}, Frequency: {frequency.Frequency}");
            }
        }
    }
}