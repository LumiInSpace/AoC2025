using System.Data;
using System.Runtime.ExceptionServices;

namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Part1();
            //Part2();
        }

        public static void Part1()
        {
            //string[] sheet = File.ReadAllLines(@"C:\Lumi's Space\Dev\AoC2025\Day6\test.txt");
            string[] sheet = File.ReadAllLines(@"C:\Lumi's Space\Dev\AoC2025\Day6\input.txt");


            int rows = sheet.Length - 1;
            int cols = sheet[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

            int[,] numGrid = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var parts = sheet[r].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int c = 0; c < cols; c++)
                {
                    numGrid[r, c] = int.Parse(parts[c]);
                }
            }

            char[] ops = sheet[^1]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x[0])
                .ToArray();

            int[,] rotated = new int[cols, rows];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    rotated[c, r] = numGrid[r, c];
                }
            }

            long result = 0;

            for (int col = 0; col < cols; col++)
            {
                long temp = rotated[col, 0];

                for (int r = 1; r < rows; r++)
                {
                    char op = ops[col];
                    temp = op switch
                    {
                        '+' => temp + rotated[col, r],
                        '*' => temp * rotated[col, r],
                        _ => throw new Exception("Unknown operator")
                    };
                }

                result += temp;
            }

            Console.WriteLine(result);
        }

        public static void Part2()
        {

        }   
    }
}
