/******************************
 * Advent of Code  Year 2021  *
 ******************************/

//Day1.Challenge1();
//Day1.Challenge2();
Day2.Challenge1();
Day2.Challenge2();

class Helper
{
    public string[] ReadFileIntoStringArray(string fileName)
    {
        string[] result = File.ReadAllLines("..\\..\\..\\" + fileName);
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
}
