using System.Diagnostics;

public class Day : IDay
{
    public virtual string Name => "";
    public virtual int Date => 0;

    Stopwatch stopwatch = new();

    protected string[] input;
    protected string result;

    public virtual void Start()
    {
        Console.WriteLine(Name);

        Console.WriteLine($"Loading day {Date}'s input data...");
        stopwatch.Start();
        LoadInputData();
        stopwatch.Stop();
        ConsoleHelper.WriteColoredText($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms, Size: {input.Length}.", ConsoleColor.DarkYellow);

        Console.WriteLine($"Running day {Date}'s challange...");
        stopwatch.Restart();
        Run();
        stopwatch.Stop();
        ConsoleHelper.WriteColoredText($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms, {result}", ConsoleColor.Green);
    }

    private void LoadInputData()
    {
        string fileName = Path.Combine(AppContext.BaseDirectory, "Inputs", $"Input_{Date}.txt");
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Error loading input data for day " + Date);
            throw new FileNotFoundException();
        }
        input = File.ReadAllLines(fileName);
    }

    public virtual void Run() => throw new NotImplementedException();
}