Console.WriteLine("Day 15");
var sequences = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day15\Input.txt").ToList();
var hashedValues = new List<int>();
var boxNumber = 0;

foreach (var sequence in sequences)
{
    var steps = sequence.Split(',');
    foreach (var step in steps)
    {
        boxNumber = 0;
        foreach (var stepValue in step)
        {
            boxNumber += (int)stepValue;
            boxNumber *= 17;
            boxNumber %= 256;
        }
        hashedValues.Add(boxNumber);
    }
}

Console.WriteLine($"Part1: {hashedValues.Sum()}");

var boxes = new Dictionary<int, Box>();

foreach (var index in Enumerable.Range(0, 256))
{
    boxes.Add(index, new Box { Number = index + 1 });
}

foreach (var sequence in sequences)
{
    var steps = sequence.Split(',');
    foreach (var step in steps)
    {
        boxNumber = 0;
        if (step.Contains('-'))
        {
            var lens = step[..step.IndexOf('-')];
            foreach (var stepValue in lens)
            {
                boxNumber += (int)stepValue;
                boxNumber *= 17;
                boxNumber %= 256;
            }
            var box = boxes[boxNumber];
            var slotToRemove = box.Slots?.FirstOrDefault(slots => slots.Lens == lens);
            if (slotToRemove is not null)
            {
                boxes[boxNumber].Slots.Remove(slotToRemove);
            }
        }
        else if (step.Contains('='))
        {
            var lens = step[..step.IndexOf('=')];
            var focalLength = (int)char.GetNumericValue(step.Last());
            foreach (var stepValue in lens)
            {
                boxNumber += (int)stepValue;
                boxNumber *= 17;
                boxNumber %= 256;
            }
            var box = boxes[boxNumber];
            var slotToReplace = box.Slots?.FirstOrDefault(slots => slots.Lens == lens);
            if (slotToReplace is not null)
            {
                slotToReplace.FocalLength = focalLength;
            }
            else
            {
                if (box is null)
                {
                    box = new Box
                    {
                        Slots = new List<Slot>
                        {
                            new Slot { FocalLength = focalLength, Lens = lens }
                        }
                    };
                    boxes[boxNumber] = box;
                }
                else
                {
                    box.Slots.Add(new Slot { FocalLength = focalLength, Lens = lens });
                }
            }
        }
    }
}

//var boxHasSlots = boxes.Where(box => box.Value.Slots.Any()).Select(box => box.Value).ToList();
//boxNumber = 0;
//foreach (var box in boxHasSlots)
//{
//    boxNumber += box.Slots.Select((slot, i) => (box.Number * (i + 1) * slot.FocalLength)).Sum();
//}
//Console.WriteLine($"Part2: {boxNumber}"); //233749
Console.WriteLine($"Part2: {boxes.Where(box => box.Value.Slots.Any()).Select(box => box.Value.Slots.Select((slot, i) => (box.Value.Number * (i + 1) * slot.FocalLength)).Sum()).Sum()}"); //233749

record Box
{
    internal Box()
    {
        Number = 0;
        Slots = new List<Slot>();
    }
    internal int Number;
    internal List<Slot> Slots;
}

record Slot
{
    internal int Number;
    internal int FocalLength;
    internal string Lens;
}