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
    }
}