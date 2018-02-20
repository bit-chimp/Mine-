
using Mine.ECS.Gameplay.Mining;

namespace Mine.ECS
{
    public sealed class MineSystems : Feature
    {
        public MineSystems(Contexts contexts) : base("Mine Systems")
        {
            Add(new MiningSystems(contexts));
        }
    }
}