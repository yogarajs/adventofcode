Console.WriteLine("Day 9");
var lines = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day9\Input.txt");

List<List<long>> extrapolateList;
long sumLast = 0;
long sumFirst = 0;

foreach (var line in lines)
{
    extrapolateList = new List<List<long>>();
    var list = line.Split().Where(l => !string.IsNullOrEmpty(l)).Select(long.Parse).ToList();
    Extrapolate(list);
    FindHistoryLastValue(extrapolateList);
    FindHistoryFirstValue(extrapolateList);
    sumLast += extrapolateList[0].Last();
    sumFirst += extrapolateList[0].First();
}

void FindHistoryLastValue(List<List<long>> extrapolateList)
{
    var listCount = extrapolateList.Count;
    for (int i = listCount - 2; i >= 0; i--)
    {
        extrapolateList[i].Add(extrapolateList[i].Last() + extrapolateList[i + 1].Last());
    }
}

void FindHistoryFirstValue(List<List<long>> extrapolateList)
{
    var listCount = extrapolateList.Count;
    for (int i = listCount - 2; i >= 0; i--)
    {
        extrapolateList[i].Insert(0, extrapolateList[i].First() - extrapolateList[i + 1].First());
    }
}

void Extrapolate(List<long> line)
{
    extrapolateList.Add(line);
    var differenceList = new List<long>();
    var count = line.Count - 1;
    
    for (int i = 0; i < count; i++)
    {
        differenceList.Add(line[i + 1] - line[i]);
    }

    if (differenceList.Any(d => d != 0))
        Extrapolate(differenceList);
}

Console.WriteLine($"Part1: {sumLast}");
Console.WriteLine($"Part2: {sumFirst}");