namespace SourtListDesc
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 7, 3, 2, 5, 9, 7 };
            list.Sort();
            list.Reverse();

            Console.WriteLine(String.Join(", ", list));
        }
    }
}