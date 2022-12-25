using System;
using System.Collections.Generic;

namespace ObjectClassExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grandparent grandparent = new Parent(); //up cast
            // Parent parent1 = grandparent; // compile error
            Parent parent2 = (Parent)grandparent; // down cast
            //Child child1 = grandparent; //compile error
            Child child2 = (Child)grandparent; // down cast
        }
    }
    class Grandparent
    {
        public string Name { get; set; } = "Grandparent";
    }

    class Parent : Grandparent
    {
        public bool IsHealthy { get; set; } = true;
        public List<Child> Children { get; set; } = new List<Child>();
    }

    class Child : Parent
    {
        public Parent TheParent { get; set; }
    }
}
