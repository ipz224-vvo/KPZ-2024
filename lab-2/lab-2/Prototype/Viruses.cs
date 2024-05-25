namespace lab_2.Prototype;

public class RNAVirus : Virus
{
    public RNAVirus(string name, int age, double weight, string type)
        : base(name, age, weight, type)
    {
    }

    public override object Clone()
    {
        RNAVirus clone = (RNAVirus)this.MemberwiseClone();
        clone.Children = new List<Virus>();
        foreach (var child in Children)
        {
            clone.Children.Add(child.Clone() as Virus);
        }

        return clone;
    }
}

public class DNAVirus : Virus
{
    public DNAVirus(string name, int age, double weight, string type)
        : base(name, age, weight, type)
    {
    }

    public override object Clone()
    {
        DNAVirus clone = (DNAVirus)this.MemberwiseClone();
        clone.Children = new List<Virus>();
        foreach (var child in Children)
        {
            clone.Children.Add(child.Clone() as Virus);
        }

        return clone;
    }
}