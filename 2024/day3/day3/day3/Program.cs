// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

string input = File.ReadAllText("input.txt");

string pattern = @"mul\([0-9]{1,3}\,[0-9]{1,3}\)";
var matches = Regex.Matches(input, pattern);

int finalValue = 0;
foreach (Match match in matches)
{
    string stringMatch = match.ToString();
    var values = Regex.Matches(stringMatch, @"[0-9]{1,3}");
    int a = int.Parse(values[0].ToString());
    int b = int.Parse(values[1].ToString());

    finalValue += a * b;
}

Console.WriteLine("finalValue part 1: " + finalValue.ToString());

var matchesPart2 = Regex.Matches(input, @"mul\([0-9]{1,3}\,[0-9]{1,3}\)|do\(\)|don\'t\(\)");
bool isEnabled = true;
int finalValue2 = 0;
foreach (Match match in matchesPart2)
{
    string stringMatch = match.ToString();
    
    bool isDo = Regex.Match(match.ToString(), @"do\(\)").Success;
    bool isDont = Regex.Match(match.ToString(), @"don\'t\(\)").Success;
    bool isMul = Regex.Match(match.ToString(), @"mul\([0-9]{1,3}\,[0-9]{1,3}\)").Success;

    isEnabled = isMul ? isEnabled : isDo;

    if (isEnabled && isMul)
    {
        var values = Regex.Matches(stringMatch, @"[0-9]{1,3}");
        int a = int.Parse(values[0].ToString());
        int b = int.Parse(values[1].ToString());

        // Console.WriteLine(a.ToString() + ' ' + b.ToString());
        finalValue2 += a * b;
    }
}

Console.WriteLine("finalValue2 " + finalValue2.ToString());
Console.ReadKey();