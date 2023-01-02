//Given a string of words Eg. string sentence = "the quick brown fox jumps over the lazy dog";
//Using LINQ, Group the words by their length in ascending order and display them.
//The output should look like this:
//Words of length 3: THE,FOX,THE, DOG
//Words of length 4 : OVER, LAZY
//Words of length 5: QUICK, BROWN, JUMPS
//* use both query syntax and method syntax to achieve that

namespace GroupWords
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Group the words by their length in ascending order (query syntax)
            string sentence = "the quick brown fox jumps over the lazy dog";
            var wordsByLength = from w in sentence.Split()    //split the sentence into an array of words
                                group w by w.Length into g    // group the words by length
                                orderby g.Key ascending
                                select new { Length = g.Key, Words = g };  // create a new anonymous object with the properties Length and Words for each group
            Console.WriteLine("Words grouped by length (query syntax):");
            foreach (var group in wordsByLength)
            {
                Console.Write($"Words of length {group.Length}: ");
                Console.WriteLine(string.Join(", ", group.Words));
            }
            Console.WriteLine();

            // Group the words by their length in ascending order (method syntax)
            var wordsByLength2 = sentence.Split()
                                         .GroupBy(w => w.Length)
                                         .OrderBy(g => g.Key)    //key = length of each word
                                         .Select(g => new { Length = g.Key, Words = g });
            Console.WriteLine("Words grouped by length (method syntax):");
            foreach (var group in wordsByLength2)
            {
                Console.Write($"Words of length {group.Length}: ");
                Console.WriteLine(string.Join(", ", group.Words));
            }



        }
    }
}