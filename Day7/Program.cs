using System.Text.RegularExpressions;

Console.WriteLine("Day 7");
var camelCardsData = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day7\Input.txt");
var hands = new List<Hand>();
var ranks = new Dictionary<char, int> { { 'A', 13 }, { 'K', 12 }, { 'Q', 11 }, { 'J', 10 }, { 'T', 9 }, { '9', 8 }, { '8', 7 }, { '7', 6 }, { '6', 5 }, { '5', 4 }, { '4', 3 }, { '3', 2 }, { '2', 1 } };

foreach (var camelCard in camelCardsData)
{
    var data = camelCard.Split();

    hands.Add(new Hand
    {
        Bid = int.Parse(data[1]),
        Cards = data[0].Select(x => new Card { Strength = ranks[x], Value = x.ToString() }).ToList()
    });
}

SetHandType();

hands.Sort();
var totalWinnings = 0;
int i = 1;

foreach (var hand in hands)
{
    totalWinnings += (hand.Bid * i);
    i++;
}

Console.WriteLine($"Part1: {totalWinnings}");

ranks = new Dictionary<char, int> { { 'A', 13 }, { 'K', 12 }, { 'Q', 11 }, { 'T', 9 }, { '9', 8 }, { '8', 7 }, { '7', 6 }, { '6', 5 }, { '5', 4 }, { '4', 3 }, { '3', 2 }, { '2', 1 }, { 'J', 0 } };
hands = new List<Hand>();
foreach (var camelCard in camelCardsData)
{
    var data = camelCard.Split();

    hands.Add(new Hand
    {
        Bid = int.Parse(data[1]),
        Cards = data[0].Select(x => new Card { Strength = ranks[x], Value = x.ToString() }).ToList()
    });
}

SetHandType2();

hands.Sort();
totalWinnings = 0;
i = 1;

foreach (var hand in hands)
{
    totalWinnings += (hand.Bid * i);
    i++;
}

Console.WriteLine($"Part2: {totalWinnings}");

void SetHandType()
{
    foreach (var hand in hands)
    {
        var handType = hand.Cards
                    .GroupBy(hand => hand.Value)
                    .Select(hand => new { hand.Key, CardsCount = hand.Count() })
                    .OrderByDescending(x => x.CardsCount).ToList();

        hand.HandType = handType![0].CardsCount switch
        {
            5 => HandType.FiveOfAKind,
            4 => HandType.FourOfAKind,
            3 => handType[1].CardsCount == 2 ? HandType.FullHouse : HandType.ThreeOfAKind,
            2 => handType[1].CardsCount == 2 ? HandType.TwoPair : HandType.OnePair,
            _ => HandType.HighCard,
        };
    }
}

void SetHandType2()
{
    foreach (var hand in hands)
    {
        var handType = hand.Cards
                    .GroupBy(hand => hand.Value)
                    .Select(hand => new { hand.Key, CardsCount = hand.Count() })
                    .OrderByDescending(x => x.CardsCount).ToList();

        hand.HandType = handType![0].CardsCount switch
        {
            5 => HandType.FiveOfAKind,
            4 => handType.Any(x => x.Key == "J") ? HandType.FiveOfAKind : HandType.FourOfAKind,
            3 => GetHandType3(),
            2 => GetHandType2(),
            _ => handType.Any(x => x.Key == "J") ? HandType.OnePair : HandType.HighCard,
        };

        HandType GetHandType3()
        {
            if (handType[1].CardsCount == 2)
            {
                return (handType[0].Key == "J" || handType[1].Key == "J") ? HandType.FiveOfAKind : HandType.FullHouse;
            }
            else
            {
                return (handType.Any(x => x.Key == "J")) ? HandType.FourOfAKind : HandType.ThreeOfAKind;
            }
        };

        HandType GetHandType2()
        {
            if (handType[1].CardsCount == 2)
            {
                if (handType[0].Key == "J" || handType[1].Key == "J")
                {
                    return HandType.FourOfAKind;
                }
                else if (handType[2].Key == "J")
                {
                    return HandType.FullHouse;
                }
                else
                {
                    return HandType.TwoPair;
                }
            }
            else
            {
                if (handType.Any(x => x.Key == "J"))
                {
                    return HandType.ThreeOfAKind;
                }
                else
                {
                    return HandType.OnePair;
                }
            }
        };
    }
}

class Hand : IComparable<Hand>
{
    internal HandType HandType { get; set; }
    internal List<Card> Cards { get; set; }
    internal int Bid { get; set; }

    public int CompareTo(Hand other)
    {
        if (HandType != other.HandType) return HandType - other.HandType;

        for (int i = 0; i < Cards.Count; i++)
        {
            if (Cards[i].Value == other.Cards[i].Value) continue;

            return Cards[i].Strength - other.Cards[i].Strength;
        }

        return 0;
    }
}

struct Card
{
    internal int Strength { get; set; }
    internal string Value { get; set; }
}

enum HandType
{
    HighCard = 0,
    OnePair = 1,
    TwoPair = 2,
    ThreeOfAKind = 3,
    FullHouse = 4,
    FourOfAKind = 5,
    FiveOfAKind = 6
}