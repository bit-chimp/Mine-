using Libraries.btcp.Goap.src.Handler;

namespace Mine.AI.Goap.Goals
{
    public class AcquireOreGoal : BaseGoapGoal
    {
        public AcquireOreGoal()
        {
            m_goalState.Set("oreAcquired", true);
        }

        public override void OnFinish()
        {
            base.OnFinish();
        }
    }
}