using System.Text.RegularExpressions;

namespace lab_3.Proxy;

class SmartTextReaderLocker : SmartTextReader
{
    private Regex regex;

    public SmartTextReaderLocker(string pattern)
    {
        regex = new Regex(pattern);
    }

    public override char[][] ReadFile(string filePath)
    {
        if (!regex.IsMatch(filePath)) 
            return base.ReadFile(filePath);
        Console.WriteLine("Access denied!");
        return [];
    }
}
