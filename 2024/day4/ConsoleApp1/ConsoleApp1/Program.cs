// See https://aka.ms/new-console-template for more information
string[] input = File.ReadAllLines("C:\\Users\\lorgn\\project\\AdventOfCode\\2024\\day4\\ConsoleApp1\\ConsoleApp1\\input.txt");

char getNextLetter(char letter)
{
    return "XMAS".ElementAt("XMAS".IndexOf(letter) + 1);
}

char test = getNextLetter('X');

int numberOfXMAS(char letterToCheck, int nRow, int nCol, int[] vec)
{
    char letter = input[nRow][nCol];
    if(letter.Equals(letterToCheck))
    {
        if (letter.Equals('S'))
        {
            return 1;
        } else {
            int nbResult = 0;
            char nextLetter = getNextLetter(letter);
            if (letter.Equals('X'))
            {
                for (int i = -1; i <= 1; i++)
                {
                    int nextRow = nRow + i;
                    bool isNextRowExist = nextRow >= 0 && nextRow < input.Length;

                    if (isNextRowExist)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int nextCol = nCol + j;
                            bool isNextColExist = nextCol >= 0 && nextCol < input[nextRow].Length;

                            if (isNextColExist)
                            {
                                nbResult += numberOfXMAS(nextLetter, nextRow, nextCol, [i,j]);
                            }
                        }
                    }
                }
            }
            else
            {
                int nextRow = nRow + vec[0];
                bool isNextRowExist = nextRow >= 0 && nextRow < input.Length;

                if(isNextRowExist)
                {
                    int nextCol = nCol + vec[1];
                    bool isNextColExist = nextCol >= 0 && nextCol < input.Length;
                    if(isNextColExist)
                    {
                        nbResult += numberOfXMAS(nextLetter, nextRow, nextCol, vec);
                    }
                }
            }
            
            return nbResult;
        }
    } else
    {
        return 0;
    }
}

int nbOfXmas = 0;
for(int nRow = 0; nRow < input.Length; nRow++)
{
    for(int nCol = 0; nCol < input[nRow].Length; nCol++)
    {
        nbOfXmas += numberOfXMAS('X', nRow, nCol, [0, 0]);
    }
}

Console.WriteLine(nbOfXmas);
Console.WriteLine("----------------------");

int numberOfXMASPartTwo(int nRow, int nCol)
{
    int nbOfXmas = 0;

    char currentLetter = input[nRow][nCol];
    if(currentLetter == 'M')
    {
        bool isNextLineCorrect = nRow + 2 < input.Length;

        bool isColRightCorrect = nCol + 2 < input[nRow].Length;

        if(isNextLineCorrect && isColRightCorrect)
        {
            // Part Down Vertical Symmetry
            bool isSecondM = input[nRow][nCol + 2] == 'M';
            bool isA = input[nRow + 1][nCol + 1] == 'A';
            bool isS1 = input[nRow + 2][nCol] == 'S';
            bool isS2 = input[nRow + 2][nCol+ 2] == 'S';

            if (isSecondM && isA && isS1 && isS2)
            {
                nbOfXmas++;
            }

            // Part Right Horizontal Symmetry
            isSecondM = input[nRow + 2][nCol] == 'M';
            isA = input[nRow + 1][nCol + 1] == 'A';
            isS1 = input[nRow][nCol + 2] == 'S';
            isS2 = input[nRow + 2][nCol + 2] == 'S';

            if (isSecondM && isA && isS1 && isS2)
            {
                nbOfXmas++;
            }
        }

        bool isLineAboveCorrect = nRow - 2 >= 0;

        if (isLineAboveCorrect && isColRightCorrect)
        {
            // Part Up Vertical Symmetry
            bool isSecondM = input[nRow][nCol + 2] == 'M';
            bool isA = input[nRow - 1][nCol + 1] == 'A';
            bool isS1 = input[nRow - 2][nCol] == 'S';
            bool isS2 = input[nRow - 2][nCol + 2] == 'S';

            if (isSecondM && isA && isS1 && isS2)
            {
                nbOfXmas++;
            }
        }

        bool isColLeftCorrect = nCol - 2 >= 0;
        if(isNextLineCorrect && isColLeftCorrect)
        {
            // Part Left Horizontal Symmetry
            bool isSecondM = input[nRow + 2][nCol] == 'M';
            bool isA = input[nRow + 1][nCol - 1] == 'A';
            bool isS1 = input[nRow][nCol - 2] == 'S';
            bool isS2 = input[nRow + 2][nCol - 2] == 'S';

            if (isSecondM && isA && isS1 && isS2)
            {
                nbOfXmas++;
            }
        }

    }
    return nbOfXmas;
}

nbOfXmas = 0;
for (int nRow = 0; nRow < input.Length; nRow++)
{
    for (int nCol = 0; nCol < input[nRow].Length; nCol++)
    {
        nbOfXmas += numberOfXMASPartTwo(nRow, nCol);
    }
}

Console.WriteLine(nbOfXmas);

Console.ReadKey();
