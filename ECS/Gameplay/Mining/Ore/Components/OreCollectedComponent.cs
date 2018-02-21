using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Mine.ECS.Gameplay.Mining.Ore.Components
{
    [Event(true), Unity]
    public class OreCollectedComponent : IComponent
    {
        public GameEntity entity;
    }
}