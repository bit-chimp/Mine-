using AI.Goap.Handler;
using UnityEngine;

namespace Assets.Scripts.AI.Goals
{
    public class DefendMineGoal : BaseGoapGoal
    {
        public DefendMineGoal()
        {
            m_goalState.Set("isTargetKilled", true);
        }

        public override void OnFinish()
        {
            Debug.Log("Mine Defended!");
            base.OnFinish();
        }
    }
}