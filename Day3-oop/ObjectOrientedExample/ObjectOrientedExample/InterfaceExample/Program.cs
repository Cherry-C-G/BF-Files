using System;
using System.Runtime.CompilerServices;

namespace InterfaceExample
{
    //Resolve ambiguity
    interface ISpeak
    {
        abstract void SayHello(); // abstract by default

    }
    interface ISay
    {
        void SayHello(); //abstract by default
      
    }
    class Person : ISpeak, ISay
    {
        public void SayHello()
        {
            Console.WriteLine("Hello") ;
        }
    }


    interface IShape
    {
        void PrintShape(); // abstract by default
    }
    class Triangle : IShape
    {
        //must implement the abstract method in IShape interface
        public void PrintShape()
        {
            Console.WriteLine("Triangle");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.SayHello();

        }
    }
}
