using System.Collections.Generic;
using Entitas;
using Mine.UI;
using UnityEngine;

public class CreateHealthBarsSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;

    private IGroup<GameEntity> m_healthBars;

    public CreateHealthBarsSystem(Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
        m_healthBars = m_contexts.game.GetGroup(GameMatcher.HealthBar);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TakeDamageComplete, GameMatcher.View));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isTakeDamageComplete && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.isEnemy)
            {
                //TODO : How can I get the damage dealt by opponent? I think I should use monobehaviours with entities, DamageUI that calls upon factory
                UI_Factory_Combat.CreateDamageTF(e.position.value, .5f);
                if (HasHealthBar(e) == false)
                {
                    UI_Factory_Combat.CreateHealthBar(e.id.value);
                }
            }
        }
    }

    private bool HasHealthBar(GameEntity e)
    {
        foreach (var bars in m_healthBars.GetEntities())
        {
            if (bars.healthBar.bar.DoesHealthBarBelongTo(e)) return true;
        }

        return false;
    }
}