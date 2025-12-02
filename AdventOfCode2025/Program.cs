using System.Drawing;

ConsoleHelper.WriteColoredText("Advent of Code 2025", ConsoleColor.Green);
Console.WriteLine("By Erik Rodriguez");
Console.WriteLine("-------------------");

int day = DateTime.UtcNow.Day;
int month = DateTime.UtcNow.Month;
int year = DateTime.UtcNow.Year;


if (year != 2025 || month != 12 || day > 12)
    day = ReadDayInput();
else
{
    Console.WriteLine($"Display todays challenge, day {day}? (Y/N)");
    string? input = Console.ReadLine();
    if(input != null && input.ToUpperInvariant() == "N")
        day = ReadDayInput();
}


Day targetDay = ParseDayInput(day);
if (targetDay == null)
{
    Console.WriteLine($"Error fetching day {day}");
    return;
}

targetDay.Start();
Console.Read();


int ReadDayInput()
{
    Console.WriteLine("What day would you like to run? (1-12)");
    string? input = Console.ReadLine();
    if (input == null || input.Length == 0 ||
        !int.TryParse(input, out day) || day < 1 || day > 12)
    {
        Console.WriteLine("Invalid input.");
        return ReadDayInput();
    }

    return day;
}

Day ParseDayInput(int day)
{
    switch (day)
    {
        case 1: return new Day1();
        case 2: return new Day2();
        default: return null;
    }
}
