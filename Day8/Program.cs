Console.WriteLine("Day 8");
var hauntedWastedlandData = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day8\Input.txt");
var directions = hauntedWastedlandData[0].ToArray();
var nodes = new Dictionary<string, (string left, string right)>();

for (var line = 2; line < hauntedWastedlandData.Length; line++)
{
    var data = hauntedWastedlandData[line].Split('=');
    var trimmedData = data[1].Trim();

    var node = new Node()
    {
        CurrentNode = data[0].Trim(),
        Left = trimmedData.Substring(trimmedData.IndexOf('(') + 1, 3),
        Right = trimmedData.Substring(trimmedData.IndexOf(',') + 2, 3)
    };
    nodes.Add(node.CurrentNode, (node.Left, node.Right));
}

var reached = false;
long steps = 0;
var currentNode = nodes["AAA"];
do
{
    foreach (var direction in directions)
    {
        var id = Find(direction, currentNode.left, currentNode.right);
        steps++;

        if (id == "ZZZ")
        {
            reached = true;
            break;
        }

        currentNode = nodes[id];
    }
} while (!reached);

string Find(char direction, string left, string right)
{
    if (direction == 'L')
        return left;
    return right;
}

Console.WriteLine($"Part1: {steps}");

var allNodesEndWithA = nodes.Where(node => node.Key.EndsWith('A')).ToList();
steps = 0;
reached = false;
var stepList = new List<long>();

//do
//{
//    foreach (var direction in directions)
//    {
//        var reachedNodes = allNodesEndWithA.Select(node => Find(direction, node.Value.left, node.Value.right)).ToList();
//        steps++;

//        if (reachedNodes.All(node => node.EndsWith('Z')))
//        {
//            reachedNodes.ForEach(x => Console.WriteLine(x));
//            reached = true;
//            break;
//        }

//        allNodesEndWithA = nodes.Where(node => reachedNodes.Contains(node.Key)).ToList();
//    }
//} while (!reached);


foreach (var node in allNodesEndWithA)
{
    var nodeCurrent = node;
    reached = false;
    steps = 0;
    do
    {
        foreach (var direction in directions)
        {
            var reachedNode = Find(direction, nodeCurrent.Value.left, nodeCurrent.Value.right);
            steps++;

            if (reachedNode.EndsWith('Z'))
            {
                reached = true;
                stepList.Add(steps);
                break;
            }
            nodeCurrent = new KeyValuePair<string, (string left, string right)>(reachedNode, (nodes[reachedNode].left, nodes[reachedNode].right));
        }
    } while (!reached);
}

long lcm = FindLCM(stepList);
Console.WriteLine($"Part2: {lcm}");

long FindLCM(List<long> numbers)
{
    long lcm = numbers[0];
    for (int i = 1; i < numbers.Count; i++)
    {
        lcm = FindLCM2(lcm, numbers[i]);
    }
    return lcm;
}

long FindLCM2(long a, long b)
{
    return a * b / GCD(a, b);
}

long GCD(long a, long b)
{
    while (b != 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

struct Node
{
    internal string CurrentNode;
    internal string Left;
    internal string Right;
}