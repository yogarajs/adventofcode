Console.WriteLine("Day 3");
var engineSchematics = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day3\Input.txt");
var numbers = new List<Number>();
var symbols = new List<Symbol>();

for (var i = 0; i < engineSchematics.Length; i++)
{
    for (var j = 0; j < engineSchematics[i].Length; j++)
    {
        int number = 0;
        var currentNumber = new Number();
        var currentValue = engineSchematics[i][j];
        
        if (currentValue == '.') { continue; }

        if (char.IsDigit(currentValue))
        {
            number = number * 10 + (int)char.GetNumericValue(currentValue);
            currentNumber.StartPosition = (i, j);

            while (j < engineSchematics[i].Length - 1 && char.IsDigit(engineSchematics[i][j + 1]))
            {
                number = number * 10 + (int)char.GetNumericValue(engineSchematics[i][j + 1]);
                j++;
            }

            currentNumber.EndPosition = (i, j);
            currentNumber.Value = number;
            numbers.Add(currentNumber);
        }
        else
        {
            symbols.Add(new Symbol
            {
                Value = currentValue,
                Position = (i, j)
            });
        }
    }
}

var part1Sum = numbers
    .Where(number => symbols.Any(symbol => AreAdjacent(number, symbol)))
    .Sum(number => number.Value);

Console.WriteLine($"Part 1: {part1Sum}");

var part2Sum = symbols
    .Where(symbol => symbol.Value == '*')
    .Select(symbol => numbers.Where(number => AreAdjacent(number, symbol)))
    .Where(gears => gears.Count() == 2)
    .Sum(gears => gears.Select(x => x.Value).Aggregate((a, b) => a * b));

Console.WriteLine($"Part 2: {part2Sum}");

static bool AreAdjacent(Number number, Symbol symbol)
{
    return Math.Abs(symbol.Position.Row - number.StartPosition.Row) <= 1
           && symbol.Position.Column >= number.StartPosition.Column - 1
           && symbol.Position.Column <= number.EndPosition.Column + 1;
}

internal struct Number
{
    public int Value { get; set; }
    public (int Row, int Column) StartPosition { get; set; }
    public (int Row, int Column) EndPosition { get; set; }
}

internal struct Symbol
{
    public char Value { get; set; }
    public (int Row, int Column) Position { get; set; }
}