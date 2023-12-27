Console.WriteLine("Day 25");
var inputs = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day25\Input.txt");
List<Component> components = new();

foreach (var input in inputs)
{
    var component = input.Split(new char[] { ':', ' ' }, StringSplitOptions.TrimEntries);
    components.Add(new Component(component[0], component.Skip(1).Where(c => !string.IsNullOrEmpty(c)).ToList()));
}

var groupProduct = 1;
Console.WriteLine($"Part1: {groupProduct}");
record Component(string Name, List<string> Connections)
{

}