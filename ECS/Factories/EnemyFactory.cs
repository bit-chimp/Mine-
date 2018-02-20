
using Libraries.btcp.ECS.src.AI.Sensors.Sight;
using Libraries.btcp.ECS.src.Combat;
using Libraries.btcp.ECS.src.Core.Movement;
using Libraries.btcp.RPG_Core.src.Combat.Attacks;
using Libraries.btcp.RPG_Core.src.Directors.Animation;
using Libraries.btcp.RPG_Core.src.Directors.Combat.Core;
using Libraries.btcp.src.Extensions;
using Mine.AI.Goap.Actions;
using Mine.AI.Goap.Goals;
using UnityEngine;

namespace Mine.ECS.Factories
{
    public static class EnemyFactory
    {
        public static GameEntity CreateEnemy(Contexts contexts, Vector2 pos)
        {
            var enemy = contexts.game.CreateEntity();
            enemy.AddPrefab("Prefabs/Enemies/spider");
            enemy.AddPosition(pos);
            enemy.isEnemy = true;
            
            MovementHelpers.AddMovementComponents(enemy, 2f, .25f, .5f, .8f, 1f);
            SightHelpers.AddSightComponents(enemy, 50);
            CombatHelpers.AddCombatComponents(enemy, 5f, 3f, .5f);
            
            var agent = new EntityGoapAgent(contexts, enemy);
            agent.AddAction(new CloseRangeAttackAction());
            agent.AddAction(new GetCloseToTargetAction());
            agent.AddAction(new TargetMinersAction());
            agent.AddGoal(new DestroyMineGoal());
            enemy.AddGoapAgent(agent);


            var animDirector = new AnimationDirector(enemy);
            enemy.AddAnimationDirector(animDirector);

            var combatDirector = new CombatDirector(enemy);
            combatDirector.AddAttack(new MeleeAttack(enemy, "spider_walk", new []{ 24}));
            enemy.AddCombatDirector(combatDirector);

            return enemy;
        }
    }
}