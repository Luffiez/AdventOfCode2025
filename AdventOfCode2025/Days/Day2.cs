public class Day2 : Day
{
    // https://adventofcode.com/2025/day/2
    public override string Name => "--- Day 2: Gift Shop ---";
    public override int Date => 2;

    public override void Run()
    {
        long[,] ranges = GetRanges();
        long invalidSum = 0;
        for (int i = 0; i < ranges.Length/2; i++)
        {
            long min = ranges[i, 0];
            long max = ranges[i, 1];
            ConsoleHelper.WriteColoredText($"{min}-{max}", ConsoleColor.Yellow);
            for (long j = min; j <= max; j++)
            {
                string jText = j.ToString();
                if (jText.Length % 2 == 0)
                {
                    int halfLength = jText.Length / 2;
                    string firstHalf = jText.Substring(0, halfLength);
                    string secondHalf = jText.Substring(halfLength, halfLength);

                    if (firstHalf.Equals(secondHalf))
                    {
                        ConsoleHelper.WriteColoredText(j + " <- Invalid Sequence", ConsoleColor.DarkRed);
                        invalidSum += j;
                        continue;
                    }
                }
            }
        }

        result = "Invalid sum: " + invalidSum;
    }

    private long[,] GetRanges()
    {
        string[] splits = input[0].Split(',');
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
