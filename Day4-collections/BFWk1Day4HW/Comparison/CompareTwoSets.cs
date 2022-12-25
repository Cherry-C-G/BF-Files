namespace Comparison
{
    public class CompareTwoSets
    {
        // Function to compare two sets and retain 

        // elements that exist on both sets 

        public static void CompareSets(HashSet<int> set1,

                                        HashSet<int> set2)

        {

            Console.Write("Set 1: ");

            foreach (int i in set1)

                Console.Write(i + " ");

            Console.Write("\nSet 2: ");

            foreach (int i in set2)

                Console.Write(i + " ");



            // To retain elements 

            // that exist on both sets 

            set1.IntersectWith(set2);



            Console.Write("\nSet 1 after intersecting with Set 2 : ");

            foreach (int i in set1)

                Console.Write(i + " ");

        }
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();

            HashSet<int> set2 = new HashSet<int>();



            // Add elements to the set 

            set1.Add(100);

            set1.Add(99);

            set1.Add(88);

            set1.Add(77);

            set1.Add(66);



            set2.Add(55);

            set2.Add(66);

            set2.Add(44);

            set2.Add(77);

            set2.Add(100);



            CompareSets(set1, set2);
        }
    }
}