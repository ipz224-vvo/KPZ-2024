﻿using lab_5.LightHTML;

namespace lab_5.Command;

public class CommandDemo
{
    public static void Demo()
    {
        LightElementNode html = new("html", DisplayType.Block, ClosingType.Double);
        LightElementNode head = new("head", DisplayType.Block, ClosingType.Double);
        LightElementNode title = new("title", DisplayType.Block, ClosingType.Double);
        LightTextNode titleText = new("Observer");
        AddChildCommand addChildCommand = new(titleText);
        addChildCommand.Execute(title);
        addChildCommand = new(title);
        addChildCommand.Execute(head);
        addChildCommand = new(head);
        addChildCommand.Execute(html);

        LightElementNode body = new("body", DisplayType.Block, ClosingType.Double);
        LightElementNode div = new("div", DisplayType.Block, ClosingType.Double);
        LightTextNode divText = new("TEST");
        div.AddChild(divText);

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
        Console.WriteLine(html.OuterHTML);
        File.WriteAllText("command.html", html.OuterHTML);
    }
}