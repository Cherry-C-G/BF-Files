namespace ConvertMinute
{
    public class Program
    {
        static void Main(string[] args)
        {
            //2. Write a C# program to convert minutes into a number of years and days.
            Console.Write("Input the number of minutes:");
            int minutes = Convert.ToInt32(Console.ReadLine());
            int year = minutes / 525600;
            int remainingMinutes = minutes % 525600;
            int day = remainingMinutes / 1440;
            Console.WriteLine(minutes + " minutes is approximately " + year + " years and " + day + " days.");
        }
    }
}