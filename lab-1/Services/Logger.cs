using lab_1.Interfaces;
using Spectre.Console;

namespace lab_1.Services;

public class Logger : ILogger
{
    public void Error(string message)
    {
        AnsiConsole.MarkupLine($"[red]Error[/]: {message}");
    }

    public void Info(string message)
    {
        AnsiConsole.MarkupLine($"[green]Info[/]: {message}");
    }

    public void Warning(string message)
    {
        AnsiConsole.MarkupLine($"[yellow]Warning[/]: {message}");
    }
}
