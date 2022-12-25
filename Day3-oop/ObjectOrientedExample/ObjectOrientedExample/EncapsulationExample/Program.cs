using System;

namespace EncapsulationExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Encapsulation Example");

        }
    }

    public class People
    {
        private string name;

        public string GetName()
        {
            return name;
        }

        private void SetName(string name)
        {
            this.name = name;
        }
    }
}
