using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using lab_3.Adapter;
using lab_3.Bridge;
using lab_3.Composite;
using lab_3.Decorator;
using lab_3.FlyWeight;
using lab_3.Proxy;

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

        Console.WriteLine("***** Bridge *****");
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
        Console.WriteLine("***** End of bridge *****");

        #endregion

        #region Proxy

        Console.WriteLine("***** Proxy *****");

        const string path = "./../../../Proxy/example.txt";
        SmartTextReader reader = new SmartTextReader();
        char[][] content = reader.ReadFile(path);
        foreach (var line in content)
        {
            Console.WriteLine(new string(line));
        }

        Console.WriteLine();

        SmartTextChecker checker = new SmartTextChecker();
        content = checker.ReadFile(path);
        Console.WriteLine("Content of file");
        foreach (var line in content)
        {
            Console.WriteLine(new string(line));
        }

        Console.WriteLine("End of file");

        Console.WriteLine();

        SmartTextReaderLocker locker = new SmartTextReaderLocker(".txt$");
        content = locker.ReadFile(path);
        if (content.Length == 0)
        {
            Console.WriteLine("Access was denied!");
        }
        else
        {
            Console.WriteLine("Content of file");
            foreach (var line in content)
            {
                Console.WriteLine(new string(line));
            }

            Console.WriteLine("End of file");
        }

        Console.WriteLine("***** End of proxy *****");

        #endregion

        #region Composite

        Console.WriteLine("***** Composite *****");

        LightElementNode table = new LightElementNode("table", DisplayType.Block, ClosingType.Double,
            new List<string> { "table", "table-bordered" });


        LightElementNode thead =
            new LightElementNode("thead", DisplayType.Block, ClosingType.Double, new List<string>());
        LightElementNode tr = new LightElementNode("tr", DisplayType.Row, ClosingType.Double, new List<string>());
        LightElementNode th = new LightElementNode("th", DisplayType.Block, ClosingType.Double, new List<string>());
        LightTextNode header1 = new LightTextNode("Column 1");
        th.AddChild(header1);
        tr.AddChild(th);

        LightTextNode header2 = new LightTextNode("Column 2");
        th.ClearChilds();
        th.AddChild(header2);
        tr.AddChild(th);
        thead.AddChild(tr);
        table.AddChild(thead);


        LightElementNode tbody =
            new LightElementNode("tbody", DisplayType.Block, ClosingType.Double, new List<string>());
        tr.ClearChilds();
        LightElementNode td = new LightElementNode("td", DisplayType.Block, ClosingType.Double, new List<string>());
        LightTextNode content1 = new LightTextNode("Cell 1");
        td.AddChild(content1);
        tr.AddChild(td);
        LightTextNode content2 = new LightTextNode("Cell 2");
        td.ClearChilds();
        td.AddChild(content2);
        tr.AddChild(td);
        tbody.AddChild(tr);
        table.AddChild(tbody);

        Console.WriteLine(table.OuterHTML);

        Console.WriteLine("***** End of composite *****");

        #endregion

        #region FlyWeight

        Console.WriteLine("***** Flyweight *****");

        LightElementFactory factory = new LightElementFactory();
        factory.ChangeToOptimized();
        FormStructure();
        var proc = Process.GetCurrentProcess();
        Console.WriteLine($"With flyweight pattern: {proc.PrivateMemorySize64} bytes");

        GC.Collect(0);
        factory.ChangeToUnOptimized();
        FormStructure();
        proc = Process.GetCurrentProcess();
        Console.WriteLine($"Without flyweight pattern: {proc.PrivateMemorySize64} bytes");


        Console.WriteLine("***** End of flyweight *****");

        void FormStructure()
        {
            string[] bookLines = File.ReadAllLines("./../../../FlyWeight/gutenberg.txt");

            LightElementNode div =
                factory.GetElement("div", DisplayType.Block, ClosingType.Double, new List<string>(), "");

            bool isFirstLine = true;
            foreach (var line in bookLines)
            {
                LightElementNode elementNode;
                if (isFirstLine)
                {
                    elementNode = factory.GetElement("h1", DisplayType.Block, ClosingType.Double, new List<string>(),
                        line);
                    isFirstLine = false;
                }
                else if (line.Length < 20 && line != "")
                {
                    elementNode = factory.GetElement("h2", DisplayType.Block, ClosingType.Double, new List<string>(),
                        line);
                }
                else if (line.StartsWith(" "))
                {
                    elementNode = factory.GetElement("blockquote", DisplayType.Block, ClosingType.Double,
                        new List<string>(), line);
                }
                else
                {
                    elementNode = factory.GetElement("p", DisplayType.Block, ClosingType.Double, new List<string>(),
                        line);
                }

                div.AddChild(elementNode);
            }

            LightElementNode html =
                new LightElementNode("html", DisplayType.Block, ClosingType.Double, new List<string>());
            LightElementNode title =
                new LightElementNode("title", DisplayType.Block, ClosingType.Double, new List<string>());
            LightElementNode head =
                new LightElementNode("head", DisplayType.Block, ClosingType.Double, new List<string>());
            LightTextNode titleText = new LightTextNode("Lab06");
            title.AddChild(titleText);
            head.AddChild(title);
            LightElementNode body =
                new LightElementNode("body", DisplayType.Block, ClosingType.Double, new List<string>());
            body.AddChild(div);
            html.AddChild(head);
            html.AddChild(body);
            File.WriteAllText("flyweight.html", html.OuterHTML);
        }

        #endregion
    }
}