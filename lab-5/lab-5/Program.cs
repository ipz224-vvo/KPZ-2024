using lab_4.Strategy;
using lab_5.Visitor;
using lab_5.TemplateMethod;
using lab_5.LightHTML;
using lab_5.State;
using lab_5.Command;
using lab_5.Iterator;

namespace lab_5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("********** Iterator demo **********");
        IteratorDemo.Demo();
        Console.WriteLine("********** Command demo **********");
        CommandDemo.Demo();
        Console.WriteLine("********** State demo **********");
        StateDemo.Demo();
        Console.WriteLine("********** TemplateMethod demo **********");
        TemplateMethodDemo.Demo();
        Console.WriteLine("********** Visitor demo **********");
        VisitorDemo.Demo();
    }
}