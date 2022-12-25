namespace DNA
{
    public class Program
    {
        static void Main(string[] args)
        {

            string reverseDNA = "GTCAG";
            var reversed = new String(reverseDNA
                .ToLower()
                .Replace('a', 'T')
                .Replace('t', 'A')
                .Replace('g', 'C')
                .Replace('c', 'G')
                .Reverse()
                .ToArray());
            Console.WriteLine(reversed);
        }
    }
}