using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Gameplay.Mining.Ore.Systems
{
    public class RespawnOreBranchSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext m_context;

        public RespawnOreBranchSystem(Contexts contexts) : base(contexts.game)
        {
            m_context = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed.Added(), GameMatcher.OreBranch.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed && entity.isOreBranch && entity.hasParent;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var branch in entities)
            {
                var vein = m_context.GetEntityWithId(branch.parent.value);
                if (vein.isDestroyed)
                {
                    continue;
                }
                OreFactory.CreateOreBranch(m_context, vein, branch.position.value);
                
            }
        }
    }
}