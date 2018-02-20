using Libraries.btcp.Goap.src.Handler;
using UnityEngine;

namespace Mine.AI.Goap.Goals
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