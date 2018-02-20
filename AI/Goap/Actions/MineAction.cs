using Libraries.btcp.Goap.src.Core;
using Libraries.btcp.src.Extensions;

namespace Mine.AI.Goap.Actions
{
    public class MineAction : EntityGoapAction
    {
        public MineAction()
        {
            SetPreCondition("hasOreTargeted", true);
            SetPreCondition("isTargetKilled", true);
            SetPostEffect("oreAcquired", true);
        }

        public override void OnRun(GoapState goalState)
        {
            OnComplete();
        }
    }
}