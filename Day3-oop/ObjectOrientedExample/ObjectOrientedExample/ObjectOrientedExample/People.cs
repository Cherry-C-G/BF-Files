using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedExample
{
    interface IFly
    {
        void Fly()
        {
            Console.WriteLine("I can fly");
        }
    } 
    internal class People
    {
        //automatic property
        public string Name { get; set; }

        // we can also make the property to get only or set only to meet our needs
        public int WorkingHoursPerDay { get; } = 8; 


        //private string name; // this is a private field

        //public string Name // this is a public property
        //{
        //    get { return name; } // get method to return the people name
        //    set { name = value; }// set method to change the people name to an assigned value
        //}
    }
}

