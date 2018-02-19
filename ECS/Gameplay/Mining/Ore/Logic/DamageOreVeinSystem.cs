﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Gameplay.Mining.Ore.Systems
{
    public class DamageOreVeinSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext m_context;

        public DamageOreVeinSystem(Contexts contexts) : base(contexts.game)
        {
            m_context = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Destroyed, GameMatcher.OreBranch));
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
                vein.health.value -= 1;
                vein.ReplaceHealth(vein.health.value, vein.health.total);
            }
        }
    }
}