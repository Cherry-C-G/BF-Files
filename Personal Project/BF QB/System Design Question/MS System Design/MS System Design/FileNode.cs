//1 system design coding question
//Design a File Management System. 
//1. GetDirectory(string path) if the path is a valid file, return its name. If the 
//path is a directory, return names of all the files under this directory. 
//2. MakeDirectory() receive a file object and make directory in the file 
//management system.



using System;
using System.Collections.Generic;
using MS_System_Design;

namespace MS_System_Design
{
    public class FileNode
    {
        public string Name { get; set; }
        public bool IsDirectory { get; set; }
        public List<FileNode> Content { get; set; }
        public FileNode Parent { get; set; }

        public FileNode(string name, bool isDirectory)
        {
            Name = name;
            IsDirectory = isDirectory;
            Content = isDirectory ? new List<FileNode>() : null;
            Parent = null;
        }
        public void AddChild(FileNode child)
        {
            if (IsDirectory)
            {
                child.Parent = this;
                Content.Add(child);
            }

        }
    }

}


