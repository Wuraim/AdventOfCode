// See https://aka.ms/new-console-template for more information
using System.Numerics;

List<string> input = File.ReadAllLines("C:\\Users\\g.lorgnier\\source\\repos\\AdventOfCode\\2024\\day2\\day2\\input.txt").ToList();

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

    bool isIncreasing = true;
    if (allValue[0] != allValue[1])
    {
        isIncreasing = allValue[0] < allValue[1];
    } else
    {
        isIncreasing = allValue[1] < allValue[2];
    }

    bool isCorrect = true;
    bool hasNotMadeOneMistake = true;

    for (int i = 0; i < allValue.Count - 1; i++)
    {
        if (isIncreasing)
        {
            bool growMoreThan1 = allValue[i] + 1 <= allValue[i + 1];
            bool growLessThan3 = allValue[i] + 3 >= allValue[i + 1];
            isCorrect = growMoreThan1 && growLessThan3;
        }
        else
        {
            bool decreaseMoreThan1 = allValue[i] - 1 >= allValue[i + 1];
            bool decreaseLessThan3 = allValue[i] - 3 <= allValue[i + 1];
            isCorrect = decreaseMoreThan1 && decreaseLessThan3;
        }

        if (isCorrect == false && hasNotMadeOneMistake == true) {
            hasNotMadeOneMistake = false;
        } else if (isCorrect == false) { 
            break; 
        }
    }

    if (isCorrect)
    {
        nbCorrectLinesPart2++;
    }
}

Console.WriteLine(nbCorrectLinesPart2.ToString());
