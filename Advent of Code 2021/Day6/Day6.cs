using System.Collections.Generic;

class Day6
{
    public static void Challenge1() // 361169
    {
        Helper helper = new Helper();

        string fileName = "Day6\\input.txt";
        string[] input = helper.ReadFileIntoStringArray(fileName);
        var startNumbers = ConvertStringIntoIntList(input);

        List<LanternFish> fishes = new List<LanternFish>();

        foreach (var number in startNumbers)
        {
            fishes.Add(new LanternFish { SpawnTimer = number });
        }

        Console.WriteLine("Fishes Day 0: " + fishes.Count);

        for (int day = 1; day <= 80; day++)
        {
            for (int fish = fishes.Count - 1; fish >= 0; fish--)
            {
                if (fishes[fish].UpdateSpawnTimer())
                {
                    fishes.Add(new LanternFish { SpawnTimer = 8 });
                }
            }
            Console.WriteLine("Fishes Day " + day + ": " + fishes.Count);
        }

        Console.WriteLine("Day6. Challenge 1: " + fishes.Count);
    }

    public static void Challenge2() // 1634946868992
    {
        Helper helper = new Helper();

        Dictionary<int, long> fishes = new();
        string fileName = "Day6\\input.txt";
        string[] input = helper.ReadFileIntoStringArray(fileName);

        for (int fish = 0; fish <= 8; fish++)
        {
            fishes.Add(fish, input[0].Count(f => f == (char)(fish + 48)));
        }
        for (int day = 1; day <= 256; day++)
        {
            UpdateFishes(fishes);
        }
        PrintAllFishes(fishes);
        long totalFishes = 0;
        for (int fish = 0; fish <= 8; fish++)
        {
            totalFishes += fishes[fish];
        }

        Console.WriteLine("Day6. Challenge 2: " + totalFishes);
    }

    private static void UpdateFishes(Dictionary<int, long> fishes)
    {
        long newFishes = fishes[0];
        for (int fish = 1; fish <= 8; fish++)
        {
            fishes[fish - 1] = fishes[fish];
        }
        fishes[6] += newFishes;
        fishes[8] = newFishes;
    }

    public static void PrintAllFishes(Dictionary<int, long> fishes)
    {
        for (int fish = 0; fish <= 8; fish++)
        {
            Console.WriteLine(fish + ": " +fishes[fish]);
        }
    }

    public static List<int> ConvertStringIntoIntList (string [] input)
    {
        List<int> output = new();
        string[] temp = input[0].Split(',');
        foreach (string s in temp)
        {
            output.Add(Int32.Parse(s));
            //Console.WriteLine(output.Count());
        }
        return output;
    }
}

class LanternFish
{  
    public int SpawnTimer { get; set; }

    public void PrintSpawnTimer ()
    {
        Console.WriteLine(SpawnTimer);
    }

    public bool UpdateSpawnTimer()
    {
        SpawnTimer--;
        if (SpawnTimer < 0)
        {
            SpawnTimer = 6;
            return true;
        }
        return false;
    }
}