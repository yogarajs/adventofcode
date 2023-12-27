//Console.WriteLine("Day 4");
//var cardData = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day4\Input.txt");
//var cards = new List<Card>();

//foreach (var cardDatum in cardData)
//{
//    var scartchCards = cardDatum.Substring(cardDatum.IndexOf(':') + 1).Split('|');
//    var winningNumbers = scartchCards[0].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));
//    var scartchCardNumbers = scartchCards[1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));
//    var commonNumbers = winningNumbers.Intersect(scartchCardNumbers).Select(int.Parse).ToList();
//    var card = new Card
//    {
//        WinningNumbers = commonNumbers,
//        Points = (int)Math.Pow(2, commonNumbers.Count - 1)
//    };
//    cards.Add(card);
//}

//Console.WriteLine($"Part 1: {cards.Sum(x => x.Points)}");


//struct Card
//{
//    internal List<int> WinningNumbers { get; set; }
//    internal int Points { get; set; }
//}

//foreach (var card in cards2)
//{
//    ProcessWinningCards2(card);
//}

//void ProcessWinningCards2(Card winningCard)
//{
//    for (var instanceCount = 1; instanceCount <= winningCard.InstanceCount; instanceCount++)
//    {
//        foreach (var item in winningCard.WinningCards)
//        {
//            cards2.Where(x => x.ID == item).First().InstanceCount++;
//        }
//    }
//}