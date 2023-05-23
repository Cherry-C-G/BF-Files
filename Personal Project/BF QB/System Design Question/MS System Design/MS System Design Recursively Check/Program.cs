using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS_System_Design;

namespace MS_System_Design_Recursively_Check
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileManagementSystem = new FileManagementSystem();

            // Test case 1: Creating a new directory and checking if it exists
            fileManagementSystem.MakeDirectory("/", new FileNode("TestDirectory1", true));
            var contents = fileManagementSystem.GetDirectory("/");
            if (contents.Contains("TestDirectory1"))
            {
                Console.WriteLine("Test case 1: Passed");
            }
            else
            {
                Console.WriteLine("Test case 1: Failed");
            }

            // Test case 2: Creating a nested directory and checking if it exists
            fileManagementSystem.MakeDirectory("/TestDirectory1", new FileNode("TestDirectory2", true));
            contents = fileManagementSystem.GetDirectory("/TestDirectory1");
            if (contents.Contains("TestDirectory2"))
            {
                Console.WriteLine("Test case 2: Passed");
            }
            else
            {
                Console.WriteLine("Test case 2: Failed");
            }

            // Test case 3: Checking if an invalid path throws an exception
            try
            {
                contents = fileManagementSystem.GetDirectory("/InvalidDirectory");
                Console.WriteLine("Test case 3: Failed");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Test case 3: Passed");
            }

            // Test case 4: Creating a file and checking if it exists
            fileManagementSystem.MakeDirectory("/TestDirectory1/TestDirectory2", new FileNode("TestFile.txt", false));
            contents = fileManagementSystem.GetDirectory("/TestDirectory1/TestDirectory2");
            if (contents.Contains("TestFile.txt"))
            {
                Console.WriteLine("Test case 4: Passed");
            }
            else
            {
                Console.WriteLine("Test case 4: Failed");
            }
        }
    }
}
