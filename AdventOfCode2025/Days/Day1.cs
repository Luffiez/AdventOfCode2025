public class Day1 : Day
{
    // https://adventofcode.com/2025/day/1
    public override string Name => "--- Day 1: Secret Entrance ---";
    public override int Date => 1;

    int minValue = 0;
    int maxValue = 99;

    public override void Run()
    {
        int current = 50;
        int password = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int value = GetValue(input[i]);
            current += value;    

            while (current < minValue)
                current = (maxValue + 1) + current; 

            while (current > maxValue)
                current = current - (maxValue + 1);

            if (current == 0)
                password++;
        }
        result = "Password: " + password;
    }

    int GetValue(string v)
    {
        int value = int.Parse(v.Substring(1));
        return v[0] == 'L' ? -value : value;
    }
}
