using Assets.Sources.Gameplay.Mining;

public sealed class MineSystems : Feature
{
    public MineSystems(Contexts contexts) : base("Mine Systems")
    {
        Add(new MiningSystems(contexts));
    }
}