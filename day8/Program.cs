// Read in data
var data = File.ReadAllLines("input.txt");
var maxX = data[0].Length - 1;
var maxY = data.Length - 1;

// Build forest
var trees = new List<Tree>();
for (var y = 0; y < data.Length; y++){
    for (var x = 0; x < data[y].Length; x++){
        trees.Add(new Tree { X = x, Y = y, Height = data[y][x] - '0'});
    }
}

// Check visibility for each tree
foreach (var t in trees)
{
    // Part 1: visibility
    var leftVisible = (trees.FindAll(r => r.Y == t.Y && r.X < t.X).Find(r => r.Height >= t.Height) is null);
    var rightVisible = (trees.FindAll(r => r.Y == t.Y && r.X > t.X).Find(r => r.Height >= t.Height) is null);
    var topVisible = (trees.FindAll(r => r.Y < t.Y && r.X == t.X).Find(r => r.Height >= t.Height) is null);
    var bottomVisible = (trees.FindAll(r => r.Y > t.Y && r.X == t.X).Find(r => r.Height >= t.Height) is null);
    t.Visible = leftVisible || rightVisible || topVisible || bottomVisible;

    // Part 2: Scenic score calculation
    // Left
    var candidates = trees.FindAll(r => r.Y == t.Y && r.X < t.X && r.Height >= t.Height).OrderByDescending(r => r.X);
    if (!candidates.Any()) {
        t.ScenicScore = t.X == 0 ? 0 : t.ScenicScore * t.X;
    } else {
        t.ScenicScore *= t.X - candidates.First().X;
    }
    // Right
    candidates = trees.FindAll(r => r.Y == t.Y && r.X > t.X && r.Height >= t.Height).OrderBy(r => r.X);
    if (!candidates.Any()) {
        t.ScenicScore = t.X == maxX ? 0 : t.ScenicScore * (maxX - t.X);
    } else {
        t.ScenicScore *= candidates.First().X - t.X;
    }
    // Top
    candidates = trees.FindAll(r => r.Y < t.Y && r.X == t.X && r.Height >= t.Height).OrderByDescending(r => r.Y);
    if (!candidates.Any()) {
        t.ScenicScore = t.Y == 0 ? 0 : t.ScenicScore * t.Y;
    } else {
        t.ScenicScore *= t.Y - candidates.First().Y;
    }
    // Bottom
    candidates = trees.FindAll(r => r.Y > t.Y && r.X == t.X && r.Height >= t.Height).OrderBy(r => r.Y);
    if (!candidates.Any()) {
        t.ScenicScore = t.Y == maxY ? 0 : t.ScenicScore * (maxY - t.Y);
    } else {
        t.ScenicScore *= candidates.First().Y - t.Y;
    }
}

// Report results
System.Console.WriteLine($"Part 1: Out of total of {trees.Count} trees, {trees.FindAll(t => t.Visible).Count} are visible");
var scenicTree = trees.OrderByDescending(t => t.ScenicScore).First();
System.Console.WriteLine($"Part 2: Highest scenic score is located at ({scenicTree.X}, {scenicTree.Y}) with a score of {scenicTree.ScenicScore}");


public class Tree {
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public bool Visible { get; set; } = false;
    public int ScenicScore { get; set; } = 1;
}