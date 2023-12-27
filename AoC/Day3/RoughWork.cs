//Console.WriteLine("Day 3");
//var engineSchematics = await File.ReadAllLinesAsync(@"C:\Learning\Projects\AoC\Day3\Input.txt");
//var engineSchematicArray = engineSchematics.Select(item => item.ToArray()).ToArray();
//var numbers = new List<int>();

//for (int i = 0; i < engineSchematicArray.Length; i++)
//{
//    var number = 0;
//    var adjacentCellsCounter = 0;
//    var isPartNumber = false;

//    for (int j = 0; j < engineSchematicArray[i].Length; j++)
//    {
//        if (char.IsDigit(engineSchematicArray[i][j]))
//        {
//            number = number * 10 + (int)char.GetNumericValue(engineSchematicArray[i][j]);
//            adjacentCellsCounter++;
//        }
//        else if (engineSchematicArray[i][j] != '.')
//        {
//            if (number > 0)
//            {
//                numbers.Add(number);
//                number = 0;
//                adjacentCellsCounter = 0;
//                isPartNumber = false;
//            }
//        }
//        else if (engineSchematicArray[i][j] == '.')
//        {
//            // prefix scenario
//            if (j - adjacentCellsCounter - 1 >= 0 && engineSchematicArray[i][j - adjacentCellsCounter - 1] != '.')
//            {
//                isPartNumber = true;
//            }
//            else
//            {
//                for (int k = 0; k < adjacentCellsCounter + 2; k++)
//                {
//                    // next line
//                    var columnLimit = j - k;
//                    var rowLimit = i + 1;
//                    if (rowLimit < engineSchematicArray.Length && columnLimit >= 0 && engineSchematicArray[rowLimit][j - k] != '.' && !char.IsDigit(engineSchematicArray[rowLimit][j - k]))
//                    {
//                        isPartNumber = true;
//                        break;
//                    }
//                }

//                for (int k = 0; k < adjacentCellsCounter + 2; k++)
//                {
//                    // previous line
//                    var columnLimit = j - k;
//                    var rowLimit = i - 1;
//                    if (rowLimit >= 0 && columnLimit >= 0 && engineSchematicArray[rowLimit][j - k] != '.' && !char.IsDigit(engineSchematicArray[rowLimit][j - k]))
//                    {
//                        isPartNumber = true;
//                        break;
//                    }
//                }
//            }
//            if (isPartNumber && number > 0)
//            {
//                numbers.Add(number);
//            }
//            number = 0;
//            adjacentCellsCounter = 0;
//            isPartNumber = false;
//        }

//        // edge case
//        if (number > 0 && j + 1 == engineSchematicArray[i].Length)
//        {
//            // prefix scenario
//            if (j - adjacentCellsCounter >= 0 && engineSchematicArray[i][j - adjacentCellsCounter] != '.')
//            {
//                isPartNumber = true;
//            }
//            else
//            {
//                for (int k = 0; k < adjacentCellsCounter + 2; k++)
//                {
//                    // next line
//                    var columnLimit = j - k;
//                    var rowLimit = i + 1;
//                    if (rowLimit < engineSchematicArray.Length && columnLimit >= 0 && engineSchematicArray[rowLimit][j - k] != '.' && !char.IsDigit(engineSchematicArray[rowLimit][j - k]))
//                    {
//                        isPartNumber = true;
//                        break;
//                    }
//                }

//                for (int k = 0; k < adjacentCellsCounter + 2; k++)
//                {
//                    // previous line
//                    var columnLimit = j - k;
//                    var rowLimit = i - 1;
//                    if (rowLimit >= 0 && columnLimit >= 0 && engineSchematicArray[rowLimit][j - k] != '.' && !char.IsDigit(engineSchematicArray[rowLimit][j - k]))
//                    {
//                        isPartNumber = true;
//                        break;
//                    }
//                }
//            }
//            if (isPartNumber && number > 0)
//            {
//                numbers.Add(number);
//            }
//            number = 0;
//            adjacentCellsCounter = 0;
//            isPartNumber = false;
//        }
//    }
//}

//Console.WriteLine(numbers.Sum());