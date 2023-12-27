//using System.Diagnostics;
//using System.Text;

//Console.WriteLine("Day 1");
//var lines = await File.ReadAllLinesAsync(@"C:\Learning\Projects\AoC\Day1\Input.txt");
//var calibrationValues = new string[lines.Length];
//int sum = 0;

//// Part 1
////foreach (var line in lines)
////{
////    var onlyDigits = line.Where(x => char.IsDigit(x));
////    var calibrationValue = (int)(char.GetNumericValue(onlyDigits.First()) * 10 + char.GetNumericValue(onlyDigits.Last()));
////    sum += calibrationValue;
////}
////Console.WriteLine(sum);

//int i = 0;
//foreach (var line in lines)
//{
//    var tolower = line.ToLower();
//    var lineLength = line.Length;
//    var calibrationValueBuilder = new StringBuilder();

//    for (int j = 0; j < lineLength; j++)
//    {
//        if (char.IsDigit(tolower[j]))
//        {
//            calibrationValueBuilder.Append(tolower[j]);
//        }
//        else
//        {
//            ParseLineAndExtractNumber(tolower, j, calibrationValueBuilder);

//            //if (j + 2 < lineLength && IsOne(tolower, j))
//            //{
//            //    calibrationValues[i] += "1";
//            //}
//            //else if (j + 2 < lineLength && IsTwo(tolower, j))
//            //{
//            //    calibrationValues[i] += "2";
//            //}
//            //else if (j + 4 < lineLength && IsThree(tolower, j))
//            //{
//            //    calibrationValues[i] += "3";
//            //}
//            //else if (j + 3 < lineLength && IsFour(tolower, j))
//            //{
//            //    calibrationValues[i] += "4";
//            //}
//            //else if (j + 3 < lineLength && IsFive(tolower, j))
//            //{
//            //    calibrationValues[i] += "5";
//            //}
//            //else if (j + 2 < lineLength && IsSix(tolower, j))
//            //{
//            //    calibrationValues[i] += "6";
//            //}
//            //else if (j + 4 < lineLength && IsSeven(tolower, j))
//            //{
//            //    calibrationValues[i] += "7";
//            //}
//            //else if (j + 4 < lineLength && IsEight(tolower, j))
//            //{
//            //    calibrationValues[i] += "8";
//            //}
//            //else if (j + 3 < lineLength && IsNine(tolower, j))
//            //{
//            //    calibrationValues[i] += "9";
//            //}
//        }
//    }
//    var calibrationValueString = calibrationValueBuilder.ToString();
//    calibrationValues[i] = calibrationValueString;
//    var calibrationValue = (int)(char.GetNumericValue(calibrationValueString.First()) * 10 + char.GetNumericValue(calibrationValueString.Last()));
//    sum += calibrationValue;
//    i++;
//}

//void ParseLineAndExtractNumber(string line, int index, StringBuilder calibrationValue)
//{
//    var numbers = new Dictionary<string, string> { { "one", "1" }, { "two", "2" }, { "three", "3" }, { "four", "4" }, { "five", "5" }, { "six", "6" }, { "seven", "7" }, { "eight", "8" }, { "nine", "9" } };

//    foreach (var number in numbers.Keys)
//    {
//        if ((index + number.Length) - 1 < line.Length && line.Substring(index, number.Length).Equals(number))
//        {
//            calibrationValue.Append(numbers[number]);
//        }
//    }
//}

//Console.WriteLine(sum);
////var stopwatch = Stopwatch.StartNew();
////Console.WriteLine(stopwatch.Elapsed);
////sum = 0;
////foreach (var calibration in calibrationValues)
////{
////    var calibrationValue = (int)(char.GetNumericValue(calibration.First()) * 10 + char.GetNumericValue(calibration.Last()));
////    sum += calibrationValue;
////}
////Console.WriteLine(sum);


////bool IsOne(string line, int index)
////{
////    return line[index] == 'o' && line[index + 1] == 'n' && line[index + 2] == 'e';
////}

////bool IsTwo(string line, int index)
////{
////    return line[index] == 't' && line[index + 1] == 'w' && line[index + 2] == 'o';
////}

////bool IsThree(string line, int index)
////{
////    return line[index] == 't' && line[index + 1] == 'h' && line[index + 2] == 'r' && line[index + 3] == 'e' && line[index + 4] == 'e';
////}

////bool IsFour(string line, int index)
////{
////    return line[index] == 'f' && line[index + 1] == 'o' && line[index + 2] == 'u' && line[index + 3] == 'r';
////}

////bool IsFive(string line, int index)
////{
////    return line[index] == 'f' && line[index + 1] == 'i' && line[index + 2] == 'v' && line[index + 3] == 'e';
////}

////bool IsSix(string line, int index)
////{
////    return line[index] == 's' && line[index + 1] == 'i' && line[index + 2] == 'x';
////}

////bool IsSeven(string line, int index)
////{
////    return line[index] == 's' && line[index + 1] == 'e' && line[index + 2] == 'v' && line[index + 3] == 'e' && line[index + 4] == 'n';
////}

////bool IsEight(string line, int index)
////{
////    return line[index] == 'e' && line[index + 1] == 'i' && line[index + 2] == 'g' && line[index + 3] == 'h' && line[index + 4] == 't';
////}

////bool IsNine(string line, int index)
////{
////    return line[index] == 'n' && line[index + 1] == 'i' && line[index + 2] == 'n' && line[index + 3] == 'e';
////}