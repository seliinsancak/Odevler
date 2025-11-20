using System;

class Program
{
    static void Main()
    {
        int rows = GetInt("Lütfen üçgenin kaç satır içereceğini giriniz >> ");

        int[][] pascal = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            pascal[i] = new int[i + 1];
            pascal[i][0] = 1;
            pascal[i][i] = 1;

            for (int j = 1; j < i; j++)
            {
                pascal[i][j] = pascal[i - 1][j - 1] + pascal[i - 1][j];
            }
        }

        Console.WriteLine();

        for (int i = 0; i < rows; i++)
        {
            for (int k = 0; k < rows - i; k++)
                Console.Write(" ");

            for (int j = 0; j <= i; j++)
                Console.Write(pascal[i][j] + "     ");

            Console.WriteLine();
        }
    }

    static int GetInt(string msg)
    {
        int value;
        while (true)
        {
            Console.Write(msg);
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;
            Console.WriteLine("Lütfen pozitif bir tam sayı giriniz!\n");
        }
    }
}
