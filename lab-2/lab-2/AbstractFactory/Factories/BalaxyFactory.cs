namespace lab_2.AbstractFactory.Factories;

public class BalaxyFactory : DeviceFactory
{
    public override Laptop CreateLaptop()
    {
        return new BalaxyLaptop();
    }

    public override Netbook CreateNetbook()
    {
        return new BalaxyNetbook();
    }

    public override EBook CreateEBook()
    {
        return new BalaxyEBook();
    }

    public override Smartphone CreateSmartphone()
    {
        return new BalaxySmartphone();
    }
}

public class BalaxyLaptop : Laptop
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Balaxy Laptop.");
    }
}

public class BalaxyNetbook : Netbook
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Balaxy Netbook.");
    }
}

public class BalaxyEBook : EBook
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Balaxy EBook.");
    }
}

public class BalaxySmartphone : Smartphone
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Balaxy Smartphone.");
    }
}