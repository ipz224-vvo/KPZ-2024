namespace lab_3.Adapter;

class LoggerAdapter : Logger
{
    private FileWriter fileWriter;

    public LoggerAdapter(FileWriter fileWriter)
    {
        this.fileWriter = fileWriter;
    }

    public override void Log(string message)
    {
        fileWriter.WriteLine(message);
    }

    public override void Error(string message)
    {
        fileWriter.WriteLine("Error: " + message);
    }

    public override void Warn(string message)
    {
        fileWriter.WriteLine("Warning: " + message);
    }
}