
using Mine.ECS.Gameplay.Mining.Ore;

namespace Mine.ECS.Gameplay.Mining
{
    public class MiningSystems : Feature
    {
        public MiningSystems(Contexts contexts)
        {
            Add(new OreSystems(contexts));
        }
    }
}