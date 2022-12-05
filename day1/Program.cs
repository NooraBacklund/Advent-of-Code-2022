var elves = ReadInput("input.txt");

// Part 1 - most calories a single elf is carrying:
System.Console.WriteLine($"Highest number of calories carried is {elves.Max(e => e.TotalCalories())}");

// Part 2 - sum of calories carried by top three elves with most calories:
System.Console.WriteLine($"Sum of top three calorie carriers: {elves.OrderByDescending(e => e.TotalCalories()).Take(3).Sum(e => e.TotalCalories())}");

//----------------------------------------------------------------------------------------------------

List<Elf> ReadInput(string filename){
    var data = File.ReadAllLines("input.txt");

    // Create elves
    var elves = new List<Elf>();
    var elfNumber = 1;

    foreach (var line in data)
    {
        if (String.IsNullOrEmpty(line)){
            elfNumber++;
        } else {
            var elf = elves.Find(e => e.Id == elfNumber) ?? new Elf(elfNumber);
            elf.AddCalories(int.Parse(line));
            if (elves.FindIndex(e => e.Id == elf.Id) == -1) elves.Add(elf);
        }
    }

    return elves;
}