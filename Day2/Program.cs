Console.WriteLine("Day 2");
var gameLines = await File.ReadAllLinesAsync(@"C:\Learning\Projects\AoC\Day2\Input.txt");
var games = new List<Game>();
int i = 1;

foreach (var gameLine in gameLines)
{
    var gameDataSets = gameLine.Substring(gameLine.IndexOf(':') + 1).Split(';');
    var gameSets = new List<Set>();

    foreach (var gameDataSet in gameDataSets)
    {
        var cubeData = gameDataSet.Split(',');
        var cubes = new List<Cube>();

        foreach (var cubedata in cubeData)
        {
            var cube = cubedata.Trim().Split(' ');
            cubes.Add(new Cube
            {
                Value = Convert.ToInt32(cube[0]),
                Color = Enum.Parse<Color>(cube[1], true)
            });
        }

        gameSets.Add(new Set
        {
            Cubes = cubes
        });
    }

    var game = new Game
    {
        ID = i,
        Sets = gameSets
    };

    games.Add(game);
    i++;
}

var part1Sum = games.Where(
            game => game.Sets.All(
            set => set.Cubes.All(
            cube => cube.Color == Color.Red && cube.Value <= 12 || cube.Color == Color.Green && cube.Value <= 13 || cube.Color == Color.Blue && cube.Value <= 14)))
            .Sum(g => g.ID);
Console.WriteLine($"Part 1: {part1Sum}");

var part2Sum = games.Sum(g => g.Sets.SelectMany(c => c.Cubes)
            .GroupBy(g => g.Color)
            .Select(s => s.MaxBy(m => m.Value))
            .Select(s => s.Value)
            .Aggregate((a, b) => a * b));

Console.WriteLine($"Part 2: {part2Sum}");

internal struct Game
{
    internal int ID { get; set; }
    internal List<Set> Sets { get; set; }
}

internal struct Set
{
    internal List<Cube> Cubes { get; set; }
}

internal struct Cube
{
    internal Color Color { get; set; }
    internal int Value { get; set; }
}

enum Color
{
    Red = 0,
    Green = 1,
    Blue = 2,
}