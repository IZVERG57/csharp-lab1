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
