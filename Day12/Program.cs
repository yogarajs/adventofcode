Console.WriteLine("Day 12");
var lines = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day12\Input.txt").ToList();
var springs = new List<string>();
var groups = new Dictionary<int, List<int>>();
var i = 1;
foreach (var line in lines)
{
    var l = line.Split();
    springs.Add(l[0]);
    groups.Add(i, l[1].Split(',').Select(int.Parse).ToList());
    i++;
}

var split = lines.SelectMany(line => line.Split().Select(x => new { employeeId = line[0], payrollId = line[1] }));

var sum = 0;
Console.WriteLine($"Part1: {sum}");