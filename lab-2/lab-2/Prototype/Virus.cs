using System.Text;
using System.Threading.Channels;

namespace lab_2.Prototype;

public abstract class Virus : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Type { get; set; }
    public List<Virus> Children { get; set; }

    public static Action<string, int> PrintLine = (text, index) => { Console.WriteLine(text); };

    public Virus(string name, int age, double weight, string type)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Type = type;
        Children = new List<Virus>();
    }

    public abstract object Clone();

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public void PrintVirusInfo(int tabIndex = 0)
    {
        PrintLine($"Name: {Name}, Age: {Age}, Weight: {Weight}, Type: {Type}", tabIndex);
        if (Children.Count > 0)
        {
            PrintLine($"{Name} childrens:", tabIndex + 1);
            foreach (var child in Children)
            {
                child.PrintVirusInfo(tabIndex + 1);
            }
            //WriteInConsole($"End of {Name} childrens.",tabIndex+1);
        }
    }
}