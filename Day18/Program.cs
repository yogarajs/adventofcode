Console.WriteLine("Day 18");
var digPatterns = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day18\Input.txt");
var lines = new List<Line>();
var currentPosition = (50, 50);
var gardenPlane = new char[500][];

for (int i = 0; i < 500; i++)
{
    gardenPlane[i] = Enumerable.Repeat('.', 500).ToArray();
}

var area = 0;

foreach (var digPattern in digPatterns)
{
    var digs = digPattern.Split(' ', StringSplitOptions.TrimEntries);
    var digDirection = digs[0];
    var digSteps = int.Parse(digs[1]);
    if (digDirection == "R")
    {
        var startPosition = currentPosition;
        var endPosition = (currentPosition.Item1, currentPosition.Item2 + digSteps);
        currentPosition = endPosition;
        lines.Add(new Line(startPosition, endPosition));
    }
    else if (digDirection == "L")
    {
        var startPosition = currentPosition;
        var endPosition = (currentPosition.Item1, currentPosition.Item2 - digSteps);
        currentPosition = endPosition;
        lines.Add(new Line(startPosition, endPosition));
    }
    else if (digDirection == "U")
    {
        var startPosition = currentPosition;
        var endPosition = (currentPosition.Item1 + digSteps, currentPosition.Item2);
        currentPosition = endPosition;
        lines.Add(new Line(startPosition, endPosition));
    }
    else
    {
        var startPosition = currentPosition;
        var endPosition = (currentPosition.Item1 - digSteps, currentPosition.Item2);
        currentPosition = endPosition;
        lines.Add(new Line(startPosition, endPosition));
    }
}

lines.ForEach(line =>
{
    Console.WriteLine(line.ToString());
    if (line.StartPosition.Item1 == line.EndPosition.Item1)
    {
        var startingColumn = Math.Abs(line.StartPosition.Item2);
        var endingColumn = Math.Abs(line.EndPosition.Item2);
        if (startingColumn <= endingColumn)
        {
            while (startingColumn <= endingColumn)
            {
                gardenPlane[Math.Abs(line.StartPosition.Item1)][startingColumn] = '#';
                startingColumn++;
            }
        }
        else
        {
            while (startingColumn >= endingColumn)
            {
                gardenPlane[Math.Abs(line.StartPosition.Item1)][startingColumn] = '#';
                startingColumn--;
            }
        }
    }
    else if (line.StartPosition.Item2 == line.EndPosition.Item2)
    {
        var startingRow = Math.Abs(line.StartPosition.Item1);
        var endingRow = Math.Abs(line.EndPosition.Item1);
        if (startingRow <= endingRow)
        {
            while (startingRow <= endingRow)
            {
                gardenPlane[startingRow][Math.Abs(line.EndPosition.Item2)] = '#';
                startingRow++;
            }
        }
        else
        {
            while (startingRow >= endingRow)
            {
                gardenPlane[startingRow][Math.Abs(line.EndPosition.Item2)] = '#';
                startingRow--;
            }
        }
    }
});

for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100; j++)
    {
        Console.Write(gardenPlane[i][j]);
    }
    Console.WriteLine();
}

//for (int i = 0; i < 500; i++)
//{
//    var found = false;
//    for (int j = 0; j < 500; j++)
//    {
//        while (j < 500 && gardenPlane[i][j] == '#')
//        {
//            found = true;
//            area++;
//            j++;
//        }
//        while (found && j < 500 && gardenPlane[i][j] != '#')
//        {
//            gardenPlane[i][j] = '#';
//            area++;
//            j++;
//        }
//        area++;
//        found = false;
//        //if (gardenPlane[i, j] == '#')
//        //{
//        //    area++;
//        //    j++;
//        //    if (gardenPlane[i, j] == '.')
//        //    {
//        //        area++;
//        //        j++;
//        //        while (gardenPlane[i, j] != '#')
//        //        {
//        //            area++;
//        //            j++;
//        //        }
//        //        area++;
//        //    }
//        //    else if (gardenPlane[i, j] == '#')
//        //    {
//        //        area++;
//        //        j++;
//        //        while (gardenPlane[i, j] != '.')
//        //        {
//        //            area++;
//        //            j++;
//        //        }
//        //    }
//        //}
//    }
//}

foreach (var plane in gardenPlane)
{
    if (plane.Any(p => p == '#'))
    {
        var start = plane.ToList().IndexOf('#');
        var end = plane.ToList().LastIndexOf('#');
        area += end - start + 1;
    }
}

Console.WriteLine($"Part1:{area}");

record Line((int, int) StartPosition, (int, int) EndPosition)
{
    public override string ToString()
    {
        return $"({this.StartPosition.Item1}, {this.StartPosition.Item2}) ({this.EndPosition.Item1}, {this.EndPosition.Item2})";
    }
}

enum Direction
{
    Left = 0,
    Right = 1,
    Up = 2,
    Down = 3
}
