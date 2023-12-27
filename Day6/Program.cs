Console.WriteLine("Day 6");
var raceData = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day6\Input.txt");
var raceTimings = raceData[0].Substring(raceData[0].IndexOf(':') + 1).Trim().Split(' ').Where(r => !string.IsNullOrEmpty(r)).Select(int.Parse).ToList();
var raceDistances = raceData[1].Substring(raceData[1].IndexOf(':') + 1).Trim().Split(' ').Where(r => !string.IsNullOrEmpty(r)).Select(int.Parse).ToList();
var races = new List<Race>();

int i = 1;
foreach (var raceTime in raceTimings)
{
    for (int j = 0; j < raceTime; j++)
    {
        races.Add(new Race()
        {
            ID = i,
            Time = j,
            Distance = (raceTime - j) * j
        });
    }
    i++;
}

i = 1;
var numberOfWays = 1;
foreach (var raceDistance in raceDistances)
{
    var possibleWays = races.Where(r => r.ID == i && r.Distance > raceDistance).Select(r => r).ToList();
    numberOfWays *= possibleWays.Count;
    i++;
}

Console.WriteLine($"Part1: {numberOfWays}");

i = 1;
races = new List<Race>();
numberOfWays = 0;
var overallRaceTime = long.Parse(string.Join(string.Empty, raceTimings));
var overallDistance = long.Parse(string.Join(string.Empty, raceDistances));

for (long j = 0; j < overallRaceTime; j++)
{
    if ((overallRaceTime - j) * j > overallDistance)
    {
        numberOfWays++;
    }
}
Console.WriteLine($"Part2: {numberOfWays}");

struct Race
{
    internal int ID { get; set; }
    internal long Time { get; set; }
    internal long Distance { get; set; }
}