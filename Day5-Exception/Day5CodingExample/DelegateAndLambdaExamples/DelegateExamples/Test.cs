using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateExamples
{
    
    internal class Test
    {
        public OneParamReturnIntDelegate delegate1;
        public NoParamNoReturnDelegate delegate2;

        public Test() { }
        public Test(OneParamReturnIntDelegate delegate1, NoParamNoReturnDelegate delegate2)
        {
            this.delegate1 = delegate1;
            this.delegate2 = delegate2;
        }

        public void TestFunction(OneParamReturnIntDelegate delegate1, NoParamNoReturnDelegate delegate2)
        {
            // some business logic
            delegate2();
            //some business logic
            int businessLogicResult = 100;
            Console.WriteLine(delegate1(businessLogicResult));
        }
    }
}
