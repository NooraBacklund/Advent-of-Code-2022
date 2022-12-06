var pairs = File.ReadAllLines("input.txt");

var fullyContainedPairs = 0;
var overlappingPairs = 0;

foreach (var item in pairs)
{
    var pair = item.Split(',');
    var a1 = int.Parse(pair[0].Split('-')[0]);
    var a2 = int.Parse(pair[0].Split('-')[1]);
    var b1 = int.Parse(pair[1].Split('-')[0]);
    var b2 = int.Parse(pair[1].Split('-')[1]);
    if ((a1 <= b1 && a2 >= b2) || (b1 <= a1 && b2 >= a2)) fullyContainedPairs++;
    if ((a1 <= b2 && a2 >= b1) || (b1 <= a2 && b2 >= a1)) overlappingPairs++;
}

System.Console.WriteLine($"Number of fully contained pairs: {fullyContainedPairs}");
System.Console.WriteLine($"Number of overlapping pairs: {overlappingPairs}");