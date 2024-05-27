using System.Text;
using lab_4.CoR;
using lab_4.LightHTML;
using lab_4.Mediator;
using lab_4.Memento;
using lab_4.Strategy;

namespace lab_4;

class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        #region Chain of Responsibility

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

        #endregion

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

        #region Observer

        Console.WriteLine("***** Observer *****");

        LightElementNode html = new("html", DisplayType.Block, ClosingType.Double);
        LightElementNode head = new("head", DisplayType.Block, ClosingType.Double);
        LightElementNode title = new("title", DisplayType.Block, ClosingType.Double);
        LightTextNode titleText = new("Observer");
        title.AddChild(titleText);
        head.AddChild(title);
        html.AddChild(head);
        
        LightElementNode body = new("body", DisplayType.Block, ClosingType.Double);
        LightElementNode div = new("div", DisplayType.Block, ClosingType.Double);
        LightTextNode divText = new("TEST");
        div.AddChild(divText);
        string divScript = "()=>alert(\'Test alert\')";
        div.AddSubscription("click", divScript);
        body.AddChild(div);
        html.AddChild(body);

        Console.WriteLine(html.OuterHTML);
        File.WriteAllText("observer.html", html.OuterHTML);
        
        Console.WriteLine("***** End of observer *****");

        #endregion
        
        #region Strategy

        Console.WriteLine("***** Strategy *****");

        LightElementNode html1 = new("html", DisplayType.Block, ClosingType.Double);
        LightElementNode head1 = new("head", DisplayType.Block, ClosingType.Double);
        LightElementNode title1 = new("title", DisplayType.Block, ClosingType.Double);
        LightTextNode titleText1 = new("Strategy");
        title1.AddChild(titleText1);
        head1.AddChild(title1);
        html1.AddChild(head1);
        
        LightElementNode body1 = new("body", DisplayType.Block, ClosingType.Double);
        LightElementNode div1 = new("div", DisplayType.Block, ClosingType.Double);
        FileSystemImageLoader FileSystemImageLoader = new();
        LightImageNode localImage = new("./../../../Strategy/local_meme.jpg", "local meme", FileSystemImageLoader);
        div1.AddChild(localImage);

        NetworkImageLoader NetworkImageLoader = new();
        string linkToImage =
            "https://programmerhumor.io/wp-content/uploads/2024/05/programmerhumor-io-programming-memes-b5d6340cdc6ef00-758x491.jpg";
        LightImageNode networkImage = new(linkToImage, "network meme", NetworkImageLoader);
        div1.AddChild(networkImage);
        body1.AddChild(div1);
        html1.AddChild(body1);

        Console.WriteLine(html1.OuterHTML);
        File.WriteAllText("strategy.html", html1.OuterHTML);
        
        
        Console.WriteLine("***** End of strategy *****");
        #endregion
        
        #region Memento

        Console.WriteLine("***** Memento *****");

        TextDocument document = new TextDocument("");
        TextEditor editor = new TextEditor(document);

        editor.Type("This is the first sentence. ");
        editor.Print();

        editor.Type("This is second sentence. ");
        editor.Print();

        editor.Undo();
        editor.Print();

        editor.Undo();
        editor.Print();
        
        Console.WriteLine("***** End of memento *****");
        #endregion
    }
}