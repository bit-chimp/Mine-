using Assets.Scripts.AI.Actions;
using Assets.Scripts.AI.Goals;
using ECS.AI.Goap;
using ECS.AI.Sensors.Sight;
using ECS.Combat;
using ECS.Core.Parenting;
using Mine.Combat;
using Mine.Combat.Attacks;
using unity.Helpers.Animations;
using UnityEngine;

namespace Mine.ECS.Gameplay.Defenses
{
    public static class DefenseFactory
    {
        public static void CreateTurret(Contexts contexts, Vector2 pos)
        {
            var turret = contexts.game.CreateEntity();

            turret.AddPosition(pos);
            turret.AddPrefab("Prefabs/Towers/tower_rifle");


            var muzzle = contexts.game.CreateEntity();
            muzzle.AddPrefab("Prefabs/Towers/tower_rifle_gun");
            muzzle.isLookingAtTarget = true;
            
            ParentingHelpers.AddParent(muzzle, turret, new Vector2(-0.056f, -0.118f));
            
            CombatHelpers.AddCombatComponents(muzzle, 5f, .2f, 3f);
            SightHelpers.AddSightComponents(muzzle, 10f);

            var turretAgent = new EntityGoapAgent(contexts, muzzle);
            turretAgent.AddGoal(new DefendMineGoal());
            turretAgent.AddAction(new TargetMineIntruderAction());
            turretAgent.AddAction(new RangeAttackAction());
            muzzle.AddGoapAgent(turretAgent);


            var turretAnim = new AnimationDirector(muzzle);
            muzzle.AddAnimationDirector(turretAnim);

            var turretCombat = new CombatDirector(muzzle);
            turretCombat.AddAttack(new MeleeAttack(muzzle, "tower_rifle_gun_fire", new []{3}));
            muzzle.AddCombatDirector(turretCombat);

        }
    }
}