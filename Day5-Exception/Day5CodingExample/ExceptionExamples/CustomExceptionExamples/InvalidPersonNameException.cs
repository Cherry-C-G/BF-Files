using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptionExamples
{
    
    //Step1: Create my exception class called InvalidPersonNameException, and make it inherit Exception class
    internal class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException() : base() { }
        public InvalidPersonNameException(string name) : base(string.Format("Invalid Name: {0}", name)) { }

        // Currently I don't need to override some virtual methods in Exception class
    }
}
