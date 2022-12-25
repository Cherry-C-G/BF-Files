using System.Collections.Generic;

namespace LinkedListOccurrence
{
    public class Program
    {



        // Function to get the first and last occurrence 

        // of the specified elements in a list 

        public static void GetFirstAndLastOccurrence(LinkedList<int> list,

                                                     int x)

        {

            int first = -1, last = -1;



            LinkedListNode<int> current = list.First;



            // Traverse through the LinkedList 

            while (current != null)

            {

                // If the current node is equal to the given element 

                if (current.Value == x)

                {

                    // If this is the first occurrence of the element 

                    if (first == -1)

                        first = current.Value;



                    // Update the last occurrence of the element 

                    last = current.Value;

                }



                // Move to the next node 

                current = current.Next;

            }



            if (first != -1)

                Console.Write("First Occurrence = " + first +

                                "\nLast Occurrence = " + last);

            else

                Console.Write("Element not found");

        }



        // Driver code 

        public static void Main()

        {

            LinkedList<int> list = new LinkedList<int>();

            list.AddLast(10);

            list.AddLast(22);

            list.AddLast(25);

            list.AddLast(25);

            list.AddLast(25);

            list.AddLast(39);

            list.AddLast(40);

            list.AddLast(70);

            list.AddLast(89);

            list.AddLast(88);

            int x = 88;



            GetFirstAndLastOccurrence(list, x);

        }

    }



}