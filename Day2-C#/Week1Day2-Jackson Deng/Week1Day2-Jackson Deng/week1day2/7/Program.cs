namespace _7;
class Program
{
    static string PrintNumberInWord(int num)
    {
        if(num == 1)
        {
            return "ONE";
        }
        else if(num == 2)
        {
            return "TWO";
        }
        else if(num == 3)
        {
            return "THREE";
        }
        else if (num == 4)
        {
            return "FOUR";
        }
        else if (num == 5)
        {
            return "FIVE";
        }
        else if (num == 6)
        {
            return "SIX";
        }
        else if (num == 7)
        {
            return "SEVEN";
        }
        else if (num == 8)
        {
            return "EIGHT";
        }
        else if (num == 0)
        {
            return "NINE";
        }
        else
        {
            return "OTHER";
        }
    }

    static string PrintNumberInWord2(int num)
    {
        switch (num)
        {
            case 1:
                return "ONE";
                break;
            case 2:
                return "TWO";
                break;
            case 3:
                return "THREE";
                break;
            case 4:
                return "FOUR";
                break;
            case 5:
                return "FIVE";
                break;
            case 6:
                return "SIX";
                break;
            case 7:
                return "SEVEN";
                break;
            case 8:
                return "EIGHT";
                break;
            case 9:
                return "NINE";
                break;
            default:
                return "OTHER";
                break;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine(PrintNumberInWord(5));
        Console.WriteLine(PrintNumberInWord2(5));
    }
}

