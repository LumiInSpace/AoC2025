using System.Reflection.Metadata.Ecma335;

namespace Day2
{
    internal class Program
    {
        public static string InputFilePath = "C:\\Dev\\AoC2025\\Day2\\input.txt";
        public static long result = 0;

        static void Main(string[] args)
        {
            string input = File.ReadAllText(InputFilePath);
            string[] ranges = input.Split(",");

            foreach (var range in ranges)
            {
                var parts = range.Split('-');

                for (long i = long.Parse(parts[0]); i < long.Parse(parts[1]); i++)
                {
                    int length = i.ToString().Length;
                    List<int> dividers = new List<int>();
                    for (int j = 1; j < length; j++)
                    {
                        if (length % j == 0)
                        {
                            dividers.Add(j);
                        }
                    }

                    foreach (var divider in dividers)
                    {
                        List<int> blocks = new List<int>();
                        Dictionary<int, int> comparisonTable = new Dictionary<int, int>();

                        for (int j = 0; j < i.ToString().Length / divider; j++)
                        {
                            blocks.Add(int.Parse(i.ToString().Substring(j * divider, divider)));
                        }

                        for (int j = 0; j < blocks.Count; j++)
                        {
                            if (comparisonTable.ContainsKey(blocks[j])  == false) { comparisonTable[blocks[j]] = 1; }
                            else {  comparisonTable[blocks[j]]++; }
                        }

                        if(comparisonTable.Keys.Count == 1 && comparisonTable.Values.First() >= 2)
                        {
                            result += i;
                            break;
                        }
                    }
                }
            }
            
            Console.WriteLine(result);
        }
    }
}
