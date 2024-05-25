using System.Text;
using lab_2.AbstractFactory.Factories;
using lab_2.Builder;
using lab_2.FactoryMethod;
using lab_2.Prototype;
using lab_2.Singletone;

namespace lab_2;

class Program
{
    static void Main(string[] args)
    {
        #region Factory method

        Console.WriteLine("******** Factory method ********");
        SubscriptionFactory[] factories =
        [
            new Website(),
            new MobileApp(),
            new ManagerCall()
        ];

        foreach (var factory in factories)
        {
            var subscription = factory.CreateSubscription();
            Console.WriteLine(
                $"Created subscription: {subscription.GetType().Name} with monthly fee: {subscription.MonthlyFee:C} and minimum subscription period: {subscription.MinimumSubscriptionPeriod} months.");
            Console.WriteLine("Channels and features:");
            foreach (var channel in subscription.ChannelsAndFeatures)
            {
                Console.WriteLine(channel);
            }

            Console.WriteLine();
        }

        Console.WriteLine("******** End of factory method ********");

        #endregion

        #region Abstract factory method

        Console.WriteLine("******** Abstract factory method ********");
        DeviceFactory deviceFactory = new IProneFactory();
        var laptop = deviceFactory.CreateLaptop();
        var netbook = deviceFactory.CreateNetbook();
        var ebook = deviceFactory.CreateEBook();
        var smartphone = deviceFactory.CreateSmartphone();

        laptop.ShowInfo();
        netbook.ShowInfo();
        ebook.ShowInfo();
        smartphone.ShowInfo();
        Console.WriteLine();

        deviceFactory = new KiaomiFactory();
        laptop = deviceFactory.CreateLaptop();
        netbook = deviceFactory.CreateNetbook();
        ebook = deviceFactory.CreateEBook();
        smartphone = deviceFactory.CreateSmartphone();

        laptop.ShowInfo();
        netbook.ShowInfo();
        ebook.ShowInfo();
        smartphone.ShowInfo();
        Console.WriteLine();

        deviceFactory = new BalaxyFactory();
        laptop = deviceFactory.CreateLaptop();
        netbook = deviceFactory.CreateNetbook();
        ebook = deviceFactory.CreateEBook();
        smartphone = deviceFactory.CreateSmartphone();

        laptop.ShowInfo();
        netbook.ShowInfo();
        ebook.ShowInfo();
        smartphone.ShowInfo();

        Console.WriteLine("******** End of abstract factory method ********");

        #endregion

        #region Singleton

        Console.WriteLine("******** Singleton ********");
        var authenticator1 = Authenticator.Instance;
        var authenticator2 = Authenticator.Instance;

        if (authenticator1 == authenticator2)
        {
            Console.WriteLine("Both authenticators are the same instance.");
        }
        else
        {
            Console.WriteLine("Both authenticators are different instances.");
        }

        authenticator1.Authenticate();
        authenticator2.Authenticate();

        Console.WriteLine("******** End of Singleton ********");

        #endregion

        #region Prototype

        Console.WriteLine("******** Prototype ********");
        Virus.PrintLine = WriteInConsole;
        RNAVirus grandParent = new("GrandParent", 10, 0.1, "Coronavirus");
        DNAVirus parent1 = new("Parent1", 5, 0.05, "Herpes");
        DNAVirus parent2 = new("Parent2", 5, 0.05, "Smallpox");
        RNAVirus child1 = new("Child1", 2, 0.01, "Picornavirus");
        RNAVirus child2 = new("Child2", 2, 0.01, "Filoviridae");
        DNAVirus grandChild1 = new("GrandChild1", 1, 0.005, "Adenovirus");
        DNAVirus grandChild2 = new("GrandChild2", 1, 0.005, "Wart");

        grandParent.AddChild(parent1);
        grandParent.AddChild(parent2);
        parent1.AddChild(child1);
        parent1.AddChild(child2);
        child1.AddChild(grandChild1);
        child2.AddChild(grandChild2);

        Console.WriteLine("Original Family:");
        grandParent.PrintVirusInfo();

        var clonedGrandParent = (grandParent.Clone() as Virus)!;
        Console.WriteLine("\n----Cloned Family:----");
        clonedGrandParent.PrintVirusInfo();
        Console.WriteLine("******** End of prototype ********");

        #endregion

        #region Builder

        Console.WriteLine("******** Builder ********");
        Character.PrintLine = WriteInConsole;
        Director director = new Director(new HeroBuilder());
        director.CreateHero();
        Character hero = director.GetCharacter();
        hero.PrintCharacter();

        director = new Director(new EnemyBuilder());
        director.CreateEnemy();
        Character enemy = director.GetCharacter();
        enemy.PrintCharacter();

        Console.WriteLine("******** End of builder ********");

        #endregion
    }

    public static void WriteInConsole(string text, int tabIndex = 0)
    {
        StringBuilder tabs = new();
        for (int i = 0; i < tabIndex; i++)
        {
            tabs.Append("\t");
        }

        Console.Write(tabs.ToString());
        Console.WriteLine(text);
    }
}