namespace lab_2.AbstractFactory.Factories;

public class KiaomiFactory : DeviceFactory
{
    public override Laptop CreateLaptop()
    {
        return new KiaomiLaptop();
    }

    public override Netbook CreateNetbook()
    {
        return new KiaomiNetbook();
    }

    public override EBook CreateEBook()
    {
        return new KiaomiEBook();
    }

    public override Smartphone CreateSmartphone()
    {
        return new KiaomiSmartphone();
    }
}

public class KiaomiLaptop : Laptop
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Kiaomi Laptop.");
    }
}

public class KiaomiNetbook : Netbook
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Kiaomi Netbook.");
    }
}

public class KiaomiEBook : EBook
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Kiaomi EBook.");
    }
}

public class KiaomiSmartphone : Smartphone
{
    public override void ShowInfo()
    {
        Console.WriteLine("This is a Kiaomi Smartphone.");
    }
}