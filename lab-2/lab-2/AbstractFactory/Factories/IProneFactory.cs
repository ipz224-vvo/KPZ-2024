namespace lab_2.AbstractFactory.Factories;

public class IProneFactory : DeviceFactory
{
    public override Laptop CreateLaptop()
    {
        return new IProneLaptop();
    }

    public override Netbook CreateNetbook()
    {
        return new IProneNetbook();
    }

    public override EBook CreateEBook()
    {
        return new IProneEBook();
    }

    public override Smartphone CreateSmartphone()
    {
        return new IProneSmartphone();
    }
}

public class IProneLaptop : Laptop
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is an IProne Laptop.");
    }
}

public class IProneNetbook : Netbook
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is an IProne Netbook.");
    }
}

public class IProneEBook : EBook
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is an IProne EBook.");
    }
}

public class IProneSmartphone : Smartphone
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is an IProne Smartphone.");
    }
}