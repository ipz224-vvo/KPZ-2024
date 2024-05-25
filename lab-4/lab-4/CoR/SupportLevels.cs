namespace lab_4.CoR;

public abstract class Handler
{
    protected Handler _nextHandler;

    public void SetNext(Handler next)
    {
        this._nextHandler = next;
    }

    public virtual bool HandleRequest()
    {
        if (_nextHandler != null)
        {
            var result = _nextHandler?.HandleRequest();
            return result ?? false;
        }

        return false;
    }
}

public class Level1Handler : Handler
{
    public override bool HandleRequest()
    {
        Console.WriteLine("У Вас проблема з телефоном?");
        Console.WriteLine("1. Так");
        Console.WriteLine("2. Ні");
        Console.WriteLine("0. Проблема вирішена.");
        Console.Write("Оберіть одну з опцій: ");
        int userChoice = Convert.ToInt32(Console.ReadLine());
        switch (userChoice)
        {
            case 0:
                return true;
            case 1:
                var result = _nextHandler?.HandleRequest();
                return result ?? false;
            case 2:
                Console.WriteLine("Ви не туди звернулись!");
                return false;
            default:
                Console.WriteLine("В наступний раз оберіть один із !запропонованих! варіантів.");
                return false;
        }
    }
}

public class Level2Handler : Handler
{
    public override bool HandleRequest()
    {
        Console.WriteLine("Чи пробували Ви перезавантажити його?");
        Console.WriteLine("1. Так");
        Console.WriteLine("2. Ні");
        Console.WriteLine("0. Проблема вирішена.");
        Console.Write("Оберіть одну з опцій: ");
        int userChoice = Convert.ToInt32(Console.ReadLine());
        switch (userChoice)
        {
            case 0:
                return true;
            case 1:
                var result = _nextHandler?.HandleRequest();
                return result ?? false;
            case 2:
                Console.WriteLine("Спробуйте перезавантажити!");
                return false;
            default:
                Console.WriteLine("В наступний раз оберіть один із !запропонованих! варіантів.");
                return false;
        }
    }
}

public class Level3Handler : Handler
{
    public override bool HandleRequest()
    {
        Console.WriteLine("Чи падав Ваш телефон?");
        Console.WriteLine("1. Так");
        Console.WriteLine("2. Ні");
        Console.WriteLine("0. Проблема вирішена.");
        Console.Write("Оберіть одну з опцій: ");
        int userChoice = Convert.ToInt32(Console.ReadLine());
        switch (userChoice)
        {
            case 0:
                return true;
            case 1:
                Console.WriteLine("Ну то всьо, треба було в руках тримать нормально");
                return true;
            case 2:
                var result = _nextHandler?.HandleRequest();
                return result ?? false;
            default:
                Console.WriteLine("В наступний раз оберіть один із !запропонованих! варіантів.");
                return false;
        }
    }
}

public class Level4Handler : Handler
{
    public override bool HandleRequest()
    {
        Console.WriteLine("Чи є у Вас дійсна гарантія?");
        Console.WriteLine("1. Так");
        Console.WriteLine("2. Ні");
        Console.WriteLine("0. Проблема вирішена.");
        Console.Write("Оберіть одну з опцій: ");
        int userChoice = Convert.ToInt32(Console.ReadLine());
        switch (userChoice)
        {
            case 0:
                return true;
            case 1:
                Console.WriteLine("З'єдную з оператором...");
                var result = _nextHandler?.HandleRequest();
                return result ?? false;
            case 2:
                Console.WriteLine("То гуляй");
                return false;
            default:
                Console.WriteLine("В наступний раз оберіть один із !запропонованих! варіантів.");
                return false;
        }
    }
}