using Libraries.btcp.ECS.src.AI.Sensors.Sight;
using Libraries.btcp.ECS.src.Combat;
using Libraries.btcp.ECS.src.Core.Parenting;
using Libraries.btcp.RPG_Core.src.Combat.Attacks;
using Libraries.btcp.RPG_Core.src.Directors.Animation;
using Libraries.btcp.RPG_Core.src.Directors.Combat.Core;
using Libraries.btcp.src.Extensions;
using Mine.AI.Goap.Actions;
using Mine.AI.Goap.Goals;
using UnityEngine;

namespace Mine.ECS.Factories
{
    public static class DefenseFactory
    {
        public static GameEntity CreateTurret(Contexts contexts, Vector2 pos)
        {
            var turret = contexts.game.CreateEntity();

            turret.AddPosition(pos);
            turret.AddPrefab("Prefabs/Towers/tower_rifle");


            var muzzle = contexts.game.CreateEntity();
            muzzle.AddPrefab("Prefabs/Towers/tower_rifle_gun");
            muzzle.isLookingAtTarget = true;

            muzzle.AddParent(turret.id.value);
            muzzle.AddPositionOffset(new Vector2(-0.056f, -0.118f));

            CombatHelpers.AddCombatComponents(muzzle, 5f, .5f, .1f);
            SightHelpers.AddSightComponents(muzzle, 10f);

            var turretAgent = new EntityGoapAgent(contexts, muzzle);
            turretAgent.AddGoal(new DefendMineGoal());
            turretAgent.AddAction(new TargetMineIntruderAction());
            turretAgent.AddAction(new RangeAttackAction());
            muzzle.AddGoapAgent(turretAgent);


            var turretAnim = new AnimationDirector(muzzle);
            muzzle.AddAnimationDirector(turretAnim);

            var turretCombat = new CombatDirector(muzzle);
            turretCombat.AddAttack(new MeleeAttack(muzzle, "tower_rifle_gun_fire", new[] {3}));
            muzzle.AddCombatDirector(turretCombat);
            return turret;
        }
    }
}