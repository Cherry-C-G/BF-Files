
using Newtonsoft.Json;

namespace JsonSerializationExamples
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create the object
            Student s = new Student()
            {
                Id = 1,
                Name = "Jason",
                Description = "Test"
            };

            //Convert object to Json string then write the string to the file
            string filePath = @"C:\Users\gongl\OneDrive\Desktop\practice\JsonSerializationExample.txt";
            string jsonString = JsonConvert.SerializeObject(s);
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter= new StreamWriter(fs);
            streamWriter.Write(jsonString);
            streamWriter.Close();
        }
    }
}