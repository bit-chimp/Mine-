using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.AI.Actions;
using Assets.Scripts.AI.Goals;
using Assets.Scripts.Data;
using ECS.AI.Goap;
using ECS.AI.Sensors.Sight;
using ECS.Combat;
using ECS.Core.Movement;
using Mine.Combat;
using Mine.Combat.Attacks;
using unity.Helpers.Animations;
using UnityEngine;

namespace Assets.Sources.Gameplay.Mining.Miner
{
    public static class MinerFactory
    {
        public enum MinerState
        {
            Idle = 0,
            Moving = 1,
            Mining = 2
        }


        private static readonly Stat BaseHealth = new Stat(5, .7f);
        private static readonly Stat BaseMoveSpeed = new Stat(2, .7f);
        private static readonly Stat BaseMiningDamage = new Stat(1, .7f);
        private static readonly Stat BaseMiningSpeed = new Stat(1, .7f);
        public static string MINER_ANIMATION_IDLE = "idle";
        public static string MINER_ANIMATION_MOVE = "move";
        public static string MINER_ANIMATION_DEATH = "death";
        public static string MINER_ANIMATION_MINE = "mine";
        public static string MINER_ANIMATION_CONTROLLER = "Art/Animation Controllers/miner_animation_controller";

        public static GameEntity CreateMiner(Contexts contexts, Vector2 pos)
        {
            var e = contexts.game.CreateEntity();
            e.AddPrefab("Prefabs/Miners/miner_grunt");
            e.AddPosition(pos);
            MovementHelpers.AddMovementComponents(e, 3f, .25f, .5f, .5f, .8f);
            SightHelpers.AddSightComponents(e, 10f);
            e.isMiner = true;

            var health = StatCalculator.Calculate(BaseHealth, 1);
            var damage = StatCalculator.Calculate(BaseMiningDamage, 1);
            var cooldown = StatCalculator.Calculate(BaseMiningSpeed, 1);
            CombatHelpers.AddCombatComponents(e, health, damage, cooldown);

            var animDirector = new AnimationDirector(e);
            e.AddAnimationDirector(animDirector);
            e.isKillable = true;


            var agent = new EntityGoapAgent(contexts, e);
            agent.AddAction(new CloseRangeAttackAction());
            agent.AddAction(new GetCloseToTargetAction());
            agent.AddAction(new TargetOreBranchAction());
            agent.AddAction(new MineAction());
            agent.AddGoal(new AcquireOreGoal());
            e.AddGoapAgent(agent);


            var combatDirector = new CombatDirector(e);
            combatDirector.AddAttack(new MeleeAttack(e, "miner_grunt_mine_regular", new[] {24}));
            e.AddCombatDirector(combatDirector);

            e.AddBag(new List<int>());

            return e;
        }
    }
}