namespace AbstractFactoryThemes;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Abstract Factory Demo ===");

        RunTheme(new LightThemeFactory());
        RunTheme(new DarkThemeFactory());
    }

    private static void RunTheme(IGuiFactory factory)
    {
        var app = new Application(factory);

        app.CreateUi();
        app.Paint();

        Console.WriteLine();
    }
}
