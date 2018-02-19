using AI.Goap.Handler;
using UnityEngine;

namespace Assets.Scripts.AI.Goals
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