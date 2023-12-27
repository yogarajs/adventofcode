//using System.Collections.Generic;

//Console.WriteLine("Day 7");
//var camelCardsData = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day7\Input.txt");
//var hands = new List<Hand>();

//foreach (var camelCard in camelCardsData)
//{
//    var data = camelCard.Split(' ');

//    hands.Add(new Hand
//    {
//        Bid = int.Parse(data[1]),
//        Cards = data[0].Select(c => c.ToString()).ToList()
//    });
//}

//CalculateOrder();

//void CalculateOrder()
//{
//    foreach (var hand in hands)
//    {
//        var orders = from card in hand.Cards
//                     group card by card into g
//                     select new { g, count = g.Count() };

//        var ordersCount = orders.Where(x => x.count == 5);
//        if (ordersCount.Count() == 1)
//        {
//            hand.HandType = HandType.FiveOfAKind;
//        }
//        ordersCount = orders.Where(x => x.count == 4);
//        if (ordersCount.Count() == 1)
//        {
//            hand.HandType = HandType.FourOfAKind;
//        }
//        ordersCount = orders.Where(x => x.count == 3);
//        if (ordersCount.Count() == 1)
//        {
//            ordersCount = orders.Where(x => x.count == 2);
//            if (ordersCount.Count() == 1)
//                hand.HandType = HandType.FullHouse;
//            else
//                hand.HandType = HandType.ThreeOfAKind;
//        }
//        ordersCount = orders.Where(x => x.count == 2);
//        if (ordersCount.Count() == 2)
//        {
//            hand.HandType = HandType.TwoPair;
//        }
//        ordersCount = orders.Where(x => x.count == 2);
//        if (ordersCount.Count() == 1)
//        {
//            hand.HandType = HandType.OnePair;
//        }
//    }
//}

//hands = hands.OrderBy(x => x.HandType).ToList();
//var ranks = new char[] { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

////ranks.OrderBy(r => r).ToList().ForEach(i => Console.Write("{0}", i));

//Console.WriteLine();
//foreach (var hand in hands)
//{
//    Console.WriteLine($"{hand.Cards[0] + hand.Cards[1] + hand.Cards[2] + hand.Cards[3] + hand.Cards[4]} {hand.HandType}");
//}

//hands = hands.OrderBy(x => x.HandType).ThenBy(x => x.Cards).ToList();
//foreach (var hand in hands)
//{
//    Console.WriteLine($"{hand.Cards[0] + hand.Cards[1] + hand.Cards[2] + hand.Cards[3] + hand.Cards[4]} {hand.HandType}");
//}

//var totalWinnings = 0;
//Console.WriteLine($"Part1: {totalWinnings}");

//class Hand
//{
//    internal HandType HandType { get; set; }
//    internal List<string> Cards { get; set; }
//    internal int Bid { get; set; }
//}

//class Card
//{
//    internal int HandType { get; set; }
//}

//enum HandType
//{
//    HighCard = 0,
//    OnePair = 1,
//    TwoPair = 2,
//    ThreeOfAKind = 3,
//    FullHouse = 4,
//    FourOfAKind = 5,
//    FiveOfAKind = 6
//}



//using System.Text.RegularExpressions;

//Console.WriteLine("Day 7");
//var camelCardsData = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day7\Input.txt");
//var hands = new List<Hand>();
//var ranks = new Dictionary<char, int> { { 'A', 13 }, { 'K', 12 }, { 'Q', 11 }, { 'J', 10 }, { 'T', 9 }, { '9', 8 }, { '8', 7 }, { '7', 6 }, { '6', 5 }, { '5', 4 }, { '4', 3 }, { '3', 2 }, { '2', 1 } };

//foreach (var camelCard in camelCardsData)
//{
//    var data = camelCard.Split();

//    hands.Add(new Hand
//    {
//        Bid = int.Parse(data[1]),
//        Cards = data[0].Select(x => new Card { Strength = ranks[x], Value = x.ToString() }).ToList()
//    });
//}

//SetHandType();

//void SetHandType()
//{
//    foreach (var hand in hands)
//    {
//        var handType = hand.Cards
//                    .GroupBy(hand => hand.Value)
//                    .Select(hand => new { hand.Key, CardsCount = hand.Count() })
//                    .OrderByDescending(x => x.CardsCount).ToList();

//        hand.HandType = handType![0].CardsCount switch
//        {
//            5 => HandType.FiveOfAKind,
//            4 => HandType.FourOfAKind,
//            3 => handType[1].CardsCount == 2 ? HandType.FullHouse : HandType.ThreeOfAKind,
//            2 => handType[1].CardsCount == 2 ? HandType.TwoPair : HandType.OnePair,
//            _ => HandType.HighCard,
//        };
//    }
//}

////void SetHandType2()
////{
////    foreach (var hand in hands)
////    {
////        var handType = hand.Cards
////                    .GroupBy(hand => hand.Value)
////                    .Select(hand => new { hand.Key, CardsCount = hand.Count() })
////                    .OrderByDescending(x => x.CardsCount).ToList();

////        hand.HandType = handType![0].CardsCount switch
////        {
////            5 => HandType.FiveOfAKind,
////            4 => handType.Any(x => x.Key == "J") ? HandType.FiveOfAKind : HandType.FourOfAKind,
////            3 => GetHandType3(),
////            2 => GetHandType2(),
////            handType[1].CardsCount == 2 ? HandType.TwoPair : HandType.OnePair,
////            _ => HandType.HighCard,
////        };

////        HandType GetHandType3()
////        {
////            if (handType[1].CardsCount == 2)
////            {
////                if (groups[0].Card == 'J' || groups[1].Card == 'J') { hand.HandType = HandType.FiveOfAKind; break; }
////                else { hand.HandType = HandType.FullHouse; break; }
////            }
////            else
////            {
////                if (groups.Any(x => x.Card == 'J')) { hand.HandType = HandType.FourOfAKind; break; }
////                else { hand.HandType = HandType.ThreeOfAKind; break; }
////            }
////        }
////     ? handType.Any(x => x.Key == "J" && x.CardsCount == 2) ? HandType.FullHouse : HandType.ThreeOfAKind,
////};

////    switch (groups[0].Count)
////    {
////        case 5: hand.HandType = HandType.FiveOfAKind; break;
////        case 4: hand.HandType = handType.Any(x => x.Key == "J") ? HandType.FiveOfAKind : HandType.FourOfAKind; break;
////        case 3:
////            if (groups[1].Count == 2)
////            {
////                if (groups[0].Card == 'J' || groups[1].Card == 'J') { hand.HandType = HandType.FiveOfAKind; break; }
////                else { hand.HandType = HandType.FullHouse; break; }
////            }
////            else
////            {
////                if (groups.Any(x => x.Card == 'J')) { hand.HandType = HandType.FourOfAKind; break; }
////                else { hand.HandType = HandType.ThreeOfAKind; break; }
////            }
////        case 2:
////            if (groups[1].Count == 2)
////            {
////                if (groups[0].Card == 'J' || groups[1].Card == 'J') { hand.HandType = HandType.FourOfAKind; break; }
////                else if (groups[2].Card == 'J') { hand.HandType = HandType.FullHouse; break; }
////                else { hand.HandType = HandType.TwoPair; break; }
////            }
////            else
////            {
////                if (groups.Any(x => x.Card == 'J')) { hand.HandType = HandType.ThreeOfAKind; break; }
////                else { hand.HandType = HandType.OnePair; break; }
////            }
////        default:
////            hand.HandType = groups.Any(x => x.Card == 'J') ? HandType.OnePair : HandType.HighCard;
////            break;
////    }
////}
////}

//HandType GetHandType2()
//{
//    throw new NotImplementedException();
//}

//hands.Sort();
//var totalWinnings = 0;
//int i = 1;

//foreach (var hand in hands)
//{
//    totalWinnings += (hand.Bid * i);
//    i++;
//}

//Console.WriteLine($"Part1: {totalWinnings}");

//class Hand : IComparable<Hand>
//{
//    internal HandType HandType { get; set; }
//    internal List<Card> Cards { get; set; }
//    internal int Bid { get; set; }

//    public int CompareTo(Hand other)
//    {
//        if (HandType != other.HandType) return HandType - other.HandType;

//        for (int i = 0; i < Cards.Count; i++)
//        {
//            if (Cards[i].Value == other.Cards[i].Value) continue;

//            return Cards[i].Strength - other.Cards[i].Strength;
//        }

//        return 0;
//    }
//}

//struct Card
//{
//    internal int Strength { get; set; }
//    internal string Value { get; set; }
//}

//enum HandType
//{
//    HighCard = 0,
//    OnePair = 1,
//    TwoPair = 2,
//    ThreeOfAKind = 3,
//    FullHouse = 4,
//    FourOfAKind = 5,
//    FiveOfAKind = 6
//}

////var day07 = new Day07();
////Console.WriteLine(day07.SolvePartOne());
////Console.WriteLine(day07.SolvePartTwo());

////class Day07
////{
////    List<Part1Hand> hands = new();
////    List<Part2Hand> twoHands = new();

////    public Day07()
////    {
////        foreach (var h in File.ReadAllLines(@"C:\Learning\Projects\AoC\Day7\Input.txt"))
////        {
////            var h2 = h.Split();
////            hands.Add(new(h2[0], long.Parse(h2[1])));
////            twoHands.Add(new(h2[0], long.Parse(h2[1])));
////        }
////    }

////    public object SolvePartOne()
////    {
////        List<Part1Hand> p1Hands = new(hands);

////        p1Hands.Sort();

////        long total = 0;

////        for (int i = 0; i < p1Hands.Count; i++)
////        {
////            total += (i + 1) * p1Hands[i].bid;
////        }
////        return total;
////    }

////    public object SolvePartTwo()
////    {
////        List<Part2Hand> p2Hands = new(twoHands);

////        p2Hands.Sort();

////        long total = 0;

////        for (int i = 0; i < p2Hands.Count; i++)
////        {
////            total += (i + 1) * p2Hands[i].bid;
////        }
////        return total;
////    }

////    private class Part1Hand : IComparable<Part1Hand>
////    {
////        public string cards;
////        public long bid;
////        public HandType HandType;

////        public Part1Hand(string cards, long bid)
////        {
////            cards = cards;
////            bid = bid;
////            //var groups = cards.GroupBy(x => x).Select(group => new { Card = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).ToList();


////            //switch (groups[0].Count)
////            //{
////            //    case 5: HandType = HandType.FiveMatch; break;
////            //    case 4: HandType = HandType.FourOfAKind; break;
////            //    case 3: HandType = groups[1].Count == 2 ? HandType.FullHouse : HandType.ThreeOfAKind; break;
////            //    case 2: HandType = groups[1].Count == 2 ? HandType.TwoPair : HandType.OnePair; break;
////            //    default: HandType = HandType.HighCard; break;
////            //}

////            var handType = cards
////                               .GroupBy(hand => hand)
////                               .Select(hand => new { hand.Key, CardsCount = hand.Count() })
////                               .GroupBy(hand => hand.CardsCount)
////                               .Select(hand => new { hand.Key, Count = hand.Count() })
////                               .MaxBy(x => x.Key);

////            switch (handType.Key)
////            {
////                case 5: HandType = HandType.FiveMatch; break;
////                case 4: HandType = HandType.FourOfAKind; break;
////                case 3: HandType = handType.Count == 2 ? HandType.FullHouse : HandType.ThreeOfAKind; break;
////                case 2: HandType = handType.Count == 2 ? HandType.TwoPair : HandType.OnePair; break;
////                default: HandType = HandType.HighCard; break;
////            }

////        }

////        public int CompareTo(Part1Hand other)
////        {
////            if (HandType != other.HandType) return HandType - other.HandType;
////            for (int i = 0; i < cards.Length; i++)
////            {
////                if (cards[i] == other.cards[i]) continue;
////                switch (cards[i])
////                {
////                    case 'A': return 1;
////                    case 'K': return other.cards[i] == 'A' ? -1 : 1;
////                    case 'Q': return "AK".Contains(other.cards[i]) ? -1 : 1;
////                    case 'J': return "AKQ".Contains(other.cards[i]) ? -1 : 1;
////                    case 'T': return "AKQJ".Contains(other.cards[i]) ? -1 : 1;
////                    case '9': return "AKQJT".Contains(other.cards[i]) ? -1 : 1;
////                    case '8': return "AKQJT9".Contains(other.cards[i]) ? -1 : 1;
////                    case '7': return "AKQJT98".Contains(other.cards[i]) ? -1 : 1;
////                    case '6': return "AKQJT987".Contains(other.cards[i]) ? -1 : 1;
////                    case '5': return "AKQJT9876".Contains(other.cards[i]) ? -1 : 1;
////                    case '4': return "AKQJT98765".Contains(other.cards[i]) ? -1 : 1;
////                    case '3': return "AKQJT987654".Contains(other.cards[i]) ? -1 : 1;
////                    case '2': return -1;
////                }
////            }

////            return 0;
////        }
////    }

////    private class Part2Hand : IComparable<Part2Hand>
////    {
////        public string cards;
////        public long bid;
////        public HandType HandType;

////        public Part2Hand(string cards, long bid)
////        {
////            cards = cards;
////            bid = bid;
////            var groups = cards.GroupBy(x => x).Select(group => new { Card = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).ToList();


////            switch (groups[0].Count)
////            {
////                case 5: HandType = HandType.FiveMatch; break;
////                case 4: HandType = groups.Any(x => x.Card == 'J') ? HandType.FiveMatch : HandType.FourOfAKind; break;
////                case 3:
////                    if (groups[1].Count == 2)
////                    {
////                        if (groups[0].Card == 'J' || groups[1].Card == 'J') { HandType = HandType.FiveMatch; break; }
////                        else { HandType = HandType.FullHouse; break; }
////                    }
////                    else
////                    {
////                        if (groups.Any(x => x.Card == 'J')) { HandType = HandType.FourOfAKind; break; }
////                        else { HandType = HandType.ThreeOfAKind; break; }
////                    }
////                case 2:
////                    if (groups[1].Count == 2)
////                    {
////                        if (groups[0].Card == 'J' || groups[1].Card == 'J') { HandType = HandType.FourOfAKind; break; }
////                        else if (groups[2].Card == 'J') { HandType = HandType.FullHouse; break; }
////                        else { HandType = HandType.TwoPair; break; }
////                    }
////                    else
////                    {
////                        if (groups.Any(x => x.Card == 'J')) { HandType = HandType.ThreeOfAKind; break; }
////                        else { HandType = HandType.OnePair; break; }
////                    }
////                default:
////                    HandType = groups.Any(x => x.Card == 'J') ? HandType.OnePair : HandType.HighCard;
////                    break;
////            }

////        }

////        public int CompareTo(Part2Hand other)
////        {
////            if (HandType != other.HandType) return HandType - other.HandType;
////            for (int i = 0; i < cards.Length; i++)
////            {
////                if (cards[i] == other.cards[i]) continue;
////                switch (cards[i])
////                {
////                    case 'A': return 1;
////                    case 'K': return other.cards[i] == 'A' ? -1 : 1;
////                    case 'Q': return "AK".Contains(other.cards[i]) ? -1 : 1;
////                    case 'T': return "AKQ".Contains(other.cards[i]) ? -1 : 1;
////                    case '9': return "AKQT".Contains(other.cards[i]) ? -1 : 1;
////                    case '8': return "AKQT9".Contains(other.cards[i]) ? -1 : 1;
////                    case '7': return "AKQT98".Contains(other.cards[i]) ? -1 : 1;
////                    case '6': return "AKQT987".Contains(other.cards[i]) ? -1 : 1;
////                    case '5': return "AKQT9876".Contains(other.cards[i]) ? -1 : 1;
////                    case '4': return "AKQT98765".Contains(other.cards[i]) ? -1 : 1;
////                    case '3': return "AKQT987654".Contains(other.cards[i]) ? -1 : 1;
////                    case '2': return "AKQT9876543".Contains(other.cards[i]) ? -1 : 1;
////                    case 'J': return -1;
////                }
////            }

////            return 0;
////        }
////    }

////    private enum HandType
////    {
////        HighCard = 1,
////        OnePair = 2,
////        TwoPair = 3,
////        ThreeOfAKind = 4,
////        FullHouse = 5,
////        FourOfAKind = 6,
////        FiveMatch = 7
////    }
////}


