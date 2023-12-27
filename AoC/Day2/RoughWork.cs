//Console.WriteLine("Day 2");
//var gameData = await File.ReadAllLinesAsync(@"C:\Learning\Projects\AoC\Day2\Input.txt");
//var games = new Game[gameData.Length];
//int i = 1;

//// Part 1
//foreach (var gameDatum in gameData)
//{
//    var game = new Game
//    {
//        ID = i,
//    };

//    var gameDataSets = gameDatum.Substring(gameDatum.IndexOf(':') + 1).Split(';');
//    var gameSets = new List<Set>();

//    foreach (var gameDataSet in gameDataSets)
//    {
//        var cubeData = gameDataSet.Split(',');
//        var cubes = new List<Cube>();
//        foreach (var cubedata in cubeData)
//        {
//            var cube = cubedata.Trim().Split(' ');

//            cubes.Add(new Cube
//            {
//                Value = Convert.ToInt32(cube[0]),
//                Color = Enum.Parse<Color>(cube[1], true)
//            });
//        }

//        gameSets.Add(new Set
//        {
//            Cubes = cubes
//        });
//    }

//    game.Sets = gameSets;
//    games[i - 1] = game;
//    i++;
//}
//var possibleGames = games.Where(g => g.Sets.All(s => s.Cubes.All(c => c.Color == Color.Red && c.Value <= 12 || c.Color == Color.Green && c.Value <= 13 || c.Color == Color.Blue && c.Value <= 14))).ToList();
//Console.WriteLine(possibleGames.Sum(g => g.ID));

//internal struct Game
//{
//    internal int ID { get; set; }
//    internal List<Set> Sets { get; set; }
//}

//internal struct Set
//{
//    internal List<Cube> Cubes;
//}

//internal struct Cube
//{
//    internal Color Color;
//    internal int Value;
//}

//enum Color
//{
//    Blue = 0, Green = 1, Red = 2,
//}