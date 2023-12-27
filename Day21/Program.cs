Console.WriteLine("Day 21");
var lines = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day21\Input.txt").Select(l => l.ToCharArray()).ToArray();
var gardenPlots = 0;
var startingPosition = (0, 0); // lines.Where((s, i) => s[i] == 'S').Select((p, i) => (p, i));
var rowLength = lines.Length;
var columnLength = lines[0].Length;

//for (int i = 0; i < lines.Length; i++)
//{
//    for (int j = 0; j < lines[i].Length; j++)
//    {
//        if (lines[i][j] == 'S')
//        {
//            startingPosition = (i, j);
//            break;
//        }
//    }
//}

startingPosition = Enumerable.Range(0, rowLength)
                .SelectMany(i => Enumerable.Range(0, columnLength)
                .Where(j => lines[i][j] == 'S')
                .Select(j => (i, j)))
                .Single();


var movements = new HashSet<(int, int)> { startingPosition };
for (var i = 0; i < 64; i++)
{
    movements = new HashSet<(int, int)>(movements
        .SelectMany(it => new[] { 0, 1, 2, 3 }.Select(dir => Move(it.Item1, it.Item2, dir)))
        .Where(dest => dest.Item1 >= 0 && dest.Item2 >= 0 && dest.Item1 < rowLength && dest.Item2 < columnLength && lines[dest.Item1][dest.Item2] != '#'));
}

Console.WriteLine($"Part1: {movements.Count}");

(int, int) Move(int x, int y, int direction, int dist = 1)
{
    return direction switch
    {
        0 => (x - dist, y),
        1 => (x + dist, y),
        2 => (x, y + dist),
        3 => (x, y - dist),
    };
}

//var positionsQueue = new Queue<(int, int, int)>();
//int step = 1, row = 0, column = 0, stepCounter = 1;
//positionsQueue.Enqueue((step, startingPosition.Item1, startingPosition.Item2));

//for (; stepCounter <= 64; stepCounter++)
//{
//    step++;
//    do
//    {
//        (_, row, column) = positionsQueue.Dequeue();

//        // Move North
//        if (row - 1 >= 0 && lines[row - 1][column] != '#')
//        {
//            lines[row - 1][column] = 'O';
//            positionsQueue.Enqueue((step, row - 1, column));
//        }

//        // Move South
//        if (row + 1 < rowLength && lines[row + 1][column] != '#')
//        {
//            lines[row + 1][column] = 'O';
//            positionsQueue.Enqueue((step, row + 1, column));
//        }

//        // Move West
//        if (column - 1 >= 0 && lines[row][column - 1] != '#')
//        {
//            lines[row][column - 1] = 'O';
//            positionsQueue.Enqueue((step, row, column - 1));
//        }

//        // Move East
//        if (column + 1 < columnLength && lines[row][column + 1] != '#')
//        {
//            lines[row][column + 1] = 'O';
//            positionsQueue.Enqueue((step, row, column + 1));
//        }

//        if (startingPosition == (row, column))
//        {
//            lines[row][column] = 'S';
//        }
//        else if (lines[row][column] == 'O')
//        {
//            lines[row][column] = '.';
//        }
//    } while (positionsQueue.Any(pq => pq.Item1 == stepCounter));
//    //Print(lines);
//}

//for (int i = 0; i < lines.Length; i++)
//{
//    for (int j = 0; j < lines[i].Length; j++)
//    {
//        if (lines[i][j] == 'O')
//        {
//            gardenPlots++;
//        }
//    }
//}

//void Print(char[][] lines)
//{
//    Console.WriteLine("===========================");
//    for (int i = 0; i < lines.Length; i++)
//    {
//        for (int j = 0; j < lines[i].Length; j++)
//        {
//            Console.Write(lines[i][j]);
//        }
//        Console.WriteLine();
//    }
//}

//Console.WriteLine($"Part1: {gardenPlots}");