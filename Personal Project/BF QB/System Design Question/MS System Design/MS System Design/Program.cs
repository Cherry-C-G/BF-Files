using System;
using System.Collections.Generic;
using MS_System_Design;

class Program
{
    static void Main(string[] args)
    {
        var fileManagementSystem = new FileManagementSystem();

        // Test case 1: Creating a new directory and checking if it exists
        var testDirectory1 = new FileNode("TestDirectory1", true);
        fileManagementSystem.MakeDirectory(testDirectory1);
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
        var testDirectory2 = new FileNode("TestDirectory2", true);
        testDirectory1.AddChild(testDirectory2);
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
        var testFile = new FileNode("TestFile.txt", false);
        testDirectory2.AddChild(testFile);
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
