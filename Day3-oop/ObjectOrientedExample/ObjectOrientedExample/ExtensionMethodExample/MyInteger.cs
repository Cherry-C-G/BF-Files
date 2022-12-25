using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethodExample
{
    
    public class MyInteger
    {
        public int Num { get; set; }

        // non-static method, belongs to the specific object;
        public int DoubleTheValue(int value)
        {
            return value * value;
        }

        //static method can be called only by class -> MyInteger.ToAHundred();
        public static int ToAHundred()
        {
            return 100;
        }
    }
}
