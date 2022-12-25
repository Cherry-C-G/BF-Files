namespace stringConcatenation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////1.+ perator
            //string userName = "Celia";
            //string dateString = DateTime.Today.ToShortDateString();

            //string str = "Hello " + userName + ". Today is " + dateString + ".";
            //System.Console.WriteLine(str);

            ////2.string interpolation
            //string userName = "Celia";
            //string date = DateTime.Today.ToShortDateString();

            //string str = $"Hello {userName}. Today is {date}.";
            //System.Console.WriteLine(str);

            ////3.string.Concat
            //string[] words = { "Hello", "Celia", "Today", "is", "a", "good", "day", "." };

            //var unreadablePhrase = string.Concat(words);
            //System.Console.WriteLine(unreadablePhrase);
            ////4.string.Join
            //var readablePhrase = string.Join(" ", words);
            //System.Console.WriteLine(readablePhrase);

            //5.String.Format
            //Decimal pricePerOunce = 21.99m;
            //String s = String.Format("The current price is {0:C2} per ounce.",
            //                         pricePerOunce);
            //Console.WriteLine(s);
            // Result if current culture is en-US:
            //      The current price is $17.36 per ounce.
            // Displays 'The temperature is 20.4°C.'

            //6.StringBuilder.Append
            // Use StringBuilder for concatenation in tight loops.
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                sb.AppendLine(i.ToString());
            }
            System.Console.WriteLine(sb.ToString());
        }
    }
}