using System.Text;

Console.WriteLine("Day 1");
var lines = await File.ReadAllLinesAsync(@"C:\Learning\Projects\AoC\Day1\Input.txt");
var calibrationValues = new string[lines.Length];
int sum = 0;

// Part 1
foreach (var line in lines)
{
    var onlyDigits = line.Where(x => char.IsDigit(x));
    var calibrationValue = (int)(char.GetNumericValue(onlyDigits.First()) * 10 + char.GetNumericValue(onlyDigits.Last()));
    sum += calibrationValue;
}
Console.WriteLine($"Part 1: {sum}");

// Part 2
int i = 0;
sum = 0;
foreach (var line in lines)
{
    var lineInTolower = line.ToLower();
    var lineLength = line.Length;
    var calibrationValueBuilder = new StringBuilder();

    for (int j = 0; j < lineLength; j++)
    {
        if (char.IsDigit(lineInTolower[j]))
        {
            calibrationValueBuilder.Append(lineInTolower[j]);
        }
        else
        {
            ParseLineAndExtractNumber(lineInTolower, j, calibrationValueBuilder);
        }
    }
    var calibrationValueString = calibrationValueBuilder.ToString();
    calibrationValues[i] = calibrationValueString;
    var calibrationValue = (int)(char.GetNumericValue(calibrationValueString.First()) * 10 + char.GetNumericValue(calibrationValueString.Last()));
    sum += calibrationValue;
    i++;
}

void ParseLineAndExtractNumber(string line, int index, StringBuilder calibrationValue)
{
    var numbers = new Dictionary<string, string> { { "one", "1" }, { "two", "2" }, { "three", "3" }, { "four", "4" }, { "five", "5" }, { "six", "6" }, { "seven", "7" }, { "eight", "8" }, { "nine", "9" } };

    foreach (var number in numbers.Keys)
    {
        if ((index + number.Length) - 1 < line.Length && line.Substring(index, number.Length).Equals(number))
        {
            calibrationValue.Append(numbers[number]);
        }
    }
}

Console.WriteLine($"Part 2: {sum}");