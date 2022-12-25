using System;
using System.Collections.Generic;
using System.IO;

namespace IOExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //File Path
            string path = @"C:\Users\gongl\OneDrive\Desktop\practice\FileStreamExample.txt";

            //Create FileStream obj to write/read to/from file
            //it's better to create one filestream to write, and one filestream to read
            //FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write); 

            ////create contect
            //string content = "Hello, this is the content I want to write into the file...";
            //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(content); // convert string values to byte array

            ////Write
            //writeStream.Write(bytes, 0, bytes.Length); // FROM 0 position to bytes.Length, write the content in bytes array
            ////FileStream can perform multiple read/write operations
            //string content2 = "Another text here...";
            //byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(content2);
            //writeStream.Write(bytes2, 0, bytes2.Length);

            ////after reading or writing, close the file stream
            //writeStream.Close();
            //Console.WriteLine("File has been modified");

            #region Read From File
            //File reading, create another file stream to read from the file
            FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            // to read the file we need to create an empty array first
            byte[] bytes3 = new byte[readStream.Length]; // the length of the stream == the size of the file
            //get the bytes in stream and put them to bytes3
            readStream.Read(bytes3, 0, bytes3.Length);
            //convert byte[] to string
            string content3 = System.Text.Encoding.UTF8.GetString(bytes3);
            Console.WriteLine(content3);

            //close the stream
            readStream.Close();
            Console.WriteLine("File has been read");

            #endregion
        }
    }
}
