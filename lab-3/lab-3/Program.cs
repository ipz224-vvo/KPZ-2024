using lab_3.Adapter;
using lab_3.Bridge;
using lab_3.Decorator;

namespace lab_3;

class Program
{
    static void Main(string[] args)
    {
        #region Adapter
        Console.WriteLine("***** Adapter *****");
        Logger logger = new Logger();
        logger.Log("This is a log message");
        logger.Error("This is an error message");
        logger.Warn("This is a warning message");

        FileWriter fileWriter = new FileWriter();
        LoggerAdapter loggerAdapter = new LoggerAdapter(fileWriter);
        loggerAdapter.Log("This is a log message");
        loggerAdapter.Error("This is an error message");
        loggerAdapter.Warn("This is a warning message");
        
        Console.WriteLine("***** End of adapter *****");
        #endregion

        #region Decorator
        Console.WriteLine("***** Decorator *****");

        Hero warrior = new Warrior();
        warrior.Attack();

        warrior = new SwordDecorator(warrior);
        warrior.Attack();

        warrior = new ShieldDecorator(warrior);
        warrior.Attack();

        warrior = new AmuletDecorator(warrior);
        warrior.Attack();

        Console.WriteLine();

        Hero mage = new Mage();
        mage.Attack();

        mage = new SwordDecorator(mage);
        mage.Attack();

        mage = new AmuletDecorator(mage);
        mage.Attack();

        Console.WriteLine();

        Hero paladin = new Paladin();
        paladin.Attack();

        paladin = new ShieldDecorator(paladin);
        paladin.Attack();

        paladin = new AmuletDecorator(paladin);
        paladin.Attack();
        Console.WriteLine("***** End of decorator *****");
        #endregion

        #region Bridge
        Console.WriteLine("***** Decorator *****");
        Renderer vectorRenderer = new VectorRenderer();
        Renderer rasterRenderer = new RasterRenderer();

        Shape circle = new Circle(vectorRenderer);
        circle.Draw();
        circle.Resize(2.5f);

        circle = new Circle(rasterRenderer);
        circle.Draw();
        circle.Resize(2.5f);

        Shape square = new Square(vectorRenderer);
        square.Draw();
        square.Resize(2.5f);

        square = new Square(rasterRenderer);
        square.Draw();
        square.Resize(2.5f);

        Shape triangle = new Triangle(vectorRenderer);
        triangle.Draw();
        triangle.Resize(2.5f);

        triangle = new Triangle(rasterRenderer);
        triangle.Draw();
        triangle.Resize(2.5f);
        Console.WriteLine("***** End of decorator *****");
        #endregion
    }
}