Console.WriteLine("Day 11");
var lines = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day11\Input.txt").ToList();
var count = lines[0].Length;
var emptyDotsRow = new string('.', count);

//for (var i = 0; i < lines.Count; i++)
//{
//    if (lines[i] == emptyDotsRow)
//    {
//        lines.Insert(i + 1, emptyDotsRow);
//        i++;
//    }
//}

//count = lines[0].Length;
//var emptydotscolumn = new string('.', count);

//for (var i = 0; i < count; i++)
//{
//    if (lines[i].All(l => l == '.'))
//    {
//        lines.Insert(i + 1, emptydotscolumn);
//        i++;
//    }
//}

var galaxies = new List<Vector>();

ExpandUniverse();
Console.WriteLine($"Part1: {SumOfShortestDistances()}");

galaxies = new List<Vector>();
ExpandUniverse(1000000);
Console.WriteLine($"Part2: {SumOfShortestDistances()}");

void ExpandUniverse(long expansionMultiplier = 2)
{
    var rowsToAdd = Enumerable.Range(0, lines.Count).Where(row => lines[row].All(c => c == '.')).ToArray();
    var colsToAdd = Enumerable.Range(0, lines[0].Length).Where(col => lines.All(l => l[col] == '.')).ToArray();

    for (var row = 0; row < lines.Count; row++)
    {
        var rowOffset = rowsToAdd.Count(r => r <= row) * (expansionMultiplier - 1);
        for (var col = 0; col < lines[0].Length; col++)
        {
            if (lines[row][col] != '#') continue;

            var colOffset = colsToAdd.Count(c => c <= col) * (expansionMultiplier - 1);
            galaxies.Add(new Vector(row + rowOffset, col + colOffset));
        }
    }
}

long SumOfShortestDistances()
{
    var pairs = galaxies.SelectMany((g1, i) => galaxies.Skip(i + 1).Select(g2 => (g1, g2))).ToArray();
    var sum = 0L;
    foreach (var (g1, g2) in pairs)
    {
        sum += g1.VectorTo(g2).NumberSteps;
    }

    return sum;
}

record Vector(long Row, long Col)
{
    internal Vector VectorTo(Vector other) => new(other.Row - Row, other.Col - Col);
    internal long NumberSteps { get; } = Math.Abs(Row) + Math.Abs(Col);
}