//Console.WriteLine("Day 5");
//var data = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day4\Input.txt");
//var seeds = data[0].Substring(data[0].IndexOf(':') + 1).Trim().Split(' ').Select(long.Parse).ToList();
//var garden = new Garden();

//for (var i = 2; i < data.Length;)
//{
//    if (data[i].Equals("seed-to-soil map:"))
//    {
//        i++;
//        while (!string.IsNullOrEmpty(data[i]))
//        {
//            var ranges = data[i].Split(' ');
//            var destinationStart = long.Parse(ranges[0]);
//            var sourceStart = long.Parse(ranges[1]);
//            var range = long.Parse(ranges[2]);
//            while (range > 0)
//            {
//                garden.SeedToSoil.Add(sourceStart++, destinationStart++);
//                range--;
//            }
//            i++;
//        }
//    }
//    if (data[i].Equals("soil-to-fertilizer map:"))
//    {
//        i++;
//        while (!string.IsNullOrEmpty(data[i]))
//        {
//            var ranges = data[i].Split(' ');
//            var destinationStart = long.Parse(ranges[0]);
//            var sourceStart = long.Parse(ranges[1]);
//            var range = long.Parse(ranges[2]);
//            while (range > 0)
//            {
//                garden.SoilToFertilizer.Add(sourceStart++, destinationStart++);
//                range--;
//            }
//            i++;
//        }
//    }
//    if (data[i].Equals("fertilizer-to-water map:"))
//    {
//        i++;
//        while (!string.IsNullOrEmpty(data[i]))
//        {
//            var ranges = data[i].Split(' ');
//            var destinationStart = long.Parse(ranges[0]);
//            var sourceStart = long.Parse(ranges[1]);
//            var range = long.Parse(ranges[2]);
//            while (range > 0)
//            {
//                garden.FertilizerToWater.Add(sourceStart++, destinationStart++);
//                range--;
//            }
//            i++;
//        }
//    }
//    if (data[i].Equals("water-to-light map:"))
//    {
//        i++;
//        while (!string.IsNullOrEmpty(data[i]))
//        {
//            var ranges = data[i].Split(' ');
//            var destinationStart = long.Parse(ranges[0]);
//            var sourceStart = long.Parse(ranges[1]);
//            var range = long.Parse(ranges[2]);
//            while (range > 0)
//            {
//                garden.WaterToLight.Add(sourceStart++, destinationStart++);
//                range--;
//            }
//            i++;
//        }
//    }
//    if (data[i].Equals("light-to-temperature map:"))
//    {
//        i++;
//        while (!string.IsNullOrEmpty(data[i]))
//        {
//            var ranges = data[i].Split(' ');
//            var destinationStart = long.Parse(ranges[0]);
//            var sourceStart = long.Parse(ranges[1]);
//            var range = long.Parse(ranges[2]);
//            while (range > 0)
//            {
//                garden.LightToTemperature.Add(sourceStart++, destinationStart++);
//                range--;
//            }
//            i++;
//        }
//    }
//    if (data[i].Equals("temperature-to-humidity map:"))
//    {
//        i++;
//        while (!string.IsNullOrEmpty(data[i]))
//        {
//            var ranges = data[i].Split(' ');
//            var destinationStart = long.Parse(ranges[0]);
//            var sourceStart = long.Parse(ranges[1]);
//            var range = long.Parse(ranges[2]);
//            while (range > 0)
//            {
//                garden.TemperatureToHumidity.Add(sourceStart++, destinationStart++);
//                range--;
//            }
//            i++;
//        }
//    }
//    if (data[i].Equals("humidity-to-location map:"))
//    {
//        i++;
//        while (i < data.Length && !string.IsNullOrEmpty(data[i]))
//        {
//            var ranges = data[i].Split(' ');
//            var destinationStart = long.Parse(ranges[0]);
//            var sourceStart = long.Parse(ranges[1]);
//            var range = long.Parse(ranges[2]);
//            while (range > 0)
//            {
//                garden.HumidityToLocation.Add(sourceStart++, destinationStart++);
//                range--;
//            }
//            i++;
//        }
//    }
//    i++;
//}

//var locations = new List<long>();
//foreach (var seed in seeds)
//{
//    var s1 = garden.SeedToSoil.GetValueOrDefault(seed, seed);
//    var s2 = garden.SoilToFertilizer.GetValueOrDefault(s1, s1);
//    var s3 = garden.FertilizerToWater.GetValueOrDefault(s2, s2);
//    var s4 = garden.WaterToLight.GetValueOrDefault(s3, s3);
//    var s5 = garden.LightToTemperature.GetValueOrDefault(s4, s4);
//    var s6 = garden.TemperatureToHumidity.GetValueOrDefault(s5, s5);
//    var s7 = garden.HumidityToLocation.GetValueOrDefault(s6, s6);
//    locations.Add(s7);
//}

//Console.WriteLine(locations.Min());

//struct Garden
//{
//    public Garden()
//    {
//        SeedToSoil = new Dictionary<long, long>();
//        SoilToFertilizer = new Dictionary<long, long>();
//        FertilizerToWater = new Dictionary<long, long>();
//        WaterToLight = new Dictionary<long, long>();
//        LightToTemperature = new Dictionary<long, long>();
//        TemperatureToHumidity = new Dictionary<long, long>();
//        HumidityToLocation = new Dictionary<long, long>();
//    }

//    internal Dictionary<long, long> SeedToSoil { get; set; }
//    internal Dictionary<long, long> SoilToFertilizer { get; set; }
//    internal Dictionary<long, long> FertilizerToWater { get; set; }
//    internal Dictionary<long, long> WaterToLight { get; set; }
//    internal Dictionary<long, long> LightToTemperature { get; set; }
//    internal Dictionary<long, long> TemperatureToHumidity { get; set; }
//    internal Dictionary<long, long> HumidityToLocation { get; set; }
//}