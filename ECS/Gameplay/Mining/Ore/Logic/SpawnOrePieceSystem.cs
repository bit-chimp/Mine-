using System.Collections.Generic;
using Entitas;

using UnityEngine;

namespace Mine.ECS.Gameplay.Mining.Ore.Logic
{
    public class SpawnOrePieceSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext m_context;

        public SpawnOrePieceSystem(Contexts contexts) : base(contexts.game)
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
                var orePiece = OreFactory.CreateOrePiece(m_context, branch.position.value);

                var xForce = Random.Range(-5f, 5f);
                var yForce = Random.Range(5f, 9f);
                orePiece.AddExplosiveForce(new Vector2(xForce, yForce));
                orePiece.isCarryable = false;
                orePiece.isOnGround = false;
                var yFallPos = branch.position.value.y + Random.Range(-.6f, -.25f);
                orePiece.AddFallToGround(yFallPos);
            }
        }
    }
}