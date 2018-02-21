public sealed class UISystems : Feature
{
    public UISystems(Contexts contexts) : base("UI Systems")
    {
        Add(new CreateHealthBarsSystem(contexts));
    }
}