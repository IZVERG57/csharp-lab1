namespace AbstractFactoryThemes;

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
