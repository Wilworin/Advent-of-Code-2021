class Day4
{
    public static void Challenge1()
    {
        Helper helper = new Helper();

        string fileName = "Day4\\input.txt";
        string[] input = helper.ReadFileIntoStringArray(fileName);
        string[] playedNumbers = input[0].Split(',');
        int winningScore = 0;

        List<Board> boards = new List<Board>();
        LoadBoards(boards, input);
        foreach (string number in playedNumbers)
        {
            for (int currentBoard = 0; currentBoard < boards.Count(); currentBoard++)
            {
                boards[currentBoard].CheckDrawnNumber(number);
                if (boards[currentBoard].CheckIfBingo())
                {
                    Console.WriteLine("BINGO found at board: " + currentBoard + "!");
                    boards[currentBoard].PrintBoard();
                    winningScore = boards[currentBoard].CalculateScore(int.Parse(number));
                    goto GameEnd;
                }
            }
        }
        GameEnd:
        Console.WriteLine("Antal boards: " + boards.Count);
        Console.WriteLine("Day4. Challenge 1: " + winningScore);
    }


    public static void Challenge2()
    {
        Helper helper = new Helper();

        string fileName = "Day4\\input.txt";
        string[] input = helper.ReadFileIntoStringArray(fileName);
        string[] playedNumbers = input[0].Split(',');
        int winningScore = 0;

        List<Board> boards = new List<Board>();
        LoadBoards(boards, input);
        foreach (string number in playedNumbers)
        {
            for (int currentBoard = boards.Count -1; currentBoard >= 0; currentBoard--)
            {
                boards[currentBoard].CheckDrawnNumber(number);
                if (boards[currentBoard].CheckIfBingo())
                {
                    Console.WriteLine("BINGO found at board: " + currentBoard + " with number" + number + "!");
                    //boards[currentBoard].PrintBoard();
                    winningScore = boards[currentBoard].CalculateScore(int.Parse(number));
                    if (boards.Count == 1)
                    {
                        goto GameEnd;
                    }
                    else 
                    boards.RemoveAt(currentBoard);
                }
            }
        }
    GameEnd:
        PrintAllBoards(boards);
        //winningScore = boards[0].CalculateScore(1);

    Console.WriteLine("Antal boards: " + boards.Count);
    Console.WriteLine("Day4. Challenge 2: " + winningScore);
    }

    public static List<Board> LoadBoards(List<Board> boards, string[] input)
    {
        int inputRowCounter = 2;
        while (inputRowCounter < input.Count())
        {
            Board board = new Board();
            board.AddRow(input[inputRowCounter],1);
            board.AddRow(input[inputRowCounter+1],2);
            board.AddRow(input[inputRowCounter+2],3);
            board.AddRow(input[inputRowCounter+3],4);
            board.AddRow(input[inputRowCounter+4],5);
            boards.Add(board);
            inputRowCounter += 6;
            
        }
        return boards;
    }

    private static void PrintAllBoards(List<Board> boards)
    {
        foreach (Board board in boards)
        {
            board.PrintBoard();
        }
    }
}

class Board
{
    string[] Row1 { get; set; } = new string[4];
    string[] Row2 { get; set; } = new string[4];
    string[] Row3 { get; set; } = new string[4];
    string[] Row4 { get; set; } = new string[4];
    string[] Row5 { get; set; } = new string[4];

    public void AddRow(string input, int row)
    {
        //Console.WriteLine("Row: "+row+" "+input);
        switch (row)
        {
            case 1: 
                Row1 = SplitStringIntoArray(input);
                break;
            case 2:
                Row2 = SplitStringIntoArray(input);
                break;
            case 3:
                Row3 = SplitStringIntoArray(input);
                break;
            case 4:
                Row4 = SplitStringIntoArray(input);
                break;
            case 5:
                Row5 = SplitStringIntoArray(input);
                break;
            default:
                break;
        }
    }

    private string[] SplitStringIntoArray(string input)
    {
        input = RemoveDoubleSpaces(input);
        string[] output = input.Split(' ');
        
        //foreach (string s in output) Console.Write("["+s+"] ");
        //Console.WriteLine();
        return output;
    }

    public void CheckDrawnNumber(string number)
    {
        //Console.WriteLine(number);
        for (int column = 0; column <= 4; column++)
        {
            if (Row1[column] == number) Row1[column] = "*";
            if (Row2[column] == number) Row2[column] = "*";
            if (Row3[column] == number) Row3[column] = "*";
            if (Row4[column] == number) Row4[column] = "*";
            if (Row5[column] == number) Row5[column] = "*";

        }
    }

    public bool CheckIfBingo()
    {
        bool bingo = false;
        for(int column = 0;column <= 4;column++)
        {
            if (Row1[column] == "*" && Row2[column] == "*" && Row3[column] == "*" && Row4[column] == "*" && Row5[column] == "*")
            {
                bingo = true;
            }
        }
        if(Row1[0] == "*" && Row1[1] == "*" && Row1[2] == "*" && Row1[3] == "*" && Row1[4] == "*") { bingo = true; }
        if(Row2[0] == "*" && Row2[1] == "*" && Row2[2] == "*" && Row2[3] == "*" && Row2[4] == "*") { bingo = true; }
        if(Row3[0] == "*" && Row3[1] == "*" && Row3[2] == "*" && Row3[3] == "*" && Row3[4] == "*") { bingo = true; }
        if(Row4[0] == "*" && Row4[1] == "*" && Row4[2] == "*" && Row4[3] == "*" && Row4[4] == "*") { bingo = true; }
        if(Row5[0] == "*" && Row5[1] == "*" && Row5[2] == "*" && Row5[3] == "*" && Row5[4] == "*") { bingo = true; }
        return bingo;
    }

    public int CalculateScore(int lastNumberCalled)
    {
        int score = 0;
        for(int column = 0;column <= 4;column++)
        {
            if (Row1[column] != "*")
            {
                score += int.Parse(Row1[column]);
            }
            if (Row2[column] != "*")
            {
                score += int.Parse(Row2[column]);
            }
            if (Row3[column] != "*")
            {
                score += int.Parse(Row3[column]);
            }
            if (Row4[column] != "*")
            {
                score += int.Parse(Row4[column]);
            }
            if (Row5[column] != "*")
            {
                score += int.Parse(Row5[column]);
            }
        }
        score *= lastNumberCalled;
        return score;
    }

    public void PrintBoard()
    {
        foreach (var col in Row1) Console.Write(col + " ");
        Console.WriteLine();
        foreach (var col in Row2) Console.Write(col + " ");
        Console.WriteLine();
        foreach (var col in Row3) Console.Write(col + " ");
        Console.WriteLine();
        foreach (var col in Row4) Console.Write(col + " ");
        Console.WriteLine();
        foreach (var col in Row5) Console.Write(col + " ");
        Console.WriteLine();
    }

    private string RemoveDoubleSpaces(string inData)
    {
        inData = inData.Trim();
        while (inData.Contains("  "))
        {
            inData = inData.Replace("  ", " ");
        }
        return inData;
    }
}