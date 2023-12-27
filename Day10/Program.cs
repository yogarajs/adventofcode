using System.Numerics;

Console.WriteLine("Day 10");
var lines = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day10\Input.txt").ToArray();
ParseMap();
var pipes = new Dictionary<char, (char from, char to)>
{
    { '|', ('N', 'S') },
    { '-', ('E', 'W') },
    { 'L', ('N', 'E') },
    { 'J', ('N', 'W') },
    { '7', ('S', 'W') },
    { 'F', ('S', 'E') },
    { '.', (default(char), default(char)) },
    { 'S', (default(char), default(char)) }
};

(int, int, char) startPosition = (-1, -1, 'S');
bool found = false;

for (int i = 0; i < lines.Length; i++)
{
    var row = lines[i];
    for (int j = 0; j < row.Length; j++)
    {
        if (row[j] == 'S')
        {
            startPosition = (i, j, 'S');
            break;
        }
    }
    if (found)
    {
        break;
    }
}

Console.WriteLine(startPosition);

var neighbours = GetAllNeighbourss(startPosition);
var canGoLeft = CanGoLeft(neighbours.left);
var steps = 0;
var currentCell = startPosition;

void ParseMap()
{
    var rows = lines;
    var crow = rows.Length;
    var ccol = rows[0].Length;
    var res = new Complex[crow];
    for (var irow = 0; irow < crow; irow++)
    {
        for (var icol = 0; icol < ccol; icol++)
        {
            var c = new Complex(icol, irow);
            var c1 = rows[irow][icol];
        }
    }
    //return res;
}

do
{
    if (neighbours.bottom == '|')
    {
        currentCell = (currentCell.Item1 + 1, currentCell.Item2, lines[currentCell.Item1 + 1][currentCell.Item2]);
        steps++;
    }

} while (currentCell.Item3 != 'S');

bool CanGoLeft(char left)
{
    return left != '.' && left != 'S';
}

Console.WriteLine(neighbours);

(char left, char right, char top, char bottom) GetAllNeighbourss((int, int, char) position)
{
    var left = lines[position.Item1][position.Item2 - 1];
    var right = lines[position.Item1][position.Item2 + 1];
    var top = lines[position.Item1 - 1][position.Item2];
    var bottom = lines[position.Item1 + 1][position.Item2];

    return (left, right, top, bottom);
}

//var getNext1 = lines[startPosition.Item1][startPosition.Item2];
//var getNext2 = lines[startPosition.Item1][startPosition.Item2];