using MS_System_Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

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

        var tokens = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        var current = GetNodeRecursive(_root, tokens, 0);

        if (current.IsDirectory)
        {
            return GetChildNamesRecursive(current);
        }
        else
        {
            return new List<string> { current.Name };
        }
    }

    private FileNode GetNodeRecursive(FileNode current, string[] tokens, int index)
    {
        if (index == tokens.Length)
        {
            return current;
        }

        if (!current.IsDirectory)
        {
            throw new ArgumentException("Invalid path");
        }

        var child = current.Content.FirstOrDefault(x => x.Name == tokens[index]);

        if (child == null)
        {
            throw new ArgumentException("Invalid path");
        }

        return GetNodeRecursive(child, tokens, index + 1);
    }

    private List<string> GetChildNamesRecursive(FileNode node)
    {
        var names = new List<string>();

        foreach (var child in node.Content)
        {
            names.Add(child.Name);
        }

        return names;
    }

    public void MakeDirectory(string path, FileNode directory)
    {
        if (!path.StartsWith("/"))
        {
            throw new ArgumentException("Path must start with /");
        }

        var tokens = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        var parent = GetNodeRecursive(_root, tokens, 0);

        parent.AddChild(directory);
    }
}


//use recursion in two key methods: GetNodeRecursive and GetChildNamesRecursive.

//GetNodeRecursive is used to traverse the file system tree and find the node
//corresponding to the provided path. The method takes the current node, a token array (representing the path),
//and an index representing the current depth in the path. It works by checking if the index has reached the end of the token array.
//If it has, the current node is returned. If the current node is not a directory, an "Invalid path" exception is thrown.
//The method then finds the child node with the matching name and recursively calls itself with the updated child and incremented index.

//GetChildNamesRecursive is used to retrieve the names of all children nodes in the specified directory node.
//It iterates over the children of the given node and adds their names to a list. This list is then returned.