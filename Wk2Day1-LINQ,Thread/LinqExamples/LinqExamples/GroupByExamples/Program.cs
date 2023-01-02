using System.Diagnostics;

namespace GroupByExample
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var groupByExample = numbers.GroupBy(x => x % 2);

            foreach (var x in groupByExample)
            {
                Console.WriteLine(x.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
                foreach (var item in x)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }

}


