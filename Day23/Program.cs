Console.WriteLine("Day 23");
var map = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day23\Input.txt").Select(l => l.ToCharArray()).ToArray();
var mapVisited = new bool[map.Length, map[0].Length];
var startPosition = Enumerable.Range(0, map[0].Length).Where(m => map[0][m] == '.').Select(m => (x: 0, y: m)).Single();
var endPosition = Enumerable.Range(0, map.Length - 1).Where(m => map[map.Length - 1][m] == '.').Select(m => (x: map.Length - 1, y: m)).Single();
var paths = new Dictionary<int, List<(int x, int y)>>();
paths.Add(1, new List<(int x, int y)> { startPosition });
mapVisited[startPosition.x, startPosition.y] = true;

for (int i = 1; i <= paths.Count; i++)
{
    do
    {
        //var previousLastIndex = paths[i].Count - 1;
        var nextPossiblePositions = GetPossiblePaths(paths[i].Last(), i).ToList();
        if (nextPossiblePositions.Count == 0)
        {
            break;
        }
        else if (nextPossiblePositions.Count == 1)
        {
            paths[i].Add(nextPossiblePositions.First());
        }
        else
        {
            for (int j = 1; j < nextPossiblePositions.Count; j++)
            {
                var newPath = new List<(int, int)>(); ;
                newPath.AddRange(paths[i]);
                newPath.Add(nextPossiblePositions[j]);
                paths.Add(paths.Count + 1, newPath);
            }
            paths[i].Add(nextPossiblePositions.First());
        }
    } while (!(paths[i].Last().x == endPosition.x && paths[i].Last().y == endPosition.y));
}

(int, int)[] GetPossiblePaths((int x, int y) position, int i)
{
    var possiblePaths = new List<(int, int)>();
    var right = (position.x, position.y + 1);
    var left = (position.x, position.y - 1);
    var top = (position.x - 1, position.y);
    var bottom = (position.x + 1, position.y);

    if ((map[position.x][position.y] == '.' || map[position.x][position.y] == '>')
        && right.Item2 < map[0].Length && (map[right.x][right.Item2] == '.' || map[right.x][right.Item2] == '>'))
    {
        if (!mapVisited[right.x, right.Item2])
        {
            possiblePaths.Add((right.x, right.Item2));
            mapVisited[right.x, right.Item2] = true;
        }
        else
        {
            var alreadyVisitedCompletedPaths = paths.Where(p => p.Value.Last().x == endPosition.x && p.Value.Last().y == endPosition.y && p.Value.Contains((right.x, right.Item2))).FirstOrDefault().Value?.ToList();
            if (alreadyVisitedCompletedPaths != null)
            {
                var index = alreadyVisitedCompletedPaths.IndexOf((right.x, right.Item2));
                paths[i].AddRange(alreadyVisitedCompletedPaths.Skip(index).ToList());
            }
        }
    }
    if ((map[position.x][position.y] == '.' || map[position.x][position.y] == '<')
        && left.Item2 >= 0 && (map[left.x][left.Item2] == '.' || map[left.x][left.Item2] == '<'))
    {
        if (!mapVisited[left.x, left.Item2])
        {
            possiblePaths.Add((left.x, left.Item2));
            mapVisited[left.x, left.Item2] = true;
        }
        else
        {
            var alreadyVisitedCompletedPaths = paths.Where(p => p.Value.Last().x == endPosition.x && p.Value.Last().y == endPosition.y && p.Value.Contains((left.x, left.Item2))).FirstOrDefault().Value?.ToList();
            if (alreadyVisitedCompletedPaths != null)
            {
                var index = alreadyVisitedCompletedPaths.IndexOf((left.x, left.Item2));
                paths[i].AddRange(alreadyVisitedCompletedPaths.Skip(index).ToList());
            }
        }
    }
    if ((map[position.x][position.y] == '.' || map[position.x][position.y] == 'v')
        && bottom.Item1 < map.Length && (map[bottom.Item1][bottom.y] == '.' || map[bottom.Item1][bottom.y] == 'v'))
    {
        if (!mapVisited[bottom.Item1, bottom.y])
        {
            possiblePaths.Add((bottom.Item1, bottom.y));
            mapVisited[bottom.Item1, bottom.y] = true;
        }
        else
        {
            var alreadyVisitedCompletedPaths = paths.Where(p => p.Value.Last().x == endPosition.x && p.Value.Last().y == endPosition.y && p.Value.Contains((bottom.Item1, bottom.y))).FirstOrDefault().Value?.ToList();
            if (alreadyVisitedCompletedPaths != null)
            {
                var index = alreadyVisitedCompletedPaths.IndexOf((bottom.Item1, bottom.y));
                paths[i].AddRange(alreadyVisitedCompletedPaths.Skip(index).ToList());
            }
        }
    }
    if ((map[position.x][position.y] == '.' || map[position.x][position.y] == '^')
        && top.Item1 >= 0 && (map[top.Item1][top.y] == '.' || map[top.Item1][top.y] == '^'))
    {
        if (!mapVisited[top.Item1, top.y])
        {
            possiblePaths.Add((top.Item1, top.y));
            mapVisited[top.Item1, top.y] = true;
        }
        else
        {
            var alreadyVisitedCompletedPaths = paths.Where(p => p.Value.Last().x == endPosition.x && p.Value.Last().y == endPosition.y && p.Value.Contains((top.Item1, top.y))).FirstOrDefault().Value?.ToList();
            if (alreadyVisitedCompletedPaths != null)
            {
                var index = alreadyVisitedCompletedPaths.IndexOf((top.Item1, top.y));
                paths[i].AddRange(alreadyVisitedCompletedPaths.Skip(index).ToList());
            }
        }
    }
    return possiblePaths.ToArray();
}

(int, int)[] GetPossiblePaths2((int x, int y) position, int i)
{
    var possiblePaths = new List<(int, int)>();
    var right = (position.x, position.y + 1);
    var left = (position.x, position.y - 1);
    var top = (position.x - 1, position.y);
    var bottom = (position.x + 1, position.y);

    if (right.Item2 < map[0].Length && (map[right.x][right.Item2] != '#')
        )
    {
        if (!mapVisited[right.x, right.Item2])
        {
            possiblePaths.Add((right.x, right.Item2));
            mapVisited[right.x, right.Item2] = true;
        }
        else
        {
            var alreadyVisitedCompletedPaths = paths.Where(p => p.Value.Contains((endPosition.x, endPosition.y)) && p.Value.Contains((right.x, right.Item2)))?.ToList();
            if (alreadyVisitedCompletedPaths.Any())
            {
                //if (alreadyVisitedCompletedPaths.Count > 0)
                //{
                //    Console.WriteLine("=================================");
                //    alreadyVisitedCompletedPaths.ForEach(p =>
                //    {
                //        Console.WriteLine($"{p.Key} {p.Value.Count}");
                //    });
                //    Console.WriteLine("=================================");
                //}
                var alreadyVisitedCompletedPath = alreadyVisitedCompletedPaths.OrderByDescending(p => p.Value.Count).FirstOrDefault();
                var index = alreadyVisitedCompletedPath.Value.IndexOf((right.x, right.Item2));
                if (!(paths[i].Contains((endPosition.x, endPosition.y))))
                {
                    paths[i].AddRange(alreadyVisitedCompletedPath.Value.Skip(index).ToList());
                }
            }
        }
    }
    if (left.Item2 >= 0 && (map[left.x][left.Item2] != '#')
        )
    {
        if (!mapVisited[left.x, left.Item2])
        {
            possiblePaths.Add((left.x, left.Item2));
            mapVisited[left.x, left.Item2] = true;
        }
        else
        {
            var alreadyVisitedCompletedPaths = paths.Where(p => p.Value.Contains((endPosition.x, endPosition.y)) && p.Value.Contains((left.x, left.Item2)))?.ToList();
            if (alreadyVisitedCompletedPaths.Any())
            {
                //if (alreadyVisitedCompletedPaths.Count > 0)
                //{
                //    Console.WriteLine("=================================");
                //    alreadyVisitedCompletedPaths.ForEach(p =>
                //    {
                //        Console.WriteLine($"{p.Key} {p.Value.Count}");
                //    });
                //    Console.WriteLine("=================================");
                //}
                var alreadyVisitedCompletedPath = alreadyVisitedCompletedPaths.OrderByDescending(p => p.Value.Count).FirstOrDefault();
                var index = alreadyVisitedCompletedPath.Value.IndexOf((left.x, left.Item2));
                if (!(paths[i].Contains((endPosition.x, endPosition.y))))
                {
                    paths[i].AddRange(alreadyVisitedCompletedPath.Value.Skip(index).ToList());
                }
            }
        }
    }
    if (bottom.Item1 < map.Length && (map[bottom.Item1][bottom.y] != '#')
        )
    {
        if (!mapVisited[bottom.Item1, bottom.y])
        {
            possiblePaths.Add((bottom.Item1, bottom.y));
            mapVisited[bottom.Item1, bottom.y] = true;
        }
        else
        {
            var alreadyVisitedCompletedPaths = paths.Where(p => p.Value.Contains((endPosition.x, endPosition.y)) && p.Value.Contains((bottom.Item1, bottom.y)))?.ToList();
            if (alreadyVisitedCompletedPaths.Any())
            {
                //if (alreadyVisitedCompletedPaths.Count > 0)
                //{
                //    Console.WriteLine("=================================");
                //    alreadyVisitedCompletedPaths.ForEach(p =>
                //    {
                //        Console.WriteLine($"{p.Key} {p.Value.Count}");
                //    });
                //    Console.WriteLine("=================================");
                //}
                var alreadyVisitedCompletedPath = alreadyVisitedCompletedPaths.OrderByDescending(p => p.Value.Count).FirstOrDefault();
                var index = alreadyVisitedCompletedPath.Value.IndexOf((bottom.Item1, bottom.y));
                if (!(paths[i].Contains((endPosition.x, endPosition.y))))
                {
                    paths[i].AddRange(alreadyVisitedCompletedPath.Value.Skip(index).ToList());
                }
            }
        }
    }
    if (top.Item1 >= 0 && (map[top.Item1][top.y] != '#')
        )
    {
        if (!mapVisited[top.Item1, top.y])
        {
            possiblePaths.Add((top.Item1, top.y));
            mapVisited[top.Item1, top.y] = true;
        }
        else
        {
            var alreadyVisitedCompletedPaths = paths.Where(p => p.Value.Contains((endPosition.x, endPosition.y)) && p.Value.Contains((top.Item1, top.y)))?.ToList();
            if (alreadyVisitedCompletedPaths.Any())
            {
                //if (alreadyVisitedCompletedPaths.Count > 0)
                //{
                //    Console.WriteLine("=================================");
                //    alreadyVisitedCompletedPaths.ForEach(p =>
                //    {
                //        Console.WriteLine($"{p.Key} {p.Value.Count}");
                //    });
                //    Console.WriteLine("=================================");
                //}
                var alreadyVisitedCompletedPath = alreadyVisitedCompletedPaths.OrderByDescending(p => p.Value.Count).FirstOrDefault();
                var index = alreadyVisitedCompletedPath.Value.IndexOf((top.Item1, top.y));
                if (!(paths[i].Contains((endPosition.x, endPosition.y))))
                {
                    paths[i].AddRange(alreadyVisitedCompletedPath.Value.Skip(index).ToList());
                }
            }
        }
    }
    return possiblePaths.ToArray();
}

//paths.ToList().ForEach(p =>
//{
//    int slopesCount = 0;
//    Console.WriteLine($"{p.Key}, {p.Value.Count}");
//    Console.WriteLine("---------------------------------");
//    p.Value.ForEach((position) =>
//    {
//        //if (map[position.x][position.y] != '.')
//        //{
//        //    slopesCount++;
//        //}
//        Console.WriteLine($"{position.x}, {position.y}");
//    });
//    //Console.WriteLine(slopesCount);
//    Console.WriteLine("---------------------------------");
//});

paths = paths.Where(p => p.Value.Last().x == endPosition.x && p.Value.Last().y == endPosition.y).ToDictionary(p => p.Key, p => p.Value);
var longestPath = paths.Max(p => p.Value.Count);

Console.WriteLine($"Part1: {longestPath - 1}");

//var longestPath2 = paths.Where(p => p.Value.Count == longestPath).ToDictionary(p => p.Key, p => p.Value).First();

//Console.WriteLine(longestPath2.Key);
//foreach (var position in longestPath2.Value)
//{
//    map[position.x][position.y] = 'O';
//}

//for (int i = 0; i < map.Length; i++)
//{
//    for (int j = 0; j < map[0].Length; j++)
//    {
//        Console.Write(map[i][j]);
//    }
//    Console.WriteLine();
//}
