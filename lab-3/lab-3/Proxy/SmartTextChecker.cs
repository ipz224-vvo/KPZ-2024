namespace lab_3.Proxy;

class SmartTextChecker : SmartTextReader
{
    public override char[][] ReadFile(string filePath)
    {
        Console.WriteLine($"Opening file {filePath}");
        char[][] result = base.ReadFile(filePath);
        Console.WriteLine($"File {filePath} read successfully");
        Console.WriteLine($"Total lines: {result.Length}, total characters: {result.Sum(line => line.Length)}");
        Console.WriteLine($"Closing file {filePath}");
        return result;
    }
}