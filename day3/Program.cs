var data = File.ReadAllLines("input.txt");

var commonChars = new List<char>();
var priorities = "-abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

// Part 1
foreach (var line in data)
{
    var mid = line.Length / 2;
    var left = line.Substring(0, mid);
    var right = line.Substring(mid, mid);
    commonChars.AddRange(left.Intersect(right));
}

System.Console.WriteLine($"Sum of priorities (part 1): {commonChars.Sum(c => priorities.IndexOf(c))}");

// Part 2
var commonCharsPt2 = new List<char>();
while (data.Length > 2)
{
    var group = data.Take(3);
    data = data.Skip(3).ToArray();
    commonCharsPt2.AddRange(group.ElementAt(0).Intersect(group.ElementAt(1)).Intersect(group.ElementAt(2)));   
}

System.Console.WriteLine($"Sum of priorities (part 2): {commonCharsPt2.Sum(c => priorities.IndexOf(c))}");
