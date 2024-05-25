using System.Text;
using lab_4.CoR;
using lab_4.Mediator;

namespace lab_4;

class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        /*#region Chain of Responsibility

        Console.WriteLine("***** Chain of Responsibility *****");

        Handler level1 = new Level1Handler();
        Handler level2 = new Level2Handler();
        Handler level3 = new Level3Handler();
        Handler level4 = new Level4Handler();

        level1.SetNext(level2);
        level2.SetNext(level3);
        level3.SetNext(level4);

        bool isProblemSolved = false;
        while (!isProblemSolved)
        {
            Console.Clear();
            isProblemSolved = level1.HandleRequest();
            Console.WriteLine("Натисніть для продовження.");
            Console.ReadLine();
        }

        Console.WriteLine("***** End of Chain of Responsibility *****");

        #endregion*/

        #region Mediator

        Console.WriteLine("***** Mediator *****");

        var runway1 = new Runway();
        var runway2 = new Runway();
        var commandCenter = new CommandCenter(new Dictionary<Runway, Aircraft>
            { { runway1, null }, { runway2, null } });
        var aircraft1 = new Aircraft("Aircraft 1", commandCenter);
        var aircraft2 = new Aircraft("Aircraft 2", commandCenter);

        aircraft1.Land(runway1.Id);
        aircraft2.Land(runway1.Id);
        aircraft1.TakeOff(runway1.Id);
        aircraft2.Land(runway1.Id);

        Console.WriteLine("***** End of mediator *****");

        #endregion
    }
}