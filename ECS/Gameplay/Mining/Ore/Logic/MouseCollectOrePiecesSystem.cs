using System.Collections.Generic;
using Entitas;

namespace Mine.ECS.Gameplay.Mining.Ore.Logic
{
    public class MouseCollectOrePiecesSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_context;

        public MouseCollectOrePiecesSystem(Contexts contexts) : base(contexts.game)
        {
            m_context = contexts;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.OrePiece, GameMatcher.MouseInteractHover).NoneOf(GameMatcher.Destroyed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var piece in entities)
            {
                piece.isDestroyed = true;
                
                //TODO: Use event listener rather than placing these calls in same place
                //TODO : Seperate gameplay from notification handling
                foreach (var coll in m_context.unity.GetGroup(UnityMatcher.OreCollectedListener).GetEntities())
                {
                    coll.oreCollectedListener.value.OnOreCollected(piece);
                }
            }
        }
    }
}