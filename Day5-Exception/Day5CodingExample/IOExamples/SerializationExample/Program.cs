using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace SerializationExample
{
    // an attribute to tell .NET this can be serialized
    [Serializable]
   public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Serialization
            //Create the object
            Employee employee = new Employee()
            {
                Id = 100,
                Name = "Alice"
            };

            //Create a FileStream to write
            string filePath = @"C:\Users\gongl\OneDrive\Desktop\practice\SerializationExample.txt";
            FileStream writeStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            
            //Create BinaryFormatter
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(writeStream, employee); // specify the FileStream and Employee object
            //Close the stream
            writeStream.Close();
            Console.WriteLine("Serialized");

            //Deserialization
            //Create a FileStream to read
            FileStream readStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            Employee readFromFileEmployee = (Employee)binaryFormatter.Deserialize(readStream);

            //Use the deserialized object from file
            Console.WriteLine($"Name = {readFromFileEmployee.Name}; Id = {readFromFileEmployee.Id}");

            //Close stream
            readStream.Close();
            Console.WriteLine("Deserialized");

        }
    }
}
