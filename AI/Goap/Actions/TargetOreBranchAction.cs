
using Libraries.btcp.ECS.src.AI.Sensors.Targeting;
using Libraries.btcp.Goap.src.Core;
using Libraries.btcp.src.Extensions;


namespace Mine.AI.Goap.Actions
{
    public class TargetOreBranchAction : EntityGoapAction
    {
        public TargetOreBranchAction()
        {
            SetPostEffect("hasOreTargeted", true);
            SetPostEffect("hasTarget", true);
        }

        public override bool ValidateContextPreconditions()
        {
            return m_agent.HasMatchingTargetInSight(GameMatcher.OreVein);
        }

        public override void OnRun(GoapState goalState)
        {
            if (m_agent.DoesCurrentTargetMatch(GameMatcher.OreBranch))
            {
                OnComplete();
                return;
            }

            if (HasValidTarget())
            {
                //TODO : Add wait time, executionTime > 60ms then Failed
                var branches = (m_agent.GetMatchingTargetsInSight(GameMatcher.OreBranch));
                foreach (var branchID in branches)
                {
                    var branch = m_agent.Contexts.game.GetEntityWithId(branchID);
                    if (TargetingHelpers.GetTargeters(m_agent.Contexts, branch).Count == 0)
                    {
                        m_agent.SetTarget(branchID);
                        OnComplete();
                        return;
                    }
                } //Wait till ore vein creates branch
            }

            if (m_agent.HasMatchingTargetInSight(GameMatcher.OreVein) == false)
            {
                OnFailed();
                return;
            }

            var oreVein = m_agent.GetMatchingTargetsInSight(GameMatcher.OreVein)[0];
            m_agent.SetTarget(oreVein);
        }

        private bool HasValidTarget()
        {
            if (m_agent.HasMatchingTargetInSight(GameMatcher.OreBranch) == false)
            {
                return false;
            }


            var targets = m_agent.GetMatchingTargetsInSight(GameMatcher.OreBranch);

            foreach (var branchID in targets)
            {
                //If branch targeted
                var branch = m_agent.Contexts.game.GetEntityWithId(branchID);
                if (TargetingHelpers.GetTargeters(m_agent.Contexts, branch).Count == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}