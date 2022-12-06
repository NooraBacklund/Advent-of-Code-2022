var data = File.ReadAllLines("input.txt").ToList();

// Split into cargo + instructions
var separator = data.IndexOf("");
var cargoData = data.Take(separator);
var instructionData = data.Skip(separator + 1);

// Set up cargo stacks
var numStacks = (cargoData.First().Length + 1) / 4;
var cargoStacks = new Dictionary<int, List<char>>();
for (int i = 1; i <= numStacks; i++) cargoStacks.Add(i, new List<char>());

// Fill in from bottom up, skipping stack number row
foreach (var row in cargoData.Reverse().Skip(1))
{
    decimal pos = 0;
    foreach (var c in row)
    {
        if (pos % 4 == 1 && c != ' ') cargoStacks[(int)Math.Floor(pos / 4) + 1].Add(c);
        pos++;
    }
}

// Parse instructions
var instructions = new List<Instruction>();
foreach (var inst in instructionData)
{
    var parts = inst.Split(' ');
    instructions.Add(new Instruction(
        int.Parse(parts[1]),
        int.Parse(parts[3]),
        int.Parse(parts[5])
    ));
}

// Run instructions
foreach (var instruction in instructions)
{
    // Pick up crate
    // NOTE: Enable either part 1 or part 2 code, depending on which answer you want
    //var crates = cargoStacks[instruction.Source].TakeLast(instruction.Count).Reverse(); // Part 1 code
    var crates = cargoStacks[instruction.Source].TakeLast(instruction.Count); // Part 2 code
    cargoStacks[instruction.Source] = cargoStacks[instruction.Source].Take(cargoStacks[instruction.Source].Count - instruction.Count).ToList();
    // Deposit crate
    cargoStacks[instruction.Destination].AddRange(crates);
}

var code = "";
foreach (var stack in cargoStacks) code += stack.Value.Last();

// Report results:
System.Console.WriteLine($"Crates on top of stacks: {code}");

public class Instruction {
    public int Count { get; set; }
    public int Source { get; set; }
    public int Destination { get; set; }

    public Instruction(int count, int source, int destination){
        Count = count;
        Source = source;
        Destination = destination;
    }
}