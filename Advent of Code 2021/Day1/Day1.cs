// Advent of Code. Day 1, Assignment 1.

class Day1
{
    public static void Challenge1()
    {
        Helper helper = new Helper();

        string fileName = "Day1\\input.txt";
        List<int> input = helper.ReadFileIntoIntList(fileName);

        int lastNumber = 999999999;
        int counter = 0;
        foreach (int number in input)
        {
            if (number > lastNumber)
            {
                counter++;
            }
            lastNumber = number;
        }
        Console.WriteLine("Day1. Challenge 1: " + counter);
    }

    public static void Challenge2()
    {
        Helper helper = new Helper();

        string fileName = "Day1\\input.txt";
        int[] input = helper.ReadFileIntoIntArray(fileName);

        Console.WriteLine(input.Length);
        int lastNumber = 999999999;
        int counter = 0;
        int number = 0;
        for (int i = 0; i<input.Length-2;i++)
        {
            number = input[i] + input[i+1] + input[i+2];
            if (number > lastNumber)
            {
                counter++;
            }
            lastNumber = number;
        }
        Console.WriteLine("Day1. Challenge 2: " + counter);
    }
}


