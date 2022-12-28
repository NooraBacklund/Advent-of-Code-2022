using System.Linq;

// Read input
var data = File.ReadAllLines("input.txt");

// Set some variables for pt 2
var diskSize = 70000000;
var reqFreeSpace = 30000000;

// Create starting point for fs
var root = new DirObject("/", null);
var currentNode = root;
var directoryList = new List<DirObject>();

// Build fs structure
foreach (var l in data){
    // Check if line is command
    if (l[0] == '$') {
        // Split into components
        var command = l.Split(' '); // command[1] = command, command[2] = target
        if (command[1] == "cd"){
            if (command[2] == "/"){ // Move to root
                currentNode = root;
            } else if (command[2] == "..") { // Move up a node
                currentNode = currentNode.Parent;
            } else { // Move to subdirectory
                currentNode = currentNode.ContainedDirectories.Find(d => d.Name == command[2]) ?? currentNode;
            }
        }
    } else { // Parse information
        var row = l.Split(' ');
        if (row[0] == "dir"){ // Add to child directories if a directory is contained
            var d = new DirObject(row[1], currentNode);
            currentNode.addChildDir(d);
            directoryList.Add(d);
        } else { // Add file to current directory
            var f = new FileObject(row[1], int.Parse(row[0]));
            currentNode.addFile(f);
        }
    }
}
var underSize = directoryList.FindAll(d => d.Size <= 100000);
System.Console.WriteLine($"Part 1: sum of directories with size at most 100000: {underSize.Sum(o => o.Size)}\n");

// Part 2: 
//Calculate current free space
var currFreeSpace = diskSize - root.Size;

System.Console.WriteLine("Part 2:");
System.Console.WriteLine($"Required space for update: \t\t\t{reqFreeSpace}");
System.Console.WriteLine($"Free space before deletion: \t\t\t{currFreeSpace}");
System.Console.WriteLine($"Amount of data to be deleted (minimum): \t {reqFreeSpace - currFreeSpace}");

// Locate the smallest directory which can be deleted to get enough space
var match = directoryList.FindAll(d => d.Size >= (reqFreeSpace - currFreeSpace)).OrderBy(d => d.Size).First();
System.Console.WriteLine($"Smallest directory that can be deleted: {match.Name}, size {match.Size}");

public class DirObject {
    public int Size {
        get {
            return ContainedDirectories.Sum(d => d.Size) + ContainedFiles.Sum(f => f.Size);
        }
    }
    public string Name { get; set; }
    public DirObject Parent { get; set; }
    public List<DirObject> ContainedDirectories { get; }
    public List<FileObject> ContainedFiles { get; }
    
    public DirObject(string name, DirObject parent){
        this.Name = name;
        this.Parent = parent;
        this.ContainedDirectories = new List<DirObject>();
        this.ContainedFiles = new List<FileObject>();
    }

    public void addChildDir(DirObject dir){
        ContainedDirectories.Add(dir);
    }

    public void addFile(FileObject file){
        ContainedFiles.Add(file);
    }
}

public class FileObject {
    public string Name { get; set; }
    public int Size { get; set; }

    public FileObject(string name, int size)
    {
        this.Name = name;
        this.Size = size;
    }
}