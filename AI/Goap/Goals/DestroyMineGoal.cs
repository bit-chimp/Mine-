using AI.Goap.Handler;
using UnityEngine;

namespace Assets.Scripts.AI.Goals
{
    public class DestroyMineGoal : BaseGoapGoal
    {
        public DestroyMineGoal()
        {
            m_goalState.Set("isTargetKilled", true);
        }

        public override void OnFinish()
        {
            Debug.Log("Mine Killed!");
            base.OnFinish();
        }
    }
}