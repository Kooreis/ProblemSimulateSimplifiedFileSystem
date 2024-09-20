```java
import java.util.*;

public class Main {
    public static void main(String[] args) {
        FileSystem fs = new FileSystem();
        fs.mkdir("/a/b/c");
        fs.addContentToFile("/a/b/c/d", "hello");
        System.out.println(fs.ls("/"));
        System.out.println(fs.ls("/a/b/c"));
        System.out.println(fs.readContentFromFile("/a/b/c/d"));
    }
}

class File {
    boolean isfile = false;
    HashMap < String, File > files = new HashMap < > ();
    String content = "";
}

class FileSystem {
    File root;
    public FileSystem() {
        root = new File();
    }

    public List < String > ls(String path) {
        File t = root;
        List < String > files = new ArrayList < > ();
        if (!path.equals("/")) {
            String[] d = path.split("/");
            for (int i = 1; i < d.length - 1; i++) {
                t = t.files.get(d[i]);
            }
            if (t.files.get(d[d.length - 1]).isfile) {
                files.add(d[d.length - 1]);
                return files;
            } else {
                t = t.files.get(d[d.length - 1]);
            }
        }
        List < String > res_files = new ArrayList < > (t.files.keySet());
        Collections.sort(res_files);
        return res_files;
    }

    public void mkdir(String path) {
        File t = root;
        String[] d = path.split("/");
        for (int i = 1; i < d.length; i++) {
            if (!t.files.containsKey(d[i]))
                t.files.put(d[i], new File());
            t = t.files.get(d[i]);
        }
    }

    public void addContentToFile(String filePath, String content) {
        File t = root;
        String[] d = filePath.split("/");
        for (int i = 1; i < d.length - 1; i++) {
            t = t.files.get(d[i]);
        }
        if (!t.files.containsKey(d[d.length - 1]))
            t.files.put(d[d.length - 1], new File());
        t = t.files.get(d[d.length - 1]);
        t.isfile = true;
        t.content += content;
    }

    public String readContentFromFile(String filePath) {
        File t = root;
        String[] d = filePath.split("/");
        for (int i = 1; i < d.length - 1; i++) {
            t = t.files.get(d[i]);
        }
        return t.files.get(d[d.length - 1]).content;
    }
}
```