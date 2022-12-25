namespace xor
{
    public class Program
    {
        // Function to find the
        public static int findSingle(int[] A, int ar_size)
        {

            // Iterate over every element
            for (int i = 0; i < ar_size; i++)
            {

                // Initialize count to 0
                var count = 0;
                for (int j = 0; j < ar_size; j++)
                {

                    // Count the frequency
                    // of the element
                    if (A[i] == A[j])
        {
          count++;
        }
}

// if the frequency of the
// element is one
if (count == 1)
{
    return A[i];
}
    }
 
    // if no element exist at most once
    return -1;
  }
  public static void Main(String[] args)
{
    //int[] ar = { 2, 2, 1 };
            int[] ar = {4, 1, 2, 1,2 };
            var n = ar.Length;

    // Function call
    Console.WriteLine("Output:" +
                      Program.findSingle(ar, n).ToString());
}
}
    }
