using Libraries.btcp.src.Extensions;

namespace Mine.AI.Goap.Goals
{
    public class MineGoal : EntityGoapGoal
    {
        public MineGoal()
        {
            m_goalState.Set("oreAcquired", true);
        }
    
    
    }
}