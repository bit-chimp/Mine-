using AI.Goap.Core;
using ECS.AI.Goap;

namespace Assets.Scripts.AI.Actions
 {
     public class TargetMineIntruderAction : EntityGoapAction
     {
         public TargetMineIntruderAction()
         {
             SetPostEffect("hasMineIntruderTargeted", true);
             SetPostEffect("hasTarget", true);
         }

         public override bool ValidateContextPreconditions()
         {
             return m_agent.HasMatchingTargetInSight(GameMatcher.AllOf(GameMatcher.Enemy).NoneOf(GameMatcher.Dead));
         }

         public override void OnRun(GoapState goalState)
         {
             var targetID = m_agent.GetMatchingTargetsInSight(GameMatcher.AllOf(GameMatcher.Enemy).NoneOf(GameMatcher.Dead))[0];
             m_agent.SetTarget(targetID);
             OnComplete();
         }
     }
 }