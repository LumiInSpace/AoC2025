using System.Runtime.CompilerServices;
using System.IO;

namespace Day1
{
    public class Program
    {
        public readonly static string InputFile = "C:\\Dev\\AoC2025\\Day1\\input.txt";
        public static Dictionary<int, int> NumberOfDigits { get; set; } = new Dictionary<int, int>();
        public static int CurrentPosition { get; set; } = 50;

        public static int Oversprings { get; set; } = 0;

        static void Main(string[] args)
        {
            string[] fileContent = File.ReadAllLines(InputFile);
            fileContent = fileContent
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();

            for (int i = 0; i < fileContent.Length; i++)
            {
                char[] chars = fileContent[i].ToCharArray();
                char direction = chars[0];
                int value = 0;

                value = int.Parse(new string(chars, 1, chars.Length - 1));

                if (direction == 'L')
                {
                    Oversprings += (int)(Math.Floor((decimal)CurrentPosition / value) - Math.Floor(((decimal)CurrentPosition - value) / 100));
                    CurrentPosition -= value;
                    CurrentPosition = (((CurrentPosition % 100) + 100) % 100);
                }
                else
                {
                    Oversprings += (int)(Math.Floor(((decimal)CurrentPosition + value) / 100) - Math.Floor(((decimal)CurrentPosition / 100)));
                    CurrentPosition += value;
                    CurrentPosition = (((CurrentPosition % 100) +100) % 100);
                }


                if (NumberOfDigits.ContainsKey(CurrentPosition) && NumberOfDigits.TryGetValue(CurrentPosition, out int currentValue))
                {
                    NumberOfDigits[CurrentPosition] = ++currentValue;
                }
                else
                {
                    NumberOfDigits.Add(CurrentPosition, 1);
                }
            }

            Console.WriteLine(NumberOfDigits.Values.Max());
            NumberOfDigits.TryGetValue(0, out int amount);
            Console.WriteLine((Oversprings + amount).ToString());
        }
    }
}
