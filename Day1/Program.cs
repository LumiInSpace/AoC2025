using System.Runtime.CompilerServices;
using System.IO;

namespace Day1
{
    public class Program
    {
        public readonly static string InputFile = "C:\\Dev\\AoC2025\\Day1\\input.txt";
        public static int CurrentPosition { get; set; } = 50;
        public static int LastPosition { get; set; } = 0;
        public static int ZeroCount { get; set; } = 0;

        static void Main(string[] args)
        {
            string[] fileContent = File.ReadAllLines(InputFile);

            foreach (string line in fileContent)
            {
                LastPosition = CurrentPosition;
                char[] chars = line.ToCharArray();
                char direction = chars[0];
                int steps = int.Parse(line.Remove(0, 1));

                int rotations = steps / 100;
                ZeroCount += rotations;
                steps = steps % 100;

                if (direction == 'R')
                {
                    CurrentPosition += steps;
                }
                else
                {
                    CurrentPosition -= steps;
                    if (CurrentPosition < 0)
                    {
                        CurrentPosition += 100;
                    }
                }

                CurrentPosition %= 100;


                if (CurrentPosition == 0 || LastPosition != 0 && ((LastPosition > CurrentPosition && direction == 'R') || (LastPosition < CurrentPosition && direction == 'L')))
                {
                    ZeroCount++;
                }
            }

            Console.WriteLine(ZeroCount.ToString());
        }
    }
}