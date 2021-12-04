
class Day3
{
    public static void Challenge1() // 2972336
    {
        Helper helper = new Helper();

        string fileName = "Day3\\input.txt";
        string[] input = helper.ReadFileIntoStringArray(fileName);

        int amountOfCharacters = input[0].Length;
        int amountOfLines = input.Length;
        int[] countOnes = new int[amountOfCharacters];

        for (int currentLine = 0; currentLine < amountOfLines; currentLine++)
        {
            for (int currentCharacter = 0; currentCharacter < amountOfCharacters; currentCharacter++)
            {
                if (input[currentLine].ElementAt<char>(currentCharacter) == '1')
                {
                    countOnes[currentCharacter]++;
                }
            }
        }

        string gammaBinary = "";
        string epsilonBinary = "";
        foreach (int currentOnes in countOnes)
        {
            if (currentOnes > amountOfLines / 2)
            {
                gammaBinary += "1";
                epsilonBinary += "0";
            }
            else
            {
                gammaBinary += "0";
                epsilonBinary += "1";
            }
        }
        int gammaDecimal = helper.ConvertBinaryStringToDecimalInt(gammaBinary);
        int epsilonDecimal = helper.ConvertBinaryStringToDecimalInt(epsilonBinary);

        Console.WriteLine("Day3. Challenge 1: " + gammaDecimal * epsilonDecimal);
    }


    public static void Challenge2() // 3368358
    {
        Helper helper = new Helper();

        string fileName = "Day3\\input.txt";
        List<string> input = helper.ReadFileIntoStringList(fileName);
        List<string> input2 = helper.ReadFileIntoStringList(fileName);

        int oxygen = helper.ConvertBinaryStringToDecimalInt(FilterDownToLastRow(input, true));
        int co2 = helper.ConvertBinaryStringToDecimalInt(FilterDownToLastRowLow(input2));

        Console.WriteLine("Day3. Challenge 2: "+ oxygen+ " " + co2 + " " + oxygen*co2);
    }

    private static int CountNumberOfOnesAtPosition(List<string> inData, int position)
    {
        int countOnes = 0;

        foreach (string inputString in inData)
        {
            if (inputString.ElementAt<char>(position) == '1')
            {
                countOnes++;
            }
        }
        return countOnes;
    }

    private static char ReturnHighestNumberAtPosition(List<string> inData, int position, char ifEqual)
    {
        int countZeros = 0;
        int countOnes = 0;

        foreach (string inputString in inData)
        {
            if (inputString.ElementAt<char>(position) == '1')
            {
                countOnes++;
            }
            else
            {
                countZeros++;
            }
        }
        if (countZeros == countOnes)
        {
            return ifEqual;
        }
        return (countOnes > countZeros) ? '1' : '0';
    }

    private static List<string> KeepOnlyThoseWithACertainNumberAtPosition(List<string> inData, char number, int position)
    {
        if (inData.Count == 1)
        {
            Console.WriteLine(":"+inData[0]);

            return inData;
        }
        for (int row = inData.Count - 1; row >= 0; row--)
        {
            if (inData[row].ElementAt(position) != number)
            {
                inData.RemoveAt(row);
            }
        }
        return inData;
    }

    private static string FilterDownToLastRow(List<string> inData, bool keepHighest)
    {
        for (int i = 0; i < inData[0].Length; i++)
        {
            if (keepHighest)
            {
                char search = ReturnHighestNumberAtPosition(inData, i, '1');
                inData = KeepOnlyThoseWithACertainNumberAtPosition(inData, search, i);
            }
            else
            {
                char search = ReturnHighestNumberAtPosition(inData, i, '1');
                inData = KeepOnlyThoseWithACertainNumberAtPosition(inData, InvertBinaryChar(search), i);
            }
            if (inData.Count == 1)
            {
                break;
            }
        }
        return inData[0];
    }

    private static char InvertBinaryChar(char invert)
    {
        return (invert == '1') ? '0' : '1';
    }

    private static char ReturnLowestNumberAtPosition(List<string> inData, int position)
    {
        int countZeros = 0;
        int countOnes = 0;

        foreach (string inputString in inData)
        {
            if (inputString.ElementAt<char>(position) == '1')
            {
                countOnes++;
            }
            else
            {
                countZeros++;
            }
        }
        if (countZeros == countOnes)
        {
            return '0';
        }
        return (countOnes < countZeros) ? '1' : '0';
    }

    private static string FilterDownToLastRowLow(List<string> inData)
    {
        for (int i = 0; i < inData[0].Length; i++)
        {
            char search = ReturnLowestNumberAtPosition(inData, i);
            inData = KeepOnlyThoseWithACertainNumberAtPosition(inData, search, i);
            if (inData.Count == 1)
            {
                break;
            }
        }
        return inData[0];
    }
}


