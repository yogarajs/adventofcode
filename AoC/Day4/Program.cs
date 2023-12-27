Console.WriteLine("Day 4");
var cardData = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day4\Input.txt");
var cards = new Dictionary<int, Card>();

int i = 1;
foreach (var cardDatum in cardData)
{
    var scartchCards = cardDatum.Substring(cardDatum.IndexOf(':') + 1).Split('|');
    var winningNumbers = scartchCards[0].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));
    var scartchCardNumbers = scartchCards[1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));
    var commonNumbers = winningNumbers.Intersect(scartchCardNumbers).Select(int.Parse).ToList();
    var card = new Card
    {
        ID = i,
        InstanceCount = 1,
        Points = (int)Math.Pow(2, commonNumbers.Count - 1),
        WinningCards = Enumerable.Range(i + 1, commonNumbers.Count).ToList(),
    };
    cards.Add(i, card);
    i++;
}

Console.WriteLine($"Part 1: {cards.Sum(x => x.Value.Points)}");

foreach (var card in cards.Values)
{
    ProcessWinningCards(card);
}

Console.WriteLine($"Part 2: {cards.Sum(x => x.Value.InstanceCount)}");

void ProcessWinningCards(Card winningCard)
{
    foreach (var item in winningCard.WinningCards)
    {
        cards[item].InstanceCount += winningCard.InstanceCount;
    }
}

class Card
{
    internal int ID { get; set; }
    internal int InstanceCount { get; set; }
    internal List<int> WinningCards { get; set; }
    internal int Points { get; set; }
}