Console.WriteLine("Day 13");
var patterns = File.ReadAllLines(@"C:\Users\ys\Downloads\AoC (3)\AoC\Day13\Input.txt").ToList();
//var chunkedPatterns = new Dictionary<int, List<string>>();
var chunkedPatterns = new List<List<string>>();

var chunkSizeList = Enumerable.Range(0, patterns.Count).Where(row => string.IsNullOrWhiteSpace(patterns[row])).ToList();
int i = 0;
int sum = 0;

//chunkSizeList.ForEach(x =>
//{
//    chunkedPatterns.Add(x, patterns.Skip(i).Take(x - i).ToList());
//    i = x + 1;
//});

for (i = 0; i < patterns.Count; i++)
{
    var pattern = new List<string>();
    while (i < patterns.Count && !string.IsNullOrWhiteSpace(patterns[i]))
    {
        pattern.Add(patterns[i]);
        i++;
    }
    chunkedPatterns.Add(pattern);
}

CheckRowReflection();

void CheckRowReflection()
{
    var rows = new Dictionary<int, int>();
    var columns = new Dictionary<int, int>();
    int length, startPosition;
    bool reflectionFound;
    int rowReflectionCount = 0;
    int columnReflectionCount = 0;

    i = 0;
    foreach (var pattern in chunkedPatterns)
    {
        length = pattern.Count;
        startPosition = length / 2;
        reflectionFound = false;

        int row1 = startPosition;
        int row2 = startPosition + 1;
        rowReflectionCount = row1;
        while (row1 >= 0 && row2 < length && pattern[row1].SequenceEqual(pattern[row2]))
        {
            reflectionFound = true;
            row1--;
            row2++;
        }

        //reflectionFound = reflectionFound && (row1 < 0 || row2 >= length);
        if (!reflectionFound)
        {
            rowReflectionCount = row1 = startPosition - 1;
            row2 = startPosition;

            while (row1 >= 0 && row2 < length && pattern[row1].SequenceEqual(pattern[row2]))
            {
                reflectionFound = true;
                row1--;
                row2++;
            }
        }

        //reflectionFound = reflectionFound && (row1 < 0 || row2 >= length);
        if (!reflectionFound)
        {
            rowReflectionCount = row1 = startPosition + 1;
            row2 = startPosition + 2;

            while (row1 >= 0 && row2 < length && pattern[row1].SequenceEqual(pattern[row2]))
            {
                reflectionFound = true;
                row1--;
                row2++;
            }
        }

        //reflectionFound = reflectionFound && (row1 < 0 || row2 >= length);

        if (reflectionFound)
        {
            Console.WriteLine($"Part1: matching rows: {rowReflectionCount}");
            rows.Add(i, rowReflectionCount + 1);
            i++;
            continue;
        }
        //else
        //{
        //    rows.Add(i, 0);
        //}

        length = pattern.Count;
        var columnLength = pattern[0].Length;
        startPosition = columnLength / 2;
        reflectionFound = false;
        char[] col1Value, col2Value;

        int col1 = startPosition;
        int col2 = startPosition + 1;
        columnReflectionCount = col2;
        while (col1 >= 0 && col2 < columnLength)
        {
            col1Value = Enumerable.Range(0, length).Select(x => pattern[x][col1]).ToArray();
            col2Value = Enumerable.Range(0, length).Select(x => pattern[x][col2]).ToArray();
            reflectionFound = col1Value.SequenceEqual(col2Value);
            col1--;
            col2++;
        }

        //reflectionFound = reflectionFound && (col1 < 0 || col2 >= columnLength);
        if (!reflectionFound)
        {
            columnReflectionCount = col1 = startPosition - 1;
            col2 = startPosition;
            while (col1 >= 0 && col2 < columnLength)
            {
                col1Value = Enumerable.Range(0, length).Select(x => pattern[x][col1]).ToArray();
                col2Value = Enumerable.Range(0, length).Select(x => pattern[x][col2]).ToArray();
                reflectionFound = col1Value.SequenceEqual(col2Value);
                col1--;
                col2++;
            }
        }

        //reflectionFound = reflectionFound && (col1 < 0 || col2 >= columnLength);
        if (!reflectionFound)
        {
            columnReflectionCount = col1 = startPosition + 1;
            col2 = startPosition + 2;
            while (col1 >= 0 && col2 < columnLength)
            {
                col1Value = Enumerable.Range(0, length).Select(x => pattern[x][col1]).ToArray();
                col2Value = Enumerable.Range(0, length).Select(x => pattern[x][col2]).ToArray();
                reflectionFound = col1Value.SequenceEqual(col2Value);
                col1--;
                col2++;
            }
        }

        //reflectionFound = reflectionFound && (col1 < 0 || col2 >= columnLength);
        if (!reflectionFound)
        {
            columnReflectionCount = col1 = startPosition - 2;
            col2 = startPosition - 1;
            while (col1 >= 0 && col2 < columnLength)
            {
                col1Value = Enumerable.Range(0, length).Select(x => pattern[x][col1]).ToArray();
                col2Value = Enumerable.Range(0, length).Select(x => pattern[x][col2]).ToArray();
                reflectionFound = col1Value.SequenceEqual(col2Value);
                col1--;
                col2++;
            }
        }

        if (reflectionFound)
        {
            Console.WriteLine($"Part1: matching column: {columnReflectionCount}");
            columns.Add(i, columnReflectionCount);
            i++;
            //continue;
        }
        //else
        //{
        //    columns.Add(i, 0);
        //}
        //sum += (100 * (rowReflectionCount + 1)) + columnReflectionCount;
    }

    var rowSum = rows.Values.Sum();
    var columnSum = columns.Values.Sum();
    //int rowSum = 0;
    //int columnSum = 0;
    //for (int i = 0; i < rows.Count; i++)
    //{
    //    if (rows[i] > columns[i])
    //    {
    //        rowSum += rows[i];
    //        continue;
    //    }
    //    columnSum += columns[i];
    //}
    Console.WriteLine(columnSum + (rowSum * 100));
    Console.WriteLine(sum);
}

