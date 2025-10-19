interface IButton { void Paint(); }
interface ICheckbox { void Paint(); }

class WinButton : IButton { public void Paint() => Console.WriteLine("Windows Button"); }
class WinCheckbox : ICheckbox { public void Paint() => Console.WriteLine("Windows Checkbox"); }

interface IGUIFactory { IButton CreateButton(); ICheckbox CreateCheckbox(); }

class WinFactory : IGUIFactory
{
    public IButton CreateButton() => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}

class Program
{
    static void Main()
    {
        var factory = new WinFactory();
        factory.CreateButton().Paint();
        factory.CreateCheckbox().Paint();
    }
}

