// See https://aka.ms/new-console-template for more information
using System.Numerics;

List<string> input = File.ReadAllLines("C:\\Users\\lorgn\\project\\AdventOfCode\\2024\\day2\\day2\\input.txt").ToList();

int nbCorrectLinesPart1 = 0;
foreach (string line in input)
{
    List<int> allValue = line.Split(' ').Select((val) => int.Parse(val)).ToList();
    bool isIncreasing = allValue[0] < allValue[1];
    bool isCorrect = true;

    for(int i = 0; i < allValue.Count - 1; i++)
    {
        if (isIncreasing)
        {
            bool growMoreThan1 = allValue[i] + 1 <= allValue[i + 1];
            bool growLessThan3 = allValue[i] + 3 >= allValue[i + 1];
            isCorrect = growMoreThan1 && growLessThan3;
        } else
        {
            bool decreaseMoreThan1 = allValue[i] - 1 >= allValue[i + 1];
            bool decreaseLessThan3 = allValue[i] - 3 <= allValue[i + 1];
            isCorrect = decreaseMoreThan1 && decreaseLessThan3;
        }

        if (isCorrect == false) { break; }
    }

    if (isCorrect)
    {
        nbCorrectLinesPart1++;
    }
}

Console.WriteLine(nbCorrectLinesPart1.ToString());
Console.WriteLine("-----------------------------");

int nbCorrectLinesPart2 = 0;
foreach (string line in input)
{
    List<int> allValue = line.Split(' ').Select((val) => int.Parse(val)).ToList();

    bool isCounting = false;

    // On essaie toutes les possibilités de mauvaise erreur et ceux sans erreur également
    for(int i = -1; i < allValue.Count; i++)
    {
        List<int> duplicate = new List<int>(allValue);
        if (i > -1)
        {
            duplicate.RemoveAt(i);
        }

        bool isIncreasing = duplicate[0] < duplicate[1];
        bool isCorrect = true;

        for (int j = 0; j < duplicate.Count - 1; j++)
        {
            if (isIncreasing)
            {
                bool growMoreThan1 = duplicate[j] + 1 <= duplicate[j + 1];
                bool growLessThan3 = duplicate[j] + 3 >= duplicate[j + 1];
                isCorrect = growMoreThan1 && growLessThan3;
            }
            else
            {
                bool decreaseMoreThan1 = duplicate[j] - 1 >= duplicate[j + 1];
                bool decreaseLessThan3 = duplicate[j] - 3 <= duplicate[j + 1];
                isCorrect = decreaseMoreThan1 && decreaseLessThan3;
            }

            if (isCorrect == false) { break; }
        }

        if (isCorrect) {
            isCounting = true;
            break; 
        }
    }

    if (isCounting)
    {
        nbCorrectLinesPart2++;
    }
}

Console.WriteLine(nbCorrectLinesPart2.ToString());
Console.Read();