
class Day2
{
    public static void Challenge1()
    {
        Helper helper = new Helper();

        string fileName = "Day2\\input.txt";
        string[] input = helper.ReadFileIntoStringArray(fileName);

        int position = 0;
        int depth = 0;

        foreach (string inputItem in input)
        {
            string[] splitInput = inputItem.Split(' ');
            string instruction = splitInput[0];
            int number = int.Parse(splitInput[1]);
            if(instruction == "forward")
            {
                position += number;
            }
            if (instruction == "down")
            {
                depth += number;
            }
            if (instruction == "up")
            {
                depth -= number;
                if (depth < 0)
                    Console.WriteLine("ERROR! Cannot float above the surface.");
            }
        }
        Console.WriteLine("Day2. Challenge 1: " + (position*depth));
    }

    public static void Challenge2()
    {
        Helper helper = new Helper();

        string fileName = "Day2\\input.txt";
        string[] input = helper.ReadFileIntoStringArray(fileName);

        int position = 0;
        int depth = 0;
        int aim = 0;

        foreach (string inputItem in input)
        {
            string[] splitInput = inputItem.Split(' ');
            string instruction = splitInput[0];
            int number = int.Parse(splitInput[1]);

            if (instruction == "forward")
            {
                position += number;
                depth += number * aim;
            }
            if (instruction == "down")
            {
                aim += number;
            }
            if (instruction == "up")
            {
                aim -= number;
            }
            if (depth < 0)
                Console.WriteLine("ERROR! Cannot float above the surface.");
        }
        Console.WriteLine("Day2. Challenge 2: " + (position * depth));
    }
}


