Console.WriteLine("Day 14");
var patterns = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day14\Input.txt");
var totalCount = patterns.Length;
var totaLoad = 0;
var movedRocks = new List<Rock>();

//for (int i = 0; i < patterns[0].Length; i++)
//{
//    var columnLength = patterns[0].Length;
//    var rocks = Enumerable.Range(0, columnLength).Select(x => patterns[x][i]).ToArray();

//    for (int j = 0; j < rocks.Length; j++)
//    {
//        if (rocks[j] == 'O' || rocks[j] == '#')
//            continue;

//        if (rocks[j] == '.' && j + 1 < rocks.Length && rocks[j + 1] == '#')
//            continue;

//        if (rocks[j] == '.' && j + 1 < rocks.Length && rocks[j + 1] == 'O')
//        {
//            movedRocks.Add(new Rock { Position = (j, i), Load = 1, ExistingPosition = (j + 1, i) });
//            rocks[j] = 'O';
//            rocks[j + 1] = '.';
//            continue;
//        }

//        if (rocks[j] == '.' && j + 1 < rocks.Length && rocks[j + 1] == '.')
//        {
//            var j1 = j;
//            while (j1 < rocks.Length && rocks[j1] == '.')
//            {
//                j1++;
//            }

//            if (j1 < rocks.Length && rocks[j1] == 'O')
//            {
//                movedRocks.Add(new Rock { Position = (j, i), Load = j1 - j, ExistingPosition = (j1, i) });
//                rocks[j] = 'O';
//                rocks[j1] = '.';
//            }
//        }
//    }
//}

//for (int i = 0; i < totalCount; i++)
//{
//    var rocksMovedCount = movedRocks.Count(r => r.Position.Item1 == i);
//    var existingRocksCount = patterns[i].Count(p => p == 'O');
//    var existingRocksMovedCount = movedRocks.Count(r => r.ExistingPosition.Item1 == i);
//    totaLoad += (rocksMovedCount + existingRocksCount - existingRocksMovedCount) * (totalCount - i);
//}
//Console.WriteLine($"Part1: {totaLoad}");

char[][] patternsArray = patterns.Select(item => item.ToCharArray()).ToArray();
totaLoad = 0;

var history = new List<string>();
var k = 0;
Dictionary<long, long> loads = new();
Console.WriteLine("Cycle\t\tLoad");

for (; k < 1000; k++)
{

    // Tilt North
    for (int i = 0; i < patternsArray.Length; i++)
    {
        var columnLength = patternsArray[0].Length;
        for (int j = 0; j < columnLength; j++)
        {
            if (patternsArray[j][i] == 'O' || patternsArray[j][i] == '#')
                continue;

            if (patternsArray[j][i] == '.' && j + 1 < columnLength && patternsArray[j + 1][i] == '#')
                continue;

            if (patternsArray[j][i] == '.' && j + 1 < columnLength && patternsArray[j + 1][i] == 'O')
            {
                patternsArray[j][i] = 'O';
                patternsArray[j + 1][i] = '.';
                continue;
            }

            if (patternsArray[j][i] == '.' && j + 1 < columnLength && patternsArray[j + 1][i] == '.')
            {
                var j1 = j;
                while (j1 < columnLength && patternsArray[j1][i] == '.')
                {
                    j1++;
                }

                if (j1 < columnLength && patternsArray[j1][i] == 'O')
                {
                    patternsArray[j][i] = 'O';
                    patternsArray[j1][i] = '.';
                }
            }
        }
    }

    ////Console.WriteLine("After North");

    ////for (int i = 0; i < patternsArray.Length; i++)
    ////{
    ////    for (int j = 0; j < patternsArray.Length; j++)
    ////    {
    ////        Console.Write(patternsArray[i][j]);
    ////    }
    ////    Console.WriteLine();
    ////}
    ////Console.WriteLine("-------------");

    // Tilt West
    for (int i = 0; i < patternsArray.Length; i++)
    {
        var rowLength = patternsArray[i].Length;
        for (int j = 0; j < rowLength; j++)
        {
            if (patternsArray[i][j] == 'O' || patternsArray[i][j] == '#')
                continue;

            if (patternsArray[i][j] == '.' && j + 1 < rowLength && patternsArray[i][j + 1] == '#')
                continue;

            if (patternsArray[i][j] == '.' && j + 1 < rowLength && patternsArray[i][j + 1] == 'O')
            {
                patternsArray[i][j] = 'O';
                patternsArray[i][j + 1] = '.';
                continue;
            }

            if (patternsArray[i][j] == '.' && j + 1 < rowLength && patternsArray[i][j + 1] == '.')
            {
                var j1 = j;
                while (j1 < rowLength && patternsArray[i][j1] == '.')
                {
                    j1++;
                }

                if (j1 < rowLength && patternsArray[i][j1] == 'O')
                {
                    patternsArray[i][j] = 'O';
                    patternsArray[i][j1] = '.';
                }
            }
        }
    }

    //Console.WriteLine("After West");

    //for (int i = 0; i < patternsArray.Length; i++)
    //{
    //    for (int j = 0; j < patternsArray.Length; j++)
    //    {
    //        Console.Write(patternsArray[i][j]);
    //    }
    //    Console.WriteLine();
    //}
    //Console.WriteLine("-------------");

    // Tilt South
    for (int i = patternsArray.Length - 1; i >= 0; i--)
    {
        var columnLength = patternsArray[i].Length;
        for (int j = columnLength - 1; j >= 0; j--)
        {
            if (patternsArray[j][i] == 'O' || patternsArray[j][i] == '#')
                continue;

            if (patternsArray[j][i] == '.' && j - 1 >= 0 && patternsArray[j - 1][i] == '#')
                continue;

            if (patternsArray[j][i] == '.' && j - 1 >= 0 && patternsArray[j - 1][i] == 'O')
            {
                patternsArray[j][i] = 'O';
                patternsArray[j - 1][i] = '.';
                continue;
            }

            if (patternsArray[j][i] == '.' && j - 1 >= 0 && patternsArray[j - 1][i] == '.')
            {
                var j1 = j;
                while (j1 >= 0 && patternsArray[j1][i] == '.')
                {
                    j1--;
                }

                if (j1 >= 0 && patternsArray[j1][i] == 'O')
                {
                    patternsArray[j][i] = 'O';
                    patternsArray[j1][i] = '.';
                }
            }
        }
    }

    //Console.WriteLine("After South");

    //for (int i = 0; i < patternsArray.Length; i++)
    //{
    //    for (int j = 0; j < patternsArray.Length; j++)
    //    {
    //        Console.Write(patternsArray[i][j]);
    //    }
    //    Console.WriteLine();
    //}
    //Console.WriteLine("-------------");

    // Tilt East
    for (int i = patternsArray.Length - 1; i >= 0; i--)
    {
        var rowLength = patternsArray[0].Length;
        for (int j = rowLength - 1; j >= 0; j--)
        {
            if (patternsArray[i][j] == 'O' || patternsArray[i][j] == '#')
                continue;

            if (patternsArray[i][j] == '.' && j - 1 >= 0 && patternsArray[i][j - 1] == '#')
                continue;

            if (patternsArray[i][j] == '.' && j - 1 >= 0 && patternsArray[i][j - 1] == 'O')
            {
                patternsArray[i][j] = 'O';
                patternsArray[i][j - 1] = '.';
                continue;
            }

            if (patternsArray[i][j] == '.' && j - 1 >= 0 && patternsArray[i][j - 1] == '.')
            {
                var j1 = j;
                while (j1 >= 0 && patternsArray[i][j1] == '.')
                {
                    j1--;
                }

                if (j1 >= 0 && patternsArray[i][j1] == 'O')
                {
                    patternsArray[i][j] = 'O';
                    patternsArray[i][j1] = '.';
                }
            }
        }
    }

    //Console.WriteLine("After East");

    //for (int i = 0; i < patternsArray.Length; i++)
    //{
    //    for (int j = 0; j < patternsArray.Length; j++)
    //    {
    //        Console.Write(patternsArray[i][j]);
    //    }
    //    Console.WriteLine();
    //}
    //Console.WriteLine("-------------\n");
    //k--;

    var mapString = string.Join("\n", patternsArray.Select(l => new string(l)));
    var idx = history.IndexOf(mapString);
    if (idx < 0)
    {
        history.Add(mapString);
    }
    else
    {
        var loopLength = history.Count - idx;
        var remainder = (k) % loopLength;
        var pattern = history[idx + remainder];
        patternsArray = pattern.Split("\n").Select(item => item.ToCharArray()).ToArray();
        break;
    }

    totaLoad = 0;
    for (int i = 0; i < totalCount; i++)
    {
        var existingRocksCount = patternsArray[i].Count(p => p == 'O');
        totaLoad += (existingRocksCount) * (totalCount - i);
    }
    loads.Add(k, totaLoad);
    //    Console.WriteLine($"{k}\t\t{totaLoad}");
    Console.WriteLine($"{totaLoad}");
}

totaLoad = 0;
for (int i = 0; i < totalCount; i++)
{
    var existingRocksCount = patternsArray[i].Count(p => p == 'O');
    totaLoad += (existingRocksCount) * (totalCount - i);
}
loads.Add(k, totaLoad);

Console.WriteLine("Cycle\t\tLoad");
Console.WriteLine($"{k}\t\t{totaLoad}");

//var fs = File.Create(@"C:\Learning\Projects\AoC\Day14\Output.txt");
using (StreamWriter file = new(@"C:\Learning\Projects\AoC\Day14\Output.txt"))
    foreach (var entry in loads)
        file.WriteLine("[{0} {1}]", entry.Key, entry.Value);

//Console.WriteLine($"Part1: {totaLoad}");

struct Rock
{
    internal (int, int) Position;
    internal int Load;
    internal (int, int) ExistingPosition;
}

//var input = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day14\Input.txt").Select(s => s.ToCharArray()).ToArray();

//TiltNorth();

//var part1 = 0;

//for (var score = input.Length; score > 0; score--)
//{
//    part1 += input[^score].Count(c => c == 'O') * score;
//}

//Console.WriteLine($"Part 1: {part1}");

//var cache = new Dictionary<string, int>();
//var cycle = 1;
//int counter = 1;

//while (cycle <= 1_000_000_000)
//{
//    TiltNorth();
//    TiltWest();
//    TiltSouth();
//    TiltEast();

//    var current = string.Join(string.Empty, input.SelectMany(c => c));

//    if (cache.TryGetValue(current, out var cached))
//    {
//        var remaining = 1_000_000_000 - cycle - 1;
//        var loop = cycle - cached;

//        var loopRemaining = remaining % loop;
//        cycle = 1_000_000_000 - loopRemaining - 1;
//    }
//    counter++;
//    cache[current] = cycle++;
//}

//var part2 = 0;

//for (var score = input.Length; score > 0; score--)
//{
//    part2 += input[^score].Count(c => c == 'O') * score;
//}

//Console.WriteLine($"Part 2: {part2}");
//Console.WriteLine($"Part 2: {counter}");
//return;

//void TiltNorth()
//{
//    for (var row = 1; row < input.Length; row++)
//    {
//        for (var col = 0; col < input[row].Length; col++)
//        {
//            var c = input[row][col];

//            if (c != 'O')
//            {
//                continue;
//            }

//            var previous = 1;
//            while (input[row - previous][col] == '.')
//            {
//                input[row - previous][col] = 'O';
//                input[row - previous + 1][col] = '.';
//                previous++;

//                if (row - previous < 0)
//                {
//                    break;
//                }
//            }
//        }
//    }
//}

//void TiltSouth()
//{
//    for (var row = input.Length - 2; row >= 0; row--)
//    {
//        for (var col = 0; col < input[row].Length; col++)
//        {
//            var c = input[row][col];

//            if (c != 'O')
//            {
//                continue;
//            }

//            var previous = 1;
//            while (input[row + previous][col] == '.')
//            {
//                input[row + previous][col] = 'O';
//                input[row + previous - 1][col] = '.';
//                previous++;

//                if (row + previous >= input.Length)
//                {
//                    break;
//                }
//            }
//        }
//    }
//}

//void TiltWest()
//{
//    for (var row = 0; row < input.Length; row++)
//    {
//        for (var col = 1; col < input[row].Length; col++)
//        {
//            var c = input[row][col];

//            if (c != 'O')
//            {
//                continue;
//            }

//            var previous = 1;
//            while (input[row][col - previous] == '.')
//            {
//                input[row][col - previous] = 'O';
//                input[row][col - previous + 1] = '.';
//                previous++;

//                if (col - previous < 0)
//                {
//                    break;
//                }
//            }
//        }
//    }
//}

//void TiltEast()
//{
//    for (var row = 0; row < input.Length; row++)
//    {
//        for (var col = input[row].Length - 2; col >= 0; col--)
//        {
//            var c = input[row][col];

//            if (c != 'O')
//            {
//                continue;
//            }

//            var previous = 1;
//            while (input[row][col + previous] == '.')
//            {
//                input[row][col + previous] = 'O';
//                input[row][col + previous - 1] = '.';
//                previous++;

//                if (col + previous >= input[row].Length)
//                {
//                    break;
//                }
//            }
//        }
//    }
//}