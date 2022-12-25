namespace FirstUniqueChar
{
    public class Program
    {
        public static int FirstUniqueChar(string s)
        {
            var countChar = new int[256];
            foreach (var i in s)
            {
                countChar[i]++;
            }
            for (int i = 0; i<s.Length; i++)
            {
                if(countChar [s[i]] ==1)
                {
                    return i;
                }
            }
            return -1;
        }
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //}
    }
}