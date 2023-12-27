using System.Data;

Console.WriteLine("Day 19");
var input = File.ReadAllLines(@"C:\Learning\Projects\AoC\Day19\Input.txt");
var workflows = new Dictionary<string, Workflow>();
var ratings = new List<Rating>();
long sum = 0;
int i = 0;

do
{
    var workflowText = input[i].Split('{', ',', '}', ':').Where(wf => !string.IsNullOrEmpty(wf)).ToArray();
    var rulesArray = workflowText[1..];
    var rules = new List<Rule>();

    for (long j = 0; j < rulesArray.Length - 1;)
    {
        var ruleText = rulesArray[j];
        rules.Add(new Rule { Name = ruleText[0].ToString(), Condition = ruleText[1] == '<' ? Condition.LesserThan : Condition.GreaterThan, Value = long.Parse(ruleText[2..]), Destination = rulesArray[j + 1] });
        j += 2;
    }
    rules.Add(new Rule { Name = string.Empty, Condition = Condition.None, Value = 0, Destination = rulesArray[rulesArray.Length - 1] });
    workflows.Add(workflowText[0], new Workflow { Name = workflowText[0], Rules = rules });
    i++;
} while (!string.IsNullOrWhiteSpace(input[i]));

i++;

var rawRatings = input[i..].ToArray();
i = 1;

foreach (var rawRating in rawRatings)
{
    //var rating = rawRating.Split('{', '}', '=', ',').Where(r => !string.IsNullOrEmpty(r)).ToArray();
    var ratingPairs = rawRating
        .Split('{', '}', '=', ',')
        .Where(r => !string.IsNullOrEmpty(r))
        .Chunk(2)
        .Select(r => (r.First(), long.Parse(r.Last())))
        .ToDictionary(r => r.Item1, r => r.Item2);
    ratings.Add(new Rating { Id = i, Status = null, Values = ratingPairs });
    i++;
}

var workflow = workflows["in"];
i = 0;
long combinations = 0;

while (i < ratings.Count && !ratings[i].Status.HasValue)
{
    string? destination = null;

    foreach (var rule in workflow.Rules)
    {
        if (!string.IsNullOrWhiteSpace(rule.Name))
        {
            var ratingValue = ratings[i].Values.GetValueOrDefault(rule.Name);
            if (rule.Condition == Condition.LesserThan && ratingValue < rule.Value)
            {
                destination = rule.Destination;
            }
            else if (rule.Condition == Condition.GreaterThan && ratingValue > rule.Value)
            {
                destination = rule.Destination;
            }
        }

        if (!string.IsNullOrEmpty(destination))
        {
            if (destination == "A")
            {
                ratings[i].Status = true;
                workflow = workflows["in"];
                i++;
                break;
            }
            else if (destination == "R")
            {
                ratings[i].Status = false;
                workflow = workflows["in"];
                i++;
                break;
            }
            else
            {
                workflow = workflows[destination];
            }
            break;
        }
    }
    if (string.IsNullOrEmpty(destination))
    {
        destination = workflow.Rules[workflow.Rules.Count - 1].Destination;
        if (destination == "A")
        {
            ratings[i].Status = true;
            workflow = workflows["in"];
            i++;
        }
        else if (destination == "R")
        {
            ratings[i].Status = false;
            workflow = workflows["in"];
            i++;
        }
        else
        {
            workflow = workflows[destination];
        }
    }
}

sum = ratings.Where(r => r.Status.HasValue && r.Status.Value).Select(r => r.Values.Values.Sum()).Sum();
Console.WriteLine($"Part1: {sum}");

workflow = workflows["in"];
foreach (var rating in ratings)
{
    foreach (var rule in workflow.Rules)
    {
        var range = GetAcceptedRules(rule, workflow);
    }
}

object GetAcceptedRules(Rule rule, Workflow workflow)
{
    throw new NotImplementedException();
}

Console.WriteLine($"Part2: {combinations}");


record Workflow
{
    internal string Name;
    internal List<Rule> Rules;
}

record Rule
{
    internal string Name;
    internal Condition Condition;
    internal long Value;
    internal string Destination;
}

record Rating
{
    internal long Id;
    internal Dictionary<string, long> Values;
    internal bool? Status;
}

enum Condition
{
    None,
    LesserThan,
    GreaterThan
}