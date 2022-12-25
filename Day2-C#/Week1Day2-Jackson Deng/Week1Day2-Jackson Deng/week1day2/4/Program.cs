namespace _4;
class Program
{
    static string pow(int a, int b)
    {
        return $"{a}   {b}   {Math.Pow(a, b)}   ";
    }

    static void Main(string[] args)
    {
        Console.WriteLine("a    b   pow(a,b)");
        int a = 1, b = 2;
        while(a <= 5)
        {
            Console.WriteLine(pow(a, b));
            a++;
            b++;
        }
    }
}

