Day[] completedDays =
[
    new Day1(),
    new Day2()
];

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

// reduce by one since the array starts at 0
Day targetDay = completedDays[day - 1];
if (targetDay == null)
{
    Console.WriteLine($"Error fetching day {day}");
    return;
}

targetDay.Start();
Console.Read();


int ReadDayInput()
{
    Console.WriteLine($"What day would you like to run? (1-{completedDays.Length})");
    string? input = Console.ReadLine();
    if (input == null || input.Length == 0 ||
        !int.TryParse(input, out day) || day < 1 || day > 12)
    {
        Console.WriteLine("Invalid input.");
        return ReadDayInput();
    }


    return day;
}
