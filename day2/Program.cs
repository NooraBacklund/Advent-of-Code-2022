var data = ReadInput("input.txt");

var choiceScore = new Dictionary<string, int>(){
    {"X", 1}, //Rock
    {"Y", 2}, //Paper
    {"Z", 3} //Scissors
};
var gameScore = new Dictionary<string, int>(){
    {"loss", 0},
    {"draw", 3},
    {"win", 6}
};
var pt2Equiv = new Dictionary<string, string>(){
    {"X", "loss"},
    {"Y", "draw"},
    {"Z", "win"}
};

var pt1Results = new Dictionary<string, Dictionary<string, string>>(){
    {"A", new Dictionary<string, string>(){
        {"X", "draw"},
        {"Y", "win"},
        {"Z", "loss"}
    }},
    {"B", new Dictionary<string, string>(){
        {"X", "loss"},
        {"Y", "draw"},
        {"Z", "win"}
    }},
    {"C", new Dictionary<string, string>(){
        {"X", "win"},
        {"Y", "loss"},
        {"Z", "draw"}
    }}
};

var pt2Results = new Dictionary<string, Dictionary<string, string>>(){
    {"A", new Dictionary<string, string>(){
        {"Y", "X"},
        {"Z", "Y"},
        {"X", "Z"}
    }},
    {"B", new Dictionary<string, string>(){
        {"X", "X"},
        {"Y", "Y"},
        {"Z", "Z"}
    }},
    {"C", new Dictionary<string, string>(){
        {"Z", "X"},
        {"X", "Y"},
        {"Y", "Z"}
    }}
};

// Part 1
System.Console.WriteLine($"Part 1 solution: Total score after all games: {data.Sum(game => CalculateScore(game))}");

// Part 2
// X = need to lose, Y = need to draw, Z = need to win
System.Console.WriteLine($"Part 2 solution: Total score after all games: {data.Sum(game => CheckResultPt2(game))}");

//--------------------------------------------------------------
List<string> ReadInput(string filename)
{
    var lines = File.ReadAllLines(filename).ToList();
    return lines;
}

int CalculateScore(string line)
{
    var opponentHand = line.Split(' ')[0];
    var playerHand = line.Split(' ')[1];
    var result = pt1Results[opponentHand][playerHand];
   
    return choiceScore[playerHand] + gameScore[result];
}

int CheckResultPt2(string line)
{
    var opponentHand = line.Split(' ')[0];
    var targetResult = line.Split(' ')[1];
    var playerHand = pt2Results[opponentHand][targetResult];
    targetResult = pt2Equiv[targetResult];
    return choiceScore[playerHand] + gameScore[targetResult];
}
