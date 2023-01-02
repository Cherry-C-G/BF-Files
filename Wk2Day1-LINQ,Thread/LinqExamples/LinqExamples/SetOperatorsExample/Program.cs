using System.Net.Mail;

namespace SetOperators
{
    internal class Program
    {
        static void Main ()
        {
            #region Distinct Example
            Console.WriteLine("Distinct Example");
            int[] ints = { 1, 2, 3, 1, 2, 3 };
            IEnumerable<int> noDuplicate = ints.Distinct(); // remove duplicates
            foreach (int i in noDuplicate)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            #endregion

            #region Except Example
            Console.WriteLine("Except Example");
            int[] dataSource1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] dataSource2 = { 2, 4, 6, 8, 10, 12, 14, 16 };

            // returns the elements that present in datasource 1 but not in datasource 2
            var exceptExample = dataSource1.Except(dataSource2);

            foreach (var x in exceptExample)
            {
                //Console.Write(x + " ");
            }
            Console.WriteLine();
            #endregion

            #region Intersect Example
            Console.WriteLine("Intersect Example");
            int[] dataSource3 = { 1, 2, 3, 4, 5, 6 };
            int[] dataSource4 = { 2, 4, 6, 8, 10 };
            // returns the common elements from both datasources
            var intersectExample = dataSource3.Intersect(dataSource4);
            foreach (var x in intersectExample)
            {
                //Console.Write(x + " ");
            }
            Console.WriteLine();
            #endregion

            #region Union Example
            Console.WriteLine("Union Example");
            int[] dataSource5 = { 1, 2, 3, 4, 5, 6 };
            int[] dataSource6 = { 1, 2, 3, 7, 8, 9 };
            // combines the multiple data sources into one data source by removing the duplicate elements
            var unionExample = dataSource5.Union(dataSource6);
            foreach (var x in unionExample)
            {
                // Console.Write(x + " ");
            }
            Console.WriteLine();
            #endregion
        }
    }
}

