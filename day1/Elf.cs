public class Elf {
    public int Id { get; set; }
    public List<int> Calories { get; set; }

    public Elf (int id) {
        Id = id;
        Calories = new List<int>();
    }

    public void AddCalories(int amount) => Calories.Add(amount);

    public int TotalCalories() => Calories.Sum();

}