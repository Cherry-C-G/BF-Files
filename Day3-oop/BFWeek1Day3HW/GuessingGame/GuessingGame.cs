using System;


namespace GuessingGame
{
    public class GuessingGame
    {

        private int answer;
        private int max;
        private int maxGuessesAllowed;
        private int numGuessesTaken;
        private Random generator;
        private bool gameOver;
        private int differential;
        public GuessingGame()
        {
            this.max = 0;
            this.generator = new Random();
        }
        public GuessingGame(int n)
        {
            this.max = n;
            this.generator = new Random();
        }
        public void newGame(int maxguess)
        {
            this.maxGuessesAllowed = maxguess;
            this.answer = this.generator.Next(this.max + 1);
            this.gameOver = false;
            this.differential = this.max;
            this.numGuessesTaken = 0;
        }
        public String guess(int g)
        {
            this.numGuessesTaken = this.numGuessesTaken + 1;
            if (this.numGuessesTaken == this.maxGuessesAllowed)
            {
                
                this.gameOver = true;
            }
            
            String s = new String(new char[] { });
            var d = 0;
            if (g == this.answer)
            {
                return "Congratulations";
            }
            if (g > this.max)
            {
                var st = "Guess out of range,The guess must be between 0 and " + this.max.ToString();
                return st;
            }
            else if (g > this.answer)
            {
                s = "Too High";
                d = g - this.answer;
            }
            else if (g < this.answer)
            {
                s = "Too Low";
                d = this.answer - g;
            }
            if (d > this.differential)
            {
                s = s + " Getting Colder";
            }
            else if (d < this.differential)
            {
                s = s + " Getting Warmer";
            }
            return s;
        }
        public bool isGameOver()
        {
            return this.gameOver;
        }
        static void Main(string[] args)
        {
           
            int mx;
            var ch = 'Y';
            do
            {
                Console.WriteLine("Welcome to the Guessing Game");
                Console.WriteLine("Enter the maximum number: ");
                mx = Convert.ToInt32(Console.ReadLine());
                var g1 = new GuessingGame(mx);
                Console.WriteLine("Enter the number of guesses allowed: ");
                var mxg = Convert.ToInt32(Console.ReadLine());
                g1.newGame(mxg);
                int i;
                for (i = 0; i < mxg; i++)
                {
                    Console.WriteLine("Enter your guess,remember it must be between 0 and " + mx.ToString());
                    int g = (int)Convert.ToInt64(Console.ReadLine());
                    var s = g1.guess(g);
                    Console.WriteLine(s);
                   // Console.WriteLine(g1.isGameOver());
                    if (s.Equals("Congratulations") == true)
                    {
                        break;
                    }
                }
                var b = g1.isGameOver();
                if (b == true)
                {
                    Console.WriteLine("Game Over");
                }
                Console.WriteLine("Would you like to play again,Y for yes, N for No: ");
                ch = Console.ReadLine()[0];
            } while (ch == 'Y' || ch == 'y');
            
        }
    }
    
}