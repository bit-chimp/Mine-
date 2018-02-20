using System.Collections.Generic;
using Entitas;

using Libraries.btcp.ECS.src.AI.Sensors.Targeting;
using UnityEngine;


namespace Mine.ECS.Gameplay.Mining.Ore.Logic
{
    public class CreateOreBranchSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts m_context;

        public CreateOreBranchSystem(Contexts contexts) : base(contexts.game)
        {
            m_context = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Target.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTarget;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var miner in entities)
            {
                var minerTarget = m_context.game.GetEntityWithId(miner.target.value);

                if (!minerTarget.isOreVein) continue;
                if (minerTarget.isDestroyed) continue;
                var availableBranches = GetVeinAvailableBranches(minerTarget);
                while(availableBranches <= 0)
                {
                    var branchPos = minerTarget.position.value;
                    branchPos.y -= 1f;
                    branchPos.x += Random.Range(-1.5f, 1.5f);
                    OreFactory.CreateOreBranch(m_context.game, minerTarget, branchPos);
                    availableBranches++;
                }
            }
        }

        private int GetVeinAvailableBranches(GameEntity e)
        {
            if (e.hasBag == false) return 0;

            var branches = e.bag.items;
            var availableBranches = branches.Count;

            foreach (var entityId in branches)
            {
                var branch = m_context.game.GetEntityWithId(entityId);
                var targeters = TargetingHelpers.GetTargeters(m_context, branch);

//
//                var targetedByMiner = false;
//
//                foreach (var targeterID in targeters)
//                {
//                    var targeter = m_context.GetEntityWithId(targeterID);
//
//                    if (targeter.isMiner)
//                    {
//                        targetedByMiner = true;
//                        break;
//                    }
//                }

//                if (targetedByMiner == false) availableBranches++;

                
                if (targeters.Count > 0) //targeted
                {
                    availableBranches--;
                }
            }

            return availableBranches;
        }
    }
}