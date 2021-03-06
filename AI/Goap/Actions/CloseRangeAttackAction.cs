﻿using Libraries.btcp.Goap.src.Core;
using Libraries.btcp.src.Extensions;

namespace Mine.AI.Goap.Actions
{
    public class CloseRangeAttackAction : EntityGoapAction
    {
        public CloseRangeAttackAction()
        {
            SetPreCondition("isNearTarget", true);
            SetPostEffect("isTargetKilled", true);
        }

        public override bool ValidateAction()
        {
            return m_agent.HasTarget() && IsTargetDead() == false && m_agent.Entity.isAttacking == false;
        }

        public override void OnBegin(GoapState goalState)
        {
            if (m_agent.Entity.combatDirector.director.DoAttack() == false)
            {
                OnFailed();
                return;
            }
        }

        public override void OnRun(GoapState goalState)
        {
            
            var entity = m_agent.Entity;
            
            if (entity.isAttackComplete)
            {
                if (entity.hasTarget == false || IsTargetDead())
                {
                    OnComplete();
                    return;
                }
                
                OnFailed();
            }
        }
        

        private bool IsTargetDead()
        { 
            var target = m_agent.GetTarget();
            return target.isDead;
        }
    }
}