using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string[] input = File.ReadAllLines("C:\\Dev\\AoC2025\\Day3\\input.txt");
            int result = 0;

            foreach (string number in input)
            {
                int greatestRight = 0;
                int greatestLeft = 0;

                for (int i = 0; i < number.Length; i++)
                {
                    int leftDigit = number[i] - '0';

                    for (int j = i + 1; j < number.Length; j++)
                    {
                        int rightDigit = number[j] - '0';

                        if (leftDigit > greatestLeft ||
                           (leftDigit == greatestLeft && rightDigit > greatestRight))
                        {
                            greatestLeft = leftDigit;
                            greatestRight = rightDigit;
                        }
                    }
                }

                result += greatestLeft * 10 + greatestRight;
            }

            Console.WriteLine(result);
        }

        public static void Part2()
        {
            string[] input = File.ReadAllLines("C:\\Dev\\AoC2025\\Day3\\input.txt");
            long result = 0;

            foreach(string number in input)
            {
                int start = 0;
                string bestNum = "";

                for (int i = 0; i < 12; i++)
                {
                    int best = 0;
                    int bestPos = 0;

                    for (int j = start; j < number.Length; j++)
                    {
                        int digit = int.Parse(number[j].ToString());

                        if (digit > best && j <= number.Length - (12 - i))
                        {
                            best = digit;
                            bestPos = j;
                        }
                    }

                    start = bestPos + 1;
                    bestNum += best.ToString();
                }

                result += long.Parse(bestNum);
            }

            Console.WriteLine(result);
        }
    }
}