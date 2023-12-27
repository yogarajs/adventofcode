//Console.WriteLine("Day 6");
//var raceData = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day6\Input.txt");
//var raceTimings = raceData[0].Substring(raceData[0].IndexOf(':') + 1).Trim().Split(' ').Where(r => !string.IsNullOrEmpty(r)).Select(int.Parse).ToList();
//var raceDistances = raceData[1].Substring(raceData[1].IndexOf(':') + 1).Trim().Split(' ').Where(r => !string.IsNullOrEmpty(r)).Select(int.Parse).ToList();
//var races = new List<Race>();

//int i = 1;
//foreach (var raceTime in raceTimings)
//{
//    for (int j = 0; j < raceTime; j++)
//    {
//        races.Add(new Race()
//        {
//            ID = i,
//            Time = j,
//            Distance = (raceTime - j) * j
//        });
//    }
//    i++;
//}

//i = 1;
//var numberOfWays = 1;
//foreach (var raceDistance in raceDistances)
//{
//    var possibleWays = races.Where(r => r.ID == i && r.Distance > raceDistance).Select(r => r).ToList();
//    numberOfWays *= possibleWays.Count;
//    i++;
//}

//Console.WriteLine(numberOfWays);

//struct Race
//{
//    internal int ID { get; set; }
//    internal int Time { get; set; }
//    internal int Distance { get; set; }
//}


//Console.WriteLine("Day 6");
//var raceData = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day6\Input.txt");
//var raceTimings = raceData[0].Substring(raceData[0].IndexOf(':') + 1).Trim().Split(' ').Where(r => !string.IsNullOrEmpty(r)).Select(int.Parse).ToList();
//var raceDistances = raceData[1].Substring(raceData[1].IndexOf(':') + 1).Trim().Split(' ').Where(r => !string.IsNullOrEmpty(r)).Select(int.Parse).ToList();
//var races = new List<Race>();

//int i = 1;
//var overallRaceTime = 0;
//for (i = 0; i < raceTimings.Count; i++)
//{
//    overallRaceTime = (overallRaceTime * 10 * i) + raceTimings[i];
//}

//for (long j = 0; j < 62649190; j++)
//{
//    races.Add(new Race()
//    {
//        ID = i,
//        Time = j,
//        Distance = (62649190 - j) * j
//    });
//}

//var overallDistance = 0;
//foreach (var raceDistance in raceDistances)
//{
//    overallDistance = (overallDistance * 10) + raceDistance;
//}

//i = 1;
//var numberOfWays = races.Where(r => r.ID == i && r.Distance > 553101014731074).Select(r => r).Count();

//Console.WriteLine(numberOfWays);

//struct Race
//{
//    internal int ID { get; set; }
//    internal long Time { get; set; }
//    internal long Distance { get; set; }
//}