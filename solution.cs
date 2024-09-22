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