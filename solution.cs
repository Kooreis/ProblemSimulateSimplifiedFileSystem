Here is a simple console application in C# that simulates a simplified file system with mkdir, ls, and addContentToFile commands:

```C#
using System;
using System.Collections.Generic;
using System.Linq;

public class FileSystem
{
    private class File
    {
        public bool IsFile = false;
        public Dictionary<string, File> Children = new Dictionary<string, File>();
        public string Content = "";
    }

    private File root;

    public FileSystem()
    {
        root = new File();
    }

    public void Mkdir(string path)
    {
        File node = root;
        string[] dirs = path.Split('/');
        foreach (string dir in dirs)
        {
            if (!node.Children.ContainsKey(dir))
                node.Children[dir] = new File();
            node = node.Children[dir];
        }
    }

    public void AddContentToFile(string filePath, string content)
    {
        File node = root;
        string[] dirs = filePath.Split('/');
        foreach (string dir in dirs)
        {
            if (!node.Children.ContainsKey(dir))
                node.Children[dir] = new File();
            node = node.Children[dir];
        }
        node.IsFile = true;
        node.Content += content;
    }

    public string ReadContentFromFile(string filePath)
    {
        File node = root;
        string[] dirs = filePath.Split('/');
        foreach (string dir in dirs)
        {
            if (!node.Children.ContainsKey(dir))
                return "";
            node = node.Children[dir];
        }
        return node.Content;
    }

    public List<string> Ls(string path)
    {
        File node = root;
        string[] dirs = path.Split('/');
        foreach (string dir in dirs)
        {
            if (!node.Children.ContainsKey(dir))
                return new List<string>();
            node = node.Children[dir];
        }
        if (node.IsFile)
            return new List<string> { dirs.Last() };
        return new List<string>(node.Children.Keys);
    }
}

class Program
{
    static void Main(string[] args)
    {
        FileSystem fs = new FileSystem();
        fs.Mkdir("/a/b/c");
        fs.AddContentToFile("/a/b/c/d", "hello");
        Console.WriteLine(string.Join(", ", fs.Ls("/a/b/c"))); // Output: d
        Console.WriteLine(fs.ReadContentFromFile("/a/b/c/d")); // Output: hello
    }
}
```

This program creates a simple file system with directories and files. The `Mkdir` method creates a new directory, the `AddContentToFile` method creates a new file or appends content to an existing file, the `ReadContentFromFile` method reads content from a file, and the `Ls` method lists all files and directories in a directory.