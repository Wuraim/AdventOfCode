// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

int finalSum = 0;
List<int> array1 = new List<int>();
List<int> array2 = new List<int>();

string[] input = File.ReadAllLines("C:\\Users\\lorgn\\project\\AdventOfCode\\2024\\day1\\day1\\input.txt");
foreach (var line in input)
{
    string[] lineValue = line.Split("   ");
    int a = int.Parse(lineValue[0]);
    int b = int.Parse(lineValue[1]);
    array1.Add(a);
    array2.Add(b);
}

array1.Sort();
array2.Sort();

for (int i = 0; i < array1.Count; i++)
{
    finalSum += Math.Abs(array1[i] - array2[i]);
}

Console.WriteLine(finalSum);
Console.WriteLine("------------");

HashSet<int> setFinal = array1.ToHashSet();
HashSet<int> set2 = array2.ToHashSet();
setFinal.UnionWith(set2);

int finalSimilarity = 0;
foreach (var sub in setFinal)
{
    int times1 = array1.FindAll(delegate (int val)
    {
        return val == sub;
    }
    ).Count;

    int times2 = array2.FindAll(delegate (int val)
    {
        return val == sub;
    }
    ).Count;

    finalSimilarity += sub * times1 * times2;
}
Console.WriteLine(finalSimilarity);



Console.Read();