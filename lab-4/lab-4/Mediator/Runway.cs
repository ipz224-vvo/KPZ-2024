namespace lab_4.Mediator;

class Runway
{
    public readonly Guid Id = Guid.NewGuid();
    public bool IsBusy { get; set; }

    public void HighLightRed()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Runway {this.Id} is busy!");
        Console.ResetColor();
    }

    public void HighLightGreen()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Runway {this.Id} is free!");
        Console.ResetColor();
    }
}