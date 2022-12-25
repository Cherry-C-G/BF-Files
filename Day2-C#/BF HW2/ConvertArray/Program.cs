

namespace ConvertArray
{
    //Convert an array of char to an array of int.

    public class Program
    {
        static void Main(string[] args)
        {
            char[] A = { '1', '2', '4','6','8' };
            int[] Aint = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                Aint[i] = Convert.ToInt32(A[i].ToString());

                Console.WriteLine(Aint[i]);
            }
        }
    }
}