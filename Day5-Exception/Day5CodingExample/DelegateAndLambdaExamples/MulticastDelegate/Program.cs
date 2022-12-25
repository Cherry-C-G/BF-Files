using System;

namespace MulticastDelegate
{
    public delegate void MyDelegate();
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDelegate md1 = ClassA.MethodA;
            MyDelegate md2 = new ClassB().MethodB;
            MyDelegate md3 = md1 + md2;
            md3(); 

        }
    }
    public class ClassA
    {
      public static void MethodA()
        {
            Console.WriteLine("This is A method");
        }
    }
    public class ClassB
    {
        public void MethodB()
        {
            Console.WriteLine("This is B method");
        }
    }

}
