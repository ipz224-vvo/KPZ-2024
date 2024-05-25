namespace lab_2.Builder;

public class Character
{
    public int Height { get; set; }
    public string Build { get; set; }
    public string HairColor { get; set; }
    public string Eyes { get; set; }
    public string Clothes { get; set; }
    public string Equipment { get; set; }
    public List<string> GoodDeeds { get; set; }
    public List<string> EvilDeeds { get; set; }
    public static Action<string, int> PrintLine = (text, index) => { Console.WriteLine(text); };

    public void PrintCharacter()
    {
        Console.WriteLine("Character:");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Build: {Build}");
        Console.WriteLine($"Hair Color: {HairColor}");
        Console.WriteLine($"Eyes: {Eyes}");
        Console.WriteLine($"Clothes: {Clothes}");
        Console.WriteLine($"Equipment: {Equipment}");

        if (GoodDeeds.Count != 0)
        {
            PrintLine("Good Deeds:", 0);
            foreach (var goodDeed in GoodDeeds)
            {
                PrintLine(goodDeed, 1);
            }
        }

        if (EvilDeeds.Count != 0)
        {
            PrintLine("Evil Deeds:", 0);
            foreach (var evilDeed in EvilDeeds)
            {
                PrintLine(evilDeed, 1);
            }
        }
    }
}