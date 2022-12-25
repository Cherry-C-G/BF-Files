using System;
using System.Collections.Concurrent;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//1.Read from the Holiday.txt and count the number of occurrences of each word(use Dictionary).


namespace BFWk1Day5hw
{
    public class Program
    {
        static void Main(string[] args)
        {

            string text = System.IO.File.ReadAllText(@"C:\Beaconfire\Day5-Exception\Day5 Assignment\Holiday.txt");
            var obj = new object();
            string textToLower = text.ToLower();
            Regex reg_exp = new Regex("[^a-z0-9]");
            textToLower = reg_exp.Replace(textToLower, " ");
            string[] Value = textToLower.Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
            var wordsToMatch = new ConcurrentDictionary<string, int>();

            for (int i = 0; i < Value.Length; i++)
            {
                if (wordsToMatch.ContainsKey(Value[i]))
                {
                    int value = wordsToMatch[Value[i]];
                    wordsToMatch[Value[i]] = value + 1;
                }
                else
                {
                    wordsToMatch.TryAdd(Value[i], 1);
                }
            }



            Console.WriteLine("The number of counts for each words are:");
            foreach (KeyValuePair<string, int> kvp in wordsToMatch)
            {
                Console.WriteLine("Counts: " + kvp.Value + " times for " + kvp.Key);
            }
            Console.ReadKey();




        }
    }
}


