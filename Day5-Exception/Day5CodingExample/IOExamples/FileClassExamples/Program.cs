using System;
using System.IO;

namespace FileClassExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The @ here is to ignore the \ --> escape sequence
            string str = "\"" ;
            string filePath = @$"C:\Users\gongl\OneDrive\Desktop\practice\File.txt";
            //Check if the file exists
            bool isExist = File.Exists(filePath);
            Console.WriteLine("File exists? ->" + isExist);
            //Use create method to create the file
            File.Create(filePath).Close();
            Console.WriteLine("File Created");

            //Delete the file with a specific path
            //File.Delete(filePath);
            //Console.WriteLine("File Deleted");

            #region Read/Write Operations
            //Write to the file
            string writeContent = "Merry Christmas!";
            File.WriteAllText(filePath, writeContent);
            Console.WriteLine("The content has been written");

            //Read from the file
            string readContent = File.ReadAllText(filePath);
            Console.WriteLine(readContent);
            Console.WriteLine("Finish Reading");

            #endregion
        }
    }
}
