using System.Collections.Generic;
using Entitas;



namespace Mine.ECS.Gameplay.Mining.Ore.Logic
{
    public class RemoveOreVeinSystem : ReactiveSystem<GameEntity>
    {
        private GameContext m_context;

        public RemoveOreVeinSystem(Contexts contexts) : base(contexts.game)
        {
            m_context = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isOreVein;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                //Get all branches that depend on me
            }
        }
    }
}