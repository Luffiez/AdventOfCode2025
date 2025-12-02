using System.Reflection.Metadata.Ecma335;
using System.Text;

public class Day2 : Day
{
    // https://adventofcode.com/2025/day/2
    public override string Name => "--- Day 2: Gift Shop ---";
    public override int Date => 2;

    //string example = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

    public override void Run()
    {
        long[,] ranges = GetRanges();
        long part1Sum = 0;
        long part2Sum = 0;

        for (int i = 0; i < ranges.Length/2; i++)
        {
            long min = ranges[i, 0];
            long max = ranges[i, 1];
            ConsoleHelper.WriteColoredText($"{min}-{max}", ConsoleColor.Yellow);

            for (long j = min; j <= max; j++)
            {
                string jText = j.ToString();
                if (!Part1_ValidityCheck(j, jText))
                {
                    part1Sum += j;
                    ConsoleHelper.WriteColoredText(j + " <- Invalid Sequence (Part 1)", ConsoleColor.DarkRed);
                    continue;
                }

                if(!Part2_ValidityCheck(part2Sum, j, jText))
                {
                    part2Sum += j;
                    ConsoleHelper.WriteColoredText(j + " <- Invalid Sequence (Part 2)", ConsoleColor.DarkRed);
                    continue;
                }
            }
        }

        result = "Part 1 Sum: " + part1Sum + ", Part 2 Sum: " + (part1Sum + part2Sum);
    }

    private bool Part1_ValidityCheck(long j, string jText)
    {
        if (jText.Length % 2 != 0)
            return true;

        int halfLength = jText.Length / 2;
        string firstHalf = jText.Substring(0, halfLength);
        string secondHalf = jText.Substring(halfLength, halfLength);
        if (!firstHalf.Equals(secondHalf))
            return true;
        
        return false;
    }

    // works with the example input, but not the real input..
    private bool Part2_ValidityCheck(long part2Sum, long j, string jText)
    {
        if (jText.Length < 2)
            return false;

        for (int k = 1; k < jText.Length; k++)
        {
            if (k > jText.Length)
                break;

            string a = jText.Substring(0, k);
            string b = "";
            for (int l = 0; l < jText.Length / k; l++)
                b += a;
            if (jText.Equals(b))
                return false;
        }

        return true;
    }

    private long[,] GetRanges()
    {
        string[] splits = input[0].Split(',');
        //string[] splits = example.Split(',');
        long[,] ranges = new long[splits.Length, 2];
        for (int i = 0; i < splits.Length; i++)
        {
            string[] parts = splits[i].Split('-');
            ranges[i, 0] = long.Parse(parts[0]);
            ranges[i, 1] = long.Parse(parts[1]);
        }
        return ranges;
    }
}
