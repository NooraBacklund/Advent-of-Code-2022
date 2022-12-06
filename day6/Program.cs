var message = File.ReadAllLines("input.txt").First();

// Part 1
var markerFound =  false;
var startPos = -1;
do
{
    startPos++;
    markerFound = message.Skip(startPos).Take(4).Distinct().Count() == 4;
} while (!markerFound && startPos < message.Length);

System.Console.WriteLine($"==== Part 1: ====");
System.Console.WriteLine($"Marker found, starting at position {startPos}");
System.Console.WriteLine($"Marker: {String.Join("", message.Skip(startPos).Take(4))}");
System.Console.WriteLine($"Number of characters until marker end: {startPos + 4}");
System.Console.WriteLine("");

// Part 2
startPos = 0;
do
{
    startPos++;
    markerFound = message.Skip(startPos).Take(14).Distinct().Count() == 14;
} while (!markerFound && startPos < message.Length);

System.Console.WriteLine($"==== Part 2: ====");
System.Console.WriteLine($"Marker found, starting at position {startPos}");
System.Console.WriteLine($"Marker: {String.Join("", message.Skip(startPos).Take(14))}");
System.Console.WriteLine($"Number of characters until marker end: {startPos + 14}");
System.Console.WriteLine("");
