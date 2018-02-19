using AI.Goap.Core;
using ECS.AI.Goap;

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