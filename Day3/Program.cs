using System.Globalization;
using System.IO;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
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
    }
}
