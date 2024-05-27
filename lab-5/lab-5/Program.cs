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
        IteratorDemo.Demo();
        CommandDemo.Demo();
        StateDemo.Demo();
        TemplateMethodDemo.Demo();
        VisitorDemo.Demo();
    }
}