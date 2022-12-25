




namespace BFWk1Day4HW
{
    public class ReverseList
    {
        static void Main(string[] args)
        {
            //1.Write a C# program to iterate a List in reverse order.
            List<string> weather = new List<string>() {"Sunny", "Stormy","Windy","Rainy","Snowy" };
            weather.Reverse();
            foreach(var i in weather)
            {
                Console.WriteLine(i);
            }
            
        }
    }
}