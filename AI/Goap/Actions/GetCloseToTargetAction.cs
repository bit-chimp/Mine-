using Libraries.btcp.Goap.src.Core;
using Libraries.btcp.src.Extensions;
using UnityEngine;

namespace Mine.AI.Goap.Actions
{
    public class GetCloseToTargetAction : EntityGoapAction
    {
        public GetCloseToTargetAction()
        {
            SetPreCondition("hasTarget", true);
            SetPostEffect("isNearTarget", true);
        }

        private Vector2 m_targetPosition;
        private bool m_isInitialized = false;

        public override void OnPrepare(IGoapAgent agent)
        {
            m_isInitialized = false;
            base.OnPrepare(agent);
        }

        public override void OnBegin(GoapState state)
        {
            if (m_agent.HasTarget() == false)
            {
                OnFailed();
                return;
            }

            m_targetPosition = m_agent.GetTarget().position.value;
            m_isInitialized = true;
            base.OnBegin(state);
        }

        public override void OnInterrupted()
        {
            //If I'm currently moving, change my plans
            if (m_agent.Entity.hasMove)
            {
                m_agent.Entity.RemoveMove();
            }

            base.OnInterrupted();
        }

        public override bool ValidateAction()
        {
            var didTargetMove = false;

            if (m_isInitialized)
            {
                if (DidTargetMove()) return false;
            }
            

            return m_agent.HasTarget();
        }

    
        public override void OnRun(GoapState goalState)
        {
            var target = m_agent.GetTarget();
            if (target == null)
            {
                OnFailed();
                return;
            }


            var entity = m_agent.Entity;

            if (entity.isMoveComplete)
            {
                OnComplete();
                return;
            }

            if (DidTargetMove())
            {
                OnFailed();
                return;
            }


            if (entity.hasMove)
            {
                return;
            }

            entity.AddMove(m_targetPosition);

            base.OnRun(goalState);
        }

        private bool DidTargetMove()
        {
            var targetPos = m_agent.GetTarget().position.value;
            //Target moved
            return (m_targetPosition != targetPos);
        }
    }
}