using System.Text;

namespace Day4
{
    internal class Program
    {
        static readonly int[][] directions =
        {
            //[row][column]
            new[] { -1, -1 }, //top left
            new[] { -1,  0 }, //top mid
            new[] { -1, +1 }, //top right
            new[] {  0, -1 }, //mid left
            new[] {  0, +1 }, //mid right
            new[] { +1, -1 }, //bottom left
            new[] { +1,  0 }, //bottom mid
            new[] { +1, +1 } //bottom right
        };

        static void Main(string[] args)
        {
            //Part1();
            Part2();
        }

        public static void Part1()
        {
            var grid = File.ReadAllLines("C:\\Dev\\AoC2025\\Day4\\input.txt");
            int accessableRoles = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    int adjacentRoles = 0;
                    if(grid[row][col] != '@') { continue; }

                    foreach (var dir in directions)
                    {
                        int newRow = row + dir[0];
                        int newCol = col + dir[1];

                        if (newRow < 0 || newCol < 0)
                            continue;

                        if (newRow >= grid.Length)
                            continue;

                        if (newCol >= grid[newRow].Length)
                            continue;

                        if (grid[newRow][newCol] == '@' )
                        {
                            adjacentRoles++;
                        }
                    }

                    if (adjacentRoles < 4)
                    {
                        accessableRoles++;
                    }
                }
            }

            Console.WriteLine(accessableRoles);
        }

        public static void Part2()
        {
            string[] grid = File.ReadAllLines("C:\\Dev\\AoC2025\\Day4\\input.txt");
            int currentAccessableRoles = -1;
            int totalAccessableRoles = 0;

            while (currentAccessableRoles != 0)
            {
                currentAccessableRoles = 0;

                for (int row = 0; row < grid.Length; row++)
                {
                    for (int col = 0; col < grid[row].Length; col++)
                    {
                        int adjacentRoles = 0;
                        if (grid[row][col] != '@') { continue; }

                        foreach (var dir in directions)
                        {
                            int newRow = row + dir[0];
                            int newCol = col + dir[1];

                            if (newRow < 0 || newCol < 0)
                                continue;

                            if (newRow >= grid.Length)
                                continue;

                            if (newCol >= grid[newRow].Length)
                                continue;

                            if (grid[newRow][newCol] == '@')
                            {
                                adjacentRoles++;
                            }
                        }

                        if (adjacentRoles < 4)
                        {
                            currentAccessableRoles++;
                            grid[row] = grid[row].Remove(col, 1).Insert(col, ".");
                        }
                    }
                }

                totalAccessableRoles += currentAccessableRoles;
            }

            Console.WriteLine(totalAccessableRoles);
        }
    }
}