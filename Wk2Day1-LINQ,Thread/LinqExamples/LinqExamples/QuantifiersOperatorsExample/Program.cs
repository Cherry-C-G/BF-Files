namespace QuantifiersOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 11, 22, 33, 44, 55 };

            //All Example
            var checkGreaterThanTen = intArray.All(x => x > 10);  // check if all the elements in intArray are greater than 10
            Console.WriteLine("Are all numbers greater than 10? {0}", checkGreaterThanTen);

            //Any Example
            var checkAnyEvenNumber = intArray.Any(x => x % 2 == 0); //check the presence of any even number in the intArray
            var checkAnyEvenNumber2 = intArray.Where(x => x % 2 == 1).Any(); // filter first then check presence
            Console.WriteLine(checkAnyEvenNumber);
            Console.WriteLine(checkAnyEvenNumber2);
            //Contains Example
            var checkContainsTen = intArray.Contains(10);
            Console.WriteLine(checkContainsTen);
        }
    }
}


