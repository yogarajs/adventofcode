using System.Linq;

Console.WriteLine("Day 20");
var lines = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day20\Input.txt");
var modules = new Dictionary<string, Module>();
var totalLowPulses = 0;
var totalHighPulses = 0;
var delimiters = new string[] { "->", ", " };
var pulseQueue = new Queue<Pulse>();

foreach (var line in lines)
{
    var module = line.Split(delimiters, StringSplitOptions.TrimEntries);
    if (module[0].First() == 'b')
    {
        var name = module[0];
        modules.Add(name, new Module
        {
            Name = name,
            State = false,
            ModuleType = ModuleType.Broadcast,
            //PulseMemory = PulseType.None,
            DestinationModuleNames = module[1..].ToList(),
            //DestinationModules = module[1..].Select(m => new Module { Name = m, State = false, /*PulseMemory = PulseType.None*/ }).ToList()
        });
    }
    else
    {
        var name = module[0][1..];
        var moduleType = module[0].First() == '%' ? ModuleType.FlipFlop : ModuleType.SingleInputConjuction;
        modules.Add(name, new Module
        {
            Name = name,
            State = false,
            ModuleType = moduleType,
            //PulseMemory = moduleType == ModuleType.SingleInputConjuction ? PulseType.Low : PulseType.High,
            DestinationModuleNames = module[1..].ToList(),
            //DestinationModules = module[1..].Select(m => new Module { Name = m, State = false, /*PulseMemory = PulseType.None*/ }).ToList()
        });
    }
}

var multiConjuctionModules = modules.SelectMany(m => m.Value.DestinationModuleNames)
    .GroupBy(m => m)
    .Select(m => new { Name = m.Key, Count = m.Count() })
    .Where(m => m.Count > 1)
    .Select(m => m.Name)
    .ToList();

multiConjuctionModules.ForEach(cm =>
{
    if (modules[cm].ModuleType == ModuleType.SingleInputConjuction)
    {
        modules[cm].PulseMemory = modules.Where(m => m.Value.DestinationModuleNames.Contains(cm)).Select(m => m.Key).ToDictionary(m => m, m => PulseType.Low);
        modules[cm].ModuleType = ModuleType.MultiInputConjuction;
    }
});

for (long i = 0; i < 1000; i++)
{
    totalLowPulses++;
    modules["broadcaster"].DestinationModuleNames.ForEach(dm => { totalLowPulses++; pulseQueue.Enqueue(new Pulse("broadcaster", PulseType.Low, dm)); });
    do
    {
        var (sourceModuleName, pulse, destinationModuleName) = pulseQueue.Dequeue();

        modules.TryGetValue(destinationModuleName, out Module module);

        if (module is not null)
        {
            if (module.ModuleType == ModuleType.FlipFlop)
            {
                if (pulse == PulseType.Low)
                {
                    if (module.State)
                    {
                        module.State = false;
                        module.DestinationModuleNames.ForEach(dm => { totalLowPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.Low, dm)); });
                    }
                    else
                    {
                        module.State = true;
                        module.DestinationModuleNames.ForEach(dm => { totalHighPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.High, dm)); });
                    }
                }
            }
            else if (module.ModuleType == ModuleType.SingleInputConjuction)
            {
                if (pulse == PulseType.Low)
                {
                    module.DestinationModuleNames.ForEach(dm => { totalHighPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.High, dm)); });
                }
                else
                {

                    module.DestinationModuleNames.ForEach(dm => { totalLowPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.Low, dm)); });
                }
            }
            else if (module.ModuleType == ModuleType.MultiInputConjuction)
            {
                var inputModuleNames = module.PulseMemory.Select(pm => pm.Key).ToArray();
                var inputModules = modules.Where(m => inputModuleNames.Contains(m.Key)).Select(m => m.Value.State);
                module.PulseMemory[sourceModuleName] = pulse;

                if (inputModules.All(m => m) && module.PulseMemory.All(pm => pm.Value == PulseType.High))
                {
                    module.DestinationModuleNames.ForEach(dm => { totalLowPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.Low, dm)); });
                }
                else
                {
                    module.DestinationModuleNames.ForEach(dm => { totalHighPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.High, dm)); });
                }
            }
        }
    } while (pulseQueue.Any());
}

Console.WriteLine($"Part1: {totalLowPulses} * {totalHighPulses} = {totalLowPulses * totalHighPulses}");

var sourceModule = "qn";
var sourceModules = modules.Where(m => m.Value.DestinationModuleNames.Contains(sourceModule)).Select(m => m.Key).ToList();
var buttonPressCounts = new Dictionary<string, long>();

// reset
foreach (var module in modules)
{
    module.Value.State = false;
}

for (long i = 0; i < 5000; i++)
{
    totalLowPulses++;
    modules["broadcaster"].DestinationModuleNames.ForEach(dm => { totalLowPulses++; pulseQueue.Enqueue(new Pulse("broadcaster", PulseType.Low, dm)); });
    do
    {
        var (sourceModuleName, pulse, destinationModuleName) = pulseQueue.Dequeue();

        modules.TryGetValue(destinationModuleName, out Module module);

        if (module is not null)
        {
            if (module.ModuleType == ModuleType.FlipFlop)
            {
                if (pulse == PulseType.Low)
                {
                    if (module.State)
                    {
                        module.State = false;
                        module.DestinationModuleNames.ForEach(dm => { totalLowPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.Low, dm)); });
                    }
                    else
                    {
                        module.State = true;
                        module.DestinationModuleNames.ForEach(dm => { totalHighPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.High, dm)); });
                    }
                }
            }
            else if (module.ModuleType == ModuleType.SingleInputConjuction)
            {
                if (pulse == PulseType.Low)
                {
                    if (sourceModules.Contains(module.Name) && !buttonPressCounts.ContainsKey(module.Name))
                    {
                        buttonPressCounts.Add(module.Name, i);
                    }
                    module.DestinationModuleNames.ForEach(dm => { totalHighPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.High, dm)); });
                }
                else
                {

                    module.DestinationModuleNames.ForEach(dm => { totalLowPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.Low, dm)); });
                }
            }
            else if (module.ModuleType == ModuleType.MultiInputConjuction)
            {
                var inputModuleNames = module.PulseMemory.Select(pm => pm.Key).ToArray();
                var inputModules = modules.Where(m => inputModuleNames.Contains(m.Key)).Select(m => m.Value.State);
                module.PulseMemory[sourceModuleName] = pulse;

                if (inputModules.All(m => m) && module.PulseMemory.All(pm => pm.Value == PulseType.High))
                {
                    module.DestinationModuleNames.ForEach(dm => { totalLowPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.Low, dm)); });
                }
                else
                {
                    module.DestinationModuleNames.ForEach(dm => { totalHighPulses++; pulseQueue.Enqueue(new Pulse(module.Name, PulseType.High, dm)); });
                }
            }
        }
    } while (pulseQueue.Any());
}

void Print(string sourceModuleName, PulseType pulse, string destinationModuleName)
{
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine($"{sourceModuleName} {pulse} {destinationModuleName}");
}

long totalCount = 1;
foreach (var buttonPressCount in buttonPressCounts)
{
    totalCount *= (buttonPressCount.Value + 1);
}

Console.WriteLine($"Part2: {totalCount}");

record Module
{
    internal string Name;
    internal bool State;
    internal ModuleType ModuleType;
    //internal List<Module> DestinationModules;
    internal List<string> DestinationModuleNames;
    internal Dictionary<string, PulseType> PulseMemory;
}

record Pulse(string sourceModuleName, PulseType PulseType, string destinationModuleName)
{
}

enum PulseType
{
    None = 0,
    Low,
    High
}

enum ModuleType
{
    FlipFlop,
    SingleInputConjuction,
    MultiInputConjuction,
    Broadcast
}