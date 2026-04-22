namespace AbstractFactoryThemes;

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
