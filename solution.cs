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
}