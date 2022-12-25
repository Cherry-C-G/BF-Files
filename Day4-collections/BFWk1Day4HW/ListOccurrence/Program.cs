namespace ListOccurrence
{
    public class Program
    {
        // Function to get the first and last occurrence 

        // of the specified elements in a list 

        public static void GetFirstAndLastOccurrence(List<int> list,

                                                     int x)

        {

            int first = -1, last = -1;



            for (int i = 0; i < list.Count; i++)

            {

                if (list[i] == x)

                {

                    if (first == -1)

                        first = i;

                    last = i;

                }

            }



            if (first != -1)

                Console.Write("First Occurrence = " + first +

                                "\nLast Occurrence = " + last);

            else

                Console.Write("Element not found");

        }


        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 7, 6, 7, 5, 3, 4, 7, 8, 9 };

            int x = 7;



            GetFirstAndLastOccurrence(list, x);
        }
    }
}