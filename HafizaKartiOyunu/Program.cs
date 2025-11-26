using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        char[] letters = { 'A','A','B','B','C','C','D','D','E','E','F','F','G','G','H','H' };
        char[] board = new char[16];
        bool[] opened = new bool[16];
        Random rnd = new Random();

        for (int i = 0; i < 16; i++)
        {
            int r = rnd.Next(i, 16);
            (letters[i], letters[r]) = (letters[r], letters[i]);
            board[i] = letters[i];
        }

        int steps = 0;
        Stopwatch sw = Stopwatch.StartNew();

        while (true)
        {
            PrintBoard(board, opened);

            int first = GetChoice("Lütfen 1. Kartı seçiniz >> ", opened) - 1;
            opened[first] = true;
            PrintBoard(board, opened);

            int second = GetChoice("Lütfen 2. Kartı seçiniz >> ", opened, first) - 1;
            opened[second] = true;
            PrintBoard(board, opened);

            steps++;

            if (board[first] != board[second])
            {
                System.Threading.Thread.Sleep(1200);
                opened[first] = false;
                opened[second] = false;
            }

            if (AllOpened(opened)) break;
        }

        sw.Stop();
        double minutes = sw.Elapsed.TotalMinutes;

        Console.WriteLine("<<End of the Game>>");
        PrintBoard(board, opened);
        Console.WriteLine($"OYUN BİTTİ!\nTOPLAM ADIM SAYISI = {steps}\nTOPLAM SÜRE = {minutes:F2} dk");
    }

    static int GetChoice(string msg, bool[] opened, int exclude = -1)
    {
        int choice;
        while (true)
        {
            Console.Write(msg);

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Lütfen sayı giriniz!");
                continue;
            }

            if (choice < 1 || choice > 16)
            {
                Console.WriteLine("Lütfen 1-16 arası geçerli bir kart seçiniz!");
                continue;
            }

            if (opened[choice - 1])
            {
                if (choice - 1 == exclude)
                    Console.WriteLine("Bu kart zaten açık, başka bir kart seçiniz!");
                else
                    Console.WriteLine("Açık olan bir kart seçtiniz!");

                continue;
            }

            return choice;
        }
    }

    static void PrintBoard(char[] board, bool[] opened)
    {
        Console.WriteLine();

        for (int i = 0; i < 16; i++)
        {
            if (opened[i])
                Console.Write($"  {board[i]}  | ");
            else
                Console.Write($" {(i + 1).ToString().PadLeft(2, ' ')} | ");

            if ((i + 1) % 4 == 0)
                Console.WriteLine();
        }

        Console.WriteLine(new string('-', 40));
    }

    static bool AllOpened(bool[] opened)
    {
        foreach (bool o in opened)
            if (!o) return false;

        return true;
    }
}
