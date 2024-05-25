namespace lab_3.Proxy;

class SmartTextReader
{
    public virtual char[][] ReadFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        return lines.Select(line => line.ToCharArray()).ToArray();
    }
}
