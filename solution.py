Here is a Python solution using a dictionary to simulate a file system:

```python
class FileSystem:
    def __init__(self):
        self.filepath = {}

    def ls(self, path: str):
        if path in self.filepath:
            if isinstance(self.filepath[path], str):
                return [path.split('/')[-1]]
            return sorted(self.filepath[path].keys())
        else:
            path = path.split('/')
            node = self.filepath
            for part in path[1:]:
                node = node[part]
            return sorted(node.keys())

    def mkdir(self, path: str):
        path = path.split('/')
        node = self.filepath
        for part in path[1:]:
            if part not in node:
                node[part] = {}
            node = node[part]

    def addContentToFile(self, filePath: str, content: str):
        path = filePath.split('/')
        node = self.filepath
        for part in path[1:-1]:
            node = node[part]
        if path[-1] not in node:
            node[path[-1]] = content
        else:
            node[path[-1]] += content

    def readContentFromFile(self, filePath: str):
        path = filePath.split('/')
        node = self.filepath
        for part in path[1:-1]:
            node = node[part]
        return node[path[-1]]


if __name__ == "__main__":
    fs = FileSystem()
    fs.mkdir("/a/b/c")
    fs.addContentToFile("/a/b/c/d", "hello")
    print(fs.ls("/"))
    print(fs.ls("/a/b/c"))
    print(fs.readContentFromFile("/a/b/c/d"))
```

This code creates a class `FileSystem` that simulates a file system. The `mkdir` method creates directories, the `addContentToFile` method creates a file and adds content to it, the `ls` method lists all files and directories in a directory, and the `readContentFromFile` method reads the content of a file. The file system is represented as a nested dictionary, where each key is a directory or file name and each value is either a dictionary (for directories) or a string (for files).