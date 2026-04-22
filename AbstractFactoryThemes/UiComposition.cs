namespace AbstractFactoryThemes;

public sealed class Application
{
    private readonly IGuiFactory _factory;
    private IButton? _button;
    private ICheckbox? _checkbox;

    public Application(IGuiFactory factory)
    {
        _factory = factory;
    }

    public void CreateUi()
    {
        _button = _factory.CreateButton();
        _checkbox = _factory.CreateCheckbox();
    }

    public void Paint()
    {
        if (_button is null || _checkbox is null)
        {
            throw new InvalidOperationException("CreateUi must be called before Paint.");
        }

        _button.Render();
        _checkbox.Render();
    }
}

public interface IGuiFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public sealed class LightThemeFactory : IGuiFactory
{
    public IButton CreateButton() => new LightButton();

    public ICheckbox CreateCheckbox() => new LightCheckbox();
}

public sealed class DarkThemeFactory : IGuiFactory
{
    public IButton CreateButton() => new DarkButton();

    public ICheckbox CreateCheckbox() => new DarkCheckbox();
}

public interface IButton
{
    string ThemeName { get; }
    string TextColor { get; }
    void Render();
}

public interface ICheckbox
{
    string ThemeName { get; }
    string MarkColor { get; }
    void Render();
}

public sealed class LightButton : IButton
{
    public string ThemeName => "Light";
    public string TextColor => "Black";

    public void Render()
    {
        Console.WriteLine($"[{ThemeName}] Button: text color = {TextColor}");
    }
}

public sealed class DarkButton : IButton
{
    public string ThemeName => "Dark";
    public string TextColor => "White";

    public void Render()
    {
        Console.WriteLine($"[{ThemeName}] Button: text color = {TextColor}");
    }
}

public sealed class LightCheckbox : ICheckbox
{
    public string ThemeName => "Light";
    public string MarkColor => "Dark Gray";

    public void Render()
    {
        Console.WriteLine($"[{ThemeName}] Checkbox: mark color = {MarkColor}");
    }
}

public sealed class DarkCheckbox : ICheckbox
{
    public string ThemeName => "Dark";
    public string MarkColor => "Light Gray";

    public void Render()
    {
        Console.WriteLine($"[{ThemeName}] Checkbox: mark color = {MarkColor}");
    }
}
