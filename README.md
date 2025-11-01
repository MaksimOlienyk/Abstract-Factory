# Abstract Factory — Патерн Проєктування

Цей приклад демонструє шаблон **Abstract Factory** у мові C#.

**Abstract Factory** дозволяє створювати *сімейства пов’язаних об’єктів*, не вказуючи їхніх конкретних класів.

---

## Ідея патерна

> Клієнтський код працює з **фабрикою**, яка створює групу узгоджених об’єктів.  
> Які саме конкретні об’єкти будуть створені — визначає реалізація фабрики.

Це дозволяє:
- легко перемикати стилі, платформи або конфігурації;
- тримати об’єкти узгодженими між собою (кнопка + чекбокс для однієї ОС);
- уникати залежності від конкретних класів.

---

## Структура

| Роль | Опис |
|------|------|
| `IButton`, `ICheckbox` | Абстракції продуктів |
| `WinButton`, `WinCheckbox` | Конкретні продукти для Windows |
| `IGUIFactory` | Абстрактна фабрика — створює сімейство продуктів |
| `WinFactory` | Конкретна фабрика — створює елементи стилю Windows |

---

## Код

```csharp
interface IButton { void Paint(); }
interface ICheckbox { void Paint(); }

class WinButton : IButton { public void Paint() => Console.WriteLine("Windows Button"); }
class WinCheckbox : ICheckbox { public void Paint() => Console.WriteLine("Windows Checkbox"); }

interface IGUIFactory {
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

class WinFactory : IGUIFactory {
    public IButton CreateButton() => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}

class Program {
    static void Main() {
        var factory = new WinFactory();
        factory.CreateButton().Paint();
        factory.CreateCheckbox().Paint();
    }
}
## 

## Приклад розширення
class MacButton : IButton { public void Paint() => Console.WriteLine("Mac Button"); }
class MacCheckbox : ICheckbox { public void Paint() => Console.WriteLine("Mac Checkbox"); }

class MacFactory : IGUIFactory {
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

