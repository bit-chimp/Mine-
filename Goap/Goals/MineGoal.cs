using ECS.AI.Goap;

public class MineGoal : EntityGoapGoal
{
    public MineGoal()
    {
        m_goalState.Set("oreAcquired", true);
    }
    
    
}