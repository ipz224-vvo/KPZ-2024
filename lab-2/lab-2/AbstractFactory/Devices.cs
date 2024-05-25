public abstract class Device
{
    public abstract void ShowInfo();
}

public class Laptop : Device
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Laptop.");
    }
}

public class Netbook : Device
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Netbook.");
    }
}

public class EBook : Device
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is an EBook.");
    }
}

public class Smartphone : Device
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Smartphone.");
    }
}