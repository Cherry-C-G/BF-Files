namespace Palindrome
{
    public class Program
    {

        public static bool Palindrome(string s)
        {
            var left = 0;
            var right = s.Length-1;

            while(left < right)
            {
                if (!char.IsLetter(s[left]))
                {
                    left++;
                }else if (!char.IsDigit(s[left]))
                {
                    right--;
                }
                else
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }
                    left++;
                    right--;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            //string str = "race a car";
            string str = "A man, a plan, a canel: Pananma";
            bool flag = Palindrome(str);
            Console.WriteLine(flag);
        }
    }
}