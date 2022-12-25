using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExample
{
    //base class
    public class Shape
    {
        //virtual method
        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks!");
        }
    }


    public class Circle : Shape
    {
        //override the virtual method in base class
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }
    public class Rectangle : Shape
    {
        //override the virtual method in base class
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }
    public class Triangle : Shape
    {
        //override the virtual method in base class
        public override void Draw()
        {
            Console.WriteLine("Drawing a triangle");
        }
    }
}
