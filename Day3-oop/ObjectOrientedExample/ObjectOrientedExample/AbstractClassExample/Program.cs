using System;

namespace AbstractClassExample
{
    //To declare an abstract class
    abstract class Animal
    {

        //Abstract method
        public abstract void AnimalSound();

        // normal method
        public void Sleep()
        {
            Console.WriteLine("Zzz");
        }
    }

    // subclasses should override the abstract methods
    class Dog : Animal
    {

        public override void AnimalSound()
        {
            Console.WriteLine("Woof, Woof"); ;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           Dog myDog = new Dog();
            myDog.Sleep();
            myDog.AnimalSound();
        }
    }
}
