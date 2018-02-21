
using Mine.ECS.Gameplay.Mining;

namespace Mine.ECS
{
    public sealed class MineSystems : Feature
    {
        public MineSystems(Contexts contexts) : base("Mine Systems")
        {
            Add(new MiningSystems(contexts));
            Add(new AddEntityToRoomSystem(contexts));
            Add(new CreateStartingEntitiesSystem(contexts));
            Add(new UISystems(contexts));
        }
    }
}