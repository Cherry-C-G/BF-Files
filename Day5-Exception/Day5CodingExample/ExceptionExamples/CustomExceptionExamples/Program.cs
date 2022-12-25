using ExceptionExamples;
using System;

namespace CustomExceptionExamples
{

   
    internal class Program
    {
        static void Main(string[] args)
        {
           Person person = new Person();
           person.Name = "#Mario";
            try
            {
                //Will thorw the user-defined Exception if the name is not valid
                ThrowException(person);
            }
            catch (InvalidPersonNameException e)
            {
                //if the user defined exception occurs, catch it and execute the following code
                Console.WriteLine("The InvalidPersonNameException has been caught");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine(person.Name);
            }
        }
        public static void ThrowException(Person p)
        {
            //if the name is not valid, throw the custom exception
            if (!IsValidName(p.Name))
            {
                throw new InvalidPersonNameException(p.Name);
            }
            //if the name is valid, nothing will happen
            return;
                
        }
        public static bool IsValidName(string name)
        {
            bool isValid = true;
            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
    }
}
