/******************************
 * Advent of Code  Year 2021  *
 ******************************/

//Day1.Challenge1();
//Day1.Challenge2();
//Day2.Challenge1();
//Day2.Challenge2();
//Day3.Challenge1();
//Day3.Challenge2();
//Day4.Challenge1();
Day4.Challenge2();

class Helper
{
    public string[] ReadFileIntoStringArray(string fileName)
    {
        string[] result = File.ReadAllLines("..\\..\\..\\" + fileName);
        return result;
    }

    public List<string> ReadFileIntoStringList(string fileName)
    {
        List<string> result = new();
        string[] inData = File.ReadAllLines("..\\..\\..\\" + fileName);
        foreach (string s in inData)
        {
            result.Add(s);
        }
        return result;
    }

    public List<int> ReadFileIntoIntList(string fileName)
    {
        List<int> result = new();
        string[] fileInput = File.ReadAllLines("..\\..\\..\\" + fileName);
        int number = 0;
        foreach (string line in fileInput)
        {
            if (int.TryParse(line, out number))
            {
                result.Add(number);
            }
        }
        return result;
    }

    public int[] ReadFileIntoIntArray(string fileName)
    {
        List<int> result = new();
        string[] fileInput = File.ReadAllLines("..\\..\\..\\" + fileName);
        int number = 0;
        foreach (string line in fileInput)
        {
            if (int.TryParse(line, out number))
            {
                result.Add(number);
            }
        }
        return result.ToArray();
    }

    public int ConvertBinaryStringToDecimalInt(string binary)
    {
        return Convert.ToInt32(binary, 2);
    }
}


class Day
{
    public static void Challenge1()
    {
        Helper helper = new Helper();

        string fileName = "Day\\input.txt";
        string[] input = helper.ReadFileIntoStringArray(fileName);


        Console.WriteLine("Day. Challenge 1: ");
    }

    public static void Challenge2()
    {
        Helper helper = new Helper();

        string fileName = "Day\\input.txt";
        string[] input = helper.ReadFileIntoStringArray(fileName);


        Console.WriteLine("Day. Challenge 2: ");
    }
}