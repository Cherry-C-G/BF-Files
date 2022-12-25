using System.Text;

namespace _9;
class Program
{
    static void Main(string[] args)
    {
        //+
        string a = "+", b = " operator";
        Console.WriteLine(a + b);

        //(2) string interpolation
        a = "interpolation";
        Console.WriteLine($"string {a}");

        //(3) string.Concat
        a = "string";
        b = "concat";
        string s3 = string.Concat(a, b);
        Console.WriteLine(s3);

        //(4) String.Format
        (string, string) s4 = ("string", "format");
        Console.WriteLine("This's {0} {1}", s4.Item1, s4.Item2);

        //(5) String.Join
        string[] strs = { "string", "join" };
        string s5 = String.Join(" ", strs);
        Console.WriteLine(s5);

        //StringBuilder.Append
        StringBuilder sb = new StringBuilder("sb");
        sb.Append(" builder");
        Console.WriteLine(sb.ToString());
    }


}
