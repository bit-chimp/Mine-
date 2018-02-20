using Libraries.btcp.Goap.src.Core;
using Libraries.btcp.src.Extensions;
using UnityEngine;


namespace Mine.AI.Goap.Actions
{
    public class TargetMinersAction : EntityGoapAction
    {
        public TargetMinersAction()
        {
            SetPostEffect("hasMinerTargeted", true);
            SetPostEffect("hasTarget", true);
        }

        public override bool ValidateAction()
        {
            return m_agent.HasMatchingTargetInSight(GameMatcher.Miner);
        }

        public override void OnRun(GoapState goalState)
        {
            var targets = m_agent.GetMatchingTargetsInSight(GameMatcher.AllOf(GameMatcher.Miner).NoneOf(GameMatcher.Dead));
            if (targets.Count == 0)
            {
                OnFailed();
                return;
            }
            
            //Target random miner
            
            m_agent.SetTarget(targets[Random.Range(0, targets.Count)]);


            OnComplete();
        }
    }
}