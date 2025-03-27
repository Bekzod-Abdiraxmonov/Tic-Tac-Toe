using System;

class TicTacToe
{
    static char[,] board =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };
    static char currentPlayer = 'X';

    static void Main()
    {
        int move;
        bool gameRunning = true;

        while (gameRunning)
        {
            Console.Clear();
            PrintBoard();
            Console.Write($"O'yinchi {currentPlayer}, raqamni tanlang: ");
            if (int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 9 && IsMoveValid(move))
            {
                MakeMove(move);
                if (CheckWin())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine($"O'yinchi {currentPlayer} yutdi!");
                    gameRunning = false;
                }
                else if (CheckDraw())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("Durrang! O'yin tugadi.");
                    gameRunning = false;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
            else
            {
                Console.WriteLine("Noto'g'ri tanlov! Qaytadan kiriting.");
                Console.ReadKey();
            }
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine("\n  {0} | {1} | {2}", board[0, 0], board[0, 1], board[0, 2]);
        Console.WriteLine(" ---|---|---");
        Console.WriteLine("  {0} | {1} | {2}", board[1, 0], board[1, 1], board[1, 2]);
        Console.WriteLine(" ---|---|---");
        Console.WriteLine("  {0} | {1} | {2}\n", board[2, 0], board[2, 1], board[2, 2]);
    }

    static bool IsMoveValid(int move)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;
        return board[row, col] != 'X' && board[row, col] != 'O';
    }

    static void MakeMove(int move)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;
        board[row, col] = currentPlayer;
    }

    static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) return true;
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer) return true;
        }
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) return true;
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer) return true;
        return false;
    }

    static bool CheckDraw()
    {
        foreach (char cell in board)
        {
            if (cell != 'X' && cell != 'O') return false;
        }
        return true;
    }
}
