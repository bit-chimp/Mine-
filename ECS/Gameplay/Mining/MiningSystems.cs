using Assets.Sources.Gameplay.Mining.Miner;
using Assets.Sources.Gameplay.Mining.Ore;

namespace Assets.Sources.Gameplay.Mining
{
    public class MiningSystems : Feature
    {
        public MiningSystems(Contexts contexts)
        {
            Add(new OreSystems(contexts));
        }
    }
}