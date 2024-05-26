using lab_5.LightHTML;
using lab_5.State;

namespace lab_5;

class Program
{
    static void Main(string[] args)
    {
        LightElementNode html = new("html", DisplayType.Block, ClosingType.Double);
        LightElementNode head = new("head", DisplayType.Block, ClosingType.Double);
        LightElementNode title = new("title", DisplayType.Block, ClosingType.Double);
        LightTextNode titleText = new("State");
        title.AddChild(titleText);
        head.AddChild(title);
        html.AddChild(head);
        
        LightElementNode body = new("body", DisplayType.Block, ClosingType.Double);
        LightElementNode div = new("div", DisplayType.Block, ClosingType.Double);
        LightTextNode divText = new("TEST");
        div.AddChild(divText);
        string divScript = "()=>alert(\'Test alert\')";
        div.AddSubscription("click", divScript);
        
        LightElementNode div2 = new("div", DisplayType.Block, ClosingType.Double);
        LightTextNode divText2 = new("TEST2");
        div2.AddChild(divText2);
        
        LightElementNode div3 = new("div", DisplayType.Block, ClosingType.Double);
        LightTextNode divText3 = new("TEST3");
        div3.AddChild(divText3);

        LightElementNode div4 = new("div", DisplayType.Block, ClosingType.Double);
        LightTextNode divText4 = new("TEST4");
        div4.AddChild(divText4);
        

        LightElementNode divMain1 = new("div", DisplayType.Block, ClosingType.Double);
        divMain1.AddChild(div);
        divMain1.AddChild(div2);

        LightElementNode divMain2 = new("div", DisplayType.Block, ClosingType.Double);
        divMain2.AddChild(div3);
        divMain2.AddChild(div4);
        
        body.AddChild(divMain1);
        body.AddChild(divMain2);
        html.AddChild(body);
        
        LightElementNode footer = new("footer", DisplayType.Block, ClosingType.Double);
        LightElementNode footerParagraph = new("p", DisplayType.Block, ClosingType.Double);
        LightTextNode footerText = new("Footer text.");
        footerParagraph.AddChild(footerText);
        footer.AddChild(footerParagraph);
        
        html.State = ClosedState.GetInstance();
        try
        {
            html.AddChild(footer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine(html.OuterHTML);
        File.WriteAllText("state.html", html.OuterHTML);
        
        html.State = OpenState.GetInstance();
        try
        {
            html.AddChild(footer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine(html.OuterHTML);
        File.WriteAllText("state.html", html.OuterHTML);
    }
}