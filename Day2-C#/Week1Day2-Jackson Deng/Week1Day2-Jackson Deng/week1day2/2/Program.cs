namespace _2;
class Program
{
    static string convertTime(int mins)
    {
        int minsInYear = 60 * 24 * 365;
        int minsInDay = 60 * 24;
        int years = mins / minsInYear;
        int days = mins % minsInDay;
        return $"{mins} minutes is approximately {years} years and {days} days";
    } 


    static void Main(string[] args)
    {
        Console.WriteLine(convertTime(3456789));
    }
}

