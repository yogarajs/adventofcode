Console.WriteLine("Day 5");
var data = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day5\Input.txt");
var seedRange = data[0].Substring(data[0].IndexOf(':') + 1).Trim().Split(' ').Select(long.Parse).ToList();
var garden = new Garden();

for (var i = 2; i < data.Length;)
{
    if (data[i].Equals("seed-to-soil map:"))
    {
        i++;
        while (!string.IsNullOrEmpty(data[i]))
        {
            var ranges = data[i].Split(' ');
            var destinationStart = long.Parse(ranges[0]);
            var sourceStart = long.Parse(ranges[1]);
            var range = long.Parse(ranges[2]);
            garden.SeedToSoil.Add(new Mapper()
            {
                SourceStart = sourceStart,
                SourceEnd = (sourceStart + range) - 1,
                DestinationStart = destinationStart,
                DestinationEnd = (destinationStart + range) - 1,
                Range = range
            });
            i++;
        }
    }
    if (data[i].Equals("soil-to-fertilizer map:"))
    {
        i++;
        while (!string.IsNullOrEmpty(data[i]))
        {
            var ranges = data[i].Split(' ');
            var destinationStart = long.Parse(ranges[0]);
            var sourceStart = long.Parse(ranges[1]);
            var range = long.Parse(ranges[2]);
            garden.SoilToFertilizer.Add(new Mapper()
            {
                SourceStart = sourceStart,
                SourceEnd = (sourceStart + range) - 1,
                DestinationStart = destinationStart,
                DestinationEnd = (destinationStart + range) - 1,
                Range = range
            });
            i++;
        }
    }
    if (data[i].Equals("fertilizer-to-water map:"))
    {
        i++;
        while (!string.IsNullOrEmpty(data[i]))
        {
            var ranges = data[i].Split(' ');
            var destinationStart = long.Parse(ranges[0]);
            var sourceStart = long.Parse(ranges[1]);
            var range = long.Parse(ranges[2]);
            garden.FertilizerToWater.Add(new Mapper() { SourceStart = sourceStart, SourceEnd = (sourceStart + range) - 1, DestinationStart = destinationStart, DestinationEnd = (destinationStart + range) - 1, Range = range });
            i++;
        }
    }
    if (data[i].Equals("water-to-light map:"))
    {
        i++;
        while (!string.IsNullOrEmpty(data[i]))
        {
            var ranges = data[i].Split(' ');
            var destinationStart = long.Parse(ranges[0]);
            var sourceStart = long.Parse(ranges[1]);
            var range = long.Parse(ranges[2]);
            garden.WaterToLight.Add(new Mapper() { SourceStart = sourceStart, SourceEnd = (sourceStart + range) - 1, DestinationStart = destinationStart, DestinationEnd = (destinationStart + range) - 1, Range = range });
            i++;
        }
    }
    if (data[i].Equals("light-to-temperature map:"))
    {
        i++;
        while (!string.IsNullOrEmpty(data[i]))
        {
            var ranges = data[i].Split(' ');
            var destinationStart = long.Parse(ranges[0]);
            var sourceStart = long.Parse(ranges[1]);
            var range = long.Parse(ranges[2]);
            garden.LightToTemperature.Add(new Mapper() { SourceStart = sourceStart, SourceEnd = (sourceStart + range) - 1, DestinationStart = destinationStart, DestinationEnd = (destinationStart + range) - 1, Range = range });
            i++;
        }
    }
    if (data[i].Equals("temperature-to-humidity map:"))
    {
        i++;
        while (!string.IsNullOrEmpty(data[i]))
        {
            var ranges = data[i].Split(' ');
            var destinationStart = long.Parse(ranges[0]);
            var sourceStart = long.Parse(ranges[1]);
            var range = long.Parse(ranges[2]);
            garden.TemperatureToHumidity.Add(new Mapper() { SourceStart = sourceStart, SourceEnd = (sourceStart + range) - 1, DestinationStart = destinationStart, DestinationEnd = (destinationStart + range) - 1, Range = range });
            i++;
        }
    }
    if (data[i].Equals("humidity-to-location map:"))
    {
        i++;
        while (i < data.Length && !string.IsNullOrEmpty(data[i]))
        {
            var ranges = data[i].Split(' ');
            var destinationStart = long.Parse(ranges[0]);
            var sourceStart = long.Parse(ranges[1]);
            var range = long.Parse(ranges[2]);
            garden.HumidityToLocation.Add(new Mapper() { SourceStart = sourceStart, SourceEnd = (sourceStart + range) - 1, DestinationStart = destinationStart, DestinationEnd = (destinationStart + range) - 1, Range = range });
            i++;
        }
    }
    i++;
}

var locations = new List<long>();
var minlocation = long.MaxValue;

Parallel.ForEach(seedRange, seed =>
{
    GetMinimumLocation(seed);
});

Console.WriteLine($"Part1: {minlocation}");

//for (int i = 0; i < seedRange.Count; i += 2)
//{
//    var start = seedRange[i];
//    var range = seedRange[i + 1];
//    Parallel.For(start, (start + range) - 1, j => GetMinimumLocation(j));
//}

Parallel.For(seedRange[0], (seedRange[0] + seedRange[1]) - 1, j => GetMinimumLocation(j));
Parallel.For(seedRange[2], (seedRange[2] + seedRange[3]) - 1, j => GetMinimumLocation(j));
Parallel.For(seedRange[4], (seedRange[4] + seedRange[5]) - 1, j => GetMinimumLocation(j));
Parallel.For(seedRange[6], (seedRange[6] + seedRange[7]) - 1, j => GetMinimumLocation(j));
Parallel.For(seedRange[8], (seedRange[8] + seedRange[9]) - 1, j => GetMinimumLocation(j));
Parallel.For(seedRange[10], (seedRange[10] + seedRange[11]) - 1, j => GetMinimumLocation(j));
Parallel.For(seedRange[12], (seedRange[12] + seedRange[13]) - 1, j => GetMinimumLocation(j));
Parallel.For(seedRange[14], (seedRange[14] + seedRange[15]) - 1, j => GetMinimumLocation(j));
Parallel.For(seedRange[16], (seedRange[16] + seedRange[17]) - 1, j => GetMinimumLocation(j));
Parallel.For(seedRange[18], (seedRange[18] + seedRange[19]) - 1, j => GetMinimumLocation(j));

void GetMinimumLocation(long seed)
{
    var soil = garden.SeedToSoil.Where(x => x.SourceStart <= seed && x.SourceEnd >= seed).Select(x => seed + (x.DestinationStart == 0 ? Math.Abs(x.DestinationStart - x.SourceStart) : x.DestinationStart - x.SourceStart)).FirstOrDefault();
    soil = soil == 0 ? seed : soil;

    var fertilizer = garden.SoilToFertilizer.Where(x => x.SourceStart <= soil && x.SourceEnd >= soil).Select(x => soil + (x.DestinationStart == 0 ? Math.Abs(x.DestinationStart - x.SourceStart) : x.DestinationStart - x.SourceStart)).FirstOrDefault();
    fertilizer = fertilizer == 0 ? soil : fertilizer;

    var water = garden.FertilizerToWater.Where(x => x.SourceStart <= fertilizer && x.SourceEnd >= fertilizer).Select(x => fertilizer + (x.DestinationStart == 0 ? (x.DestinationStart - x.SourceStart) : x.DestinationStart - x.SourceStart)).FirstOrDefault();
    water = water == 0 ? fertilizer : water;

    var light = garden.WaterToLight.Where(x => x.SourceStart <= water && x.SourceEnd >= water).Select(x => water + (x.DestinationStart == 0 ? Math.Abs(x.DestinationStart - x.SourceStart) : x.DestinationStart - x.SourceStart)).FirstOrDefault();
    light = light == 0 ? water : light;

    var temperature = light == 0 ? water : garden.LightToTemperature.Where(x => x.SourceStart <= light && x.SourceEnd >= light).Select(x => light + (x.DestinationStart == 0 ? Math.Abs(x.DestinationStart - x.SourceStart) : x.DestinationStart - x.SourceStart)).FirstOrDefault();
    temperature = temperature == 0 ? light : temperature;

    var humidity = temperature == 0 ? light : garden.TemperatureToHumidity.Where(x => x.SourceStart <= temperature && x.SourceEnd >= temperature).Select(x => temperature + (x.DestinationStart == 0 ? Math.Abs(x.DestinationStart - x.SourceStart) : x.DestinationStart - x.SourceStart)).FirstOrDefault();
    humidity = humidity == 0 ? temperature : humidity;

    var location = humidity == 0 ? temperature : garden.HumidityToLocation.Where(x => x.SourceStart <= humidity && x.SourceEnd >= humidity).Select(x => humidity + (x.DestinationStart == 0 ? Math.Abs(x.DestinationStart - x.SourceStart) : x.DestinationStart - x.SourceStart)).FirstOrDefault();
    location = location == 0 ? humidity : location;

    minlocation = location < minlocation ? location : minlocation;
}

Console.WriteLine($"Part1: {minlocation}");

struct Garden
{
    public Garden()
    {
        SeedToSoil = new List<Mapper>();
        SoilToFertilizer = new List<Mapper>();
        FertilizerToWater = new List<Mapper>();
        WaterToLight = new List<Mapper>();
        LightToTemperature = new List<Mapper>();
        TemperatureToHumidity = new List<Mapper>();
        HumidityToLocation = new List<Mapper>();
    }

    internal List<Mapper> SeedToSoil { get; set; }
    internal List<Mapper> SoilToFertilizer { get; set; }
    internal List<Mapper> FertilizerToWater { get; set; }
    internal List<Mapper> WaterToLight { get; set; }
    internal List<Mapper> LightToTemperature { get; set; }
    internal List<Mapper> TemperatureToHumidity { get; set; }
    internal List<Mapper> HumidityToLocation { get; set; }
}

struct Mapper
{
    internal long SourceStart;
    internal long SourceEnd;
    internal long DestinationStart;
    internal long DestinationEnd;
    internal long Range;
}