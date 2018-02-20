using Libraries.btcp.Goap.src.Handler;
using UnityEngine;

namespace Mine.AI.Goap.Goals
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