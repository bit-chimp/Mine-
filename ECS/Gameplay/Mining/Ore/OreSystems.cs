
using Mine.ECS.Gameplay.Mining.Ore.Logic;

namespace Mine.ECS.Gameplay.Mining.Ore
{
    public class OreSystems : Feature
    {
        public OreSystems(Contexts contexts) : base("Ore Systems")
        {
            //TODO : Figure out why a branch is remaining when destroying ore vein
            Add(new DamageOreVeinSystem(contexts));
            Add(new SpawnOrePieceSystem(contexts));
            Add(new CreateOreBranchSystem(contexts));
            Add(new RespawnOreBranchSystem(contexts));
            Add(new MouseCollectOrePiecesSystem(contexts));
        }
    }
}