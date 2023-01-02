namespace OrderingOperatorsExample
{
    internal class Program
    {
        static void Main()
        {
            #region OrderBy Example
            string[] nameList = { "Emily", "Alice", "Alan", "Adam", "Bill", "Cindy", "Dave", "Eddie", "Zac" };
            //Sort by length first(des), if the length is the same sort by first letter(asc),
            //if the first letter is the same sort by second letter(des)
            IEnumerable<string> query = from name in nameList
                                        orderby name.Length descending, name.Substring(0, 1), name.Substring(1, 2) descending
                                        select name;

            IEnumerable<string> method = nameList.OrderBy(name => name.Substring(0, 1))
                                                    .ThenBy(name => name.Length)
                                                    .ThenBy(name => name.Substring(1, 2));

            foreach (string name in method)
            {
                //Console.WriteLine(name);
            }

            #endregion

            #region Reverse Example
            int[] ints = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var reversedInts = ints.Reverse();
            foreach (int i in reversedInts)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            var reversedNameList = nameList.Reverse();
            foreach (string name in reversedNameList)
            { 
                //Console.WriteLine(name);
            }
            #endregion

        }
    }
}

