using MS_System_Design;
using NPOI.Util.Collections;
using System.IO;
using System.Security.Policy;

namespace MS_System_Design
{
    public class FileManagementSystem
    {
        private readonly FileNode _root;
        public FileManagementSystem()
        {
            _root = new FileNode("/", true);
        }
        public List<string> GetDirectory(string path)
        {
            if (!path.StartsWith("/"))
            {
                throw new ArgumentException("Path must start with /");
            }
            var current = _root;
            var tokens = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                var found = false;
                if (!current.IsDirectory)
                {
                    break;
                }
                foreach (var child in current.Content)
                {
                    if (child.Name == token)
                    {
                        current = child;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new ArgumentException("Invalid path");
                }
            }
            if (current.IsDirectory)
            {
                var filenames = new List<string>();
                foreach (var child in current.Content)
                {
                    filenames.Add(child.Name);
                }
                return filenames;
            }
            else
            {
                return new List<string> { current.Name };
            }
        }
        public void MakeDirectory(FileNode directory)
        {
            if (directory.Parent == null)
            {
                _root.AddChild(directory);
            }
            else
            {
                directory.Parent.AddChild(directory);
            }
        }
    }
}


//designing a basic File Management System with two main classes: FileNode and FileManagementSystem.

//FileNode class:

//Represents a file or a directory in the file management system.
//It has the following properties:
//Name: The name of the file or directory.
//IsDirectory: A boolean flag indicating whether the node is a directory or not.
//Content: A list of children FileNode objects, which will only be instantiated if the node is a directory.
//Parent: A reference to the parent FileNode object.
//It has a constructor to initialize the Name and IsDirectory properties.
//It has the AddChild method to add a child FileNode object to the directory.
//FileManagementSystem class:

//Represents the file management system and stores the root directory as a FileNode.
//It has the following methods:
//GetDirectory(string path): This method takes a path as input and returns a list of filenames. If the path is a file, it returns the name of the file. If the path is a directory, it returns the names of all files under the directory. It throws an exception if the path is invalid.
//It starts from the root node and iterates through the path tokens (split by '/').
//In each iteration, it searches for a child with the same name as the token in the current node's Content.
//If it finds a match, it updates the current node to the matched child and continues with the next token.
//If no match is found or the current node is not a directory, it throws an exception.
//After the iteration, if the current node is a directory, it returns the names of all the children in the directory. If the current node is a file, it returns its name.
//MakeDirectory(FileNode directory): This method takes a FileNode object as input and adds it to the file management system.
//If the Parent property of the input directory is not set, it adds the directory as a child of the root node.
//If the Parent property is set, it adds the directory as a child of the specified parent node.
//This design provides a simple file management system with the ability to represent hierarchical file structures and perform basic directory operations like getting file/directory contents and creating new directories.