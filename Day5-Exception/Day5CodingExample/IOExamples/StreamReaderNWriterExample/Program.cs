using System;
using System.IO;

namespace StreamReaderNWriterExample
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            //file path
            string filePath = "C:\\Users\\gongl\\OneDrive\\Desktop\\practice\\Practice.txt";
            //create the file, can also use FileInfo class to create the file
            //FileInfo fileInfo = new FileInfo(filePath);
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Write);

            //StreamWriter writer = new StreamWriter(filePath); // this is another way to create the stream writer
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine("Hello World");

            writer.Write("C# is an OOP language!");

            writer.WriteLine(" Java is also an OOP language!");

            // close streams
            writer.Close();

            Console.WriteLine("File has been modified!");


            //StreamReader
            //create a stream reader object
            //StreamReader reader = new StreamReader(filePath); // this is another way to create StreamReader object
            FileStream fs2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs2);

            // read the file
            // string content = reader.ReadToEnd(); // read from begining to the end
            //Console.WriteLine(content);

            //To read one line
            //Console.WriteLine(reader.ReadLine());

            //To read line by line
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }


            //// close streams
            reader.Close();
            Console.WriteLine("End");
        }
    }
}
