using System;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Part1();
            Part2();
        }

        public static void Part1()
        {
            int fresh = 0;
            var ranges = new List<(long x, long y)>();

            string[] input = File.ReadAllLines("C:\\Dev\\AoC2025\\Day5\\input.txt");

            foreach (string line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                    break;

                var parts = line.Split('-');
                ranges.Add((long.Parse(parts[0]), long.Parse(parts[1])));
            }

            for (int i = 193; i < input.Length; i++)
            {
                foreach (var range in ranges)
                {
                    if (long.Parse(input[i]) >= range.x && long.Parse(input[i]) <= range.y)
                    {
                        fresh++;
                        break;
                    }
                }
            }

            Console.WriteLine(fresh);
        }

        public static void Part2()
        {
            var ranges = new List<(long x, long y)>();
            long fresh = 0;

            string[] input = File.ReadAllLines("C:\\Dev\\AoC2025\\Day5\\input.txt");
            //string[] input = File.ReadAllLines("C:\\Dev\\AoC2025\\Day5\\test.txt");

            foreach (string line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var parts = line.Split('-');
                ranges.Add((long.Parse(parts[0]), long.Parse(parts[1])));
            }

            ranges = ranges.OrderBy(r => r.x).ToList();
            var mergedRanges = new List<(long x, long y)>();
            long currentStart = ranges[0].x;
            long currentEnd = ranges[0].y;

            foreach(var range in ranges[1..])
            {
                if (range.x <= currentEnd + 1)
                {
                    currentEnd = Math.Max(currentEnd, range.y);
                }
                else
                {
                    mergedRanges.Add((currentStart, currentEnd));
                    currentStart = range.x;
                    currentEnd = range.y;
                }
            }

            mergedRanges.Add((currentStart, currentEnd));

            foreach (var range in mergedRanges)
            {
                long length = (range.y - range.x) + 1;
                fresh += length;
            }

            Console.WriteLine(fresh);
        }
    }
}
