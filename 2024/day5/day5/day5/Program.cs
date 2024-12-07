// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Runtime.ExceptionServices;

string[] ordersInput = File.ReadAllLines(@"C:\Users\lorgn\project\AdventOfCode\2024\day5\day5\day5\input_1.txt");
string[] sequencesInput = File.ReadAllLines(@"C:\Users\lorgn\project\AdventOfCode\2024\day5\day5\day5\input_2.txt");

List<List<int>> orders = new List<List<int>>();   
foreach (string orderLine in ordersInput)
{
    List<int> order = orderLine.Split('|').Select(int.Parse).ToList();
    orders.Add(order);
}

List<List<int>> sequences = new List<List<int>>();
foreach (string sequenceLine in sequencesInput)
{
    List<int> sequence = sequenceLine.Split(',').Select(int.Parse).ToList();
    sequences.Add(sequence);
}

int getSortingScore(int X, int Y)
{
    List<int>? xBefore = orders.Find((order) => order[0] == X && order[1] == Y);
    List<int>? xAfter = orders.Find((order) => order[0] == Y && order[1] == X);

    return xBefore != null ? -1 : xAfter != null ? 1 : 0;
}
bool isSequenceCorrect(List<int> sequence)
{
    bool result = true;
    foreach (List<int> order in orders)
    {
        int X = order[0];
        int Y = order[1];

        int indexOfX = sequence.IndexOf(X);
        int indexOfY = sequence.IndexOf(Y);

        if (indexOfX > -1 && indexOfY > -1 && indexOfX > indexOfY)
        {
            result = false;
            break;
        }
    }
    return result;
}

int finalSumCorrect = 0;
int finalSumCorrect2 = 0;
foreach (var sequence in sequences)
{
    int index = sequence.Count / 2;
    if (isSequenceCorrect(sequence))
    {
        finalSumCorrect += sequence[index];
    } else
    {
        sequence.Sort(getSortingScore);
        finalSumCorrect2 += sequence[index];
    }
}

Console.Write("finalSum " + finalSumCorrect);
Console.Write("finalSum2 " + finalSumCorrect2);

Console.ReadKey();
