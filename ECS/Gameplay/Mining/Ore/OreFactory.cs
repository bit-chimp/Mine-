﻿using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Data;
using ECS.Core.Movement;
using UnityEngine;

namespace Assets.Sources.Gameplay.Mining.Ore
{
    public static class OreFactory
    {
        private static readonly Stat OrePieces = new Stat(500, .7f);
        private static readonly Stat BaseBranchHealthPercentage = new Stat(15, .7f);

        public static GameEntity CreateOreVein(GameContext context, Vector2 pos)
        {
            var e = context.CreateEntity();
            e.AddPrefab("Prefabs/Ore/ore_vein");
            e.AddPosition(pos);

            e.isOre = true;
            e.isOreVein = true;
            e.isKillable = true;
            
            e.isOnGround = true;
            e.isMouseListener = true;

            var pieces = StatCalculator.CalculateAsInt(OrePieces, 1);
            e.AddHealth(pieces, pieces);
            return e;
        }

        public static GameEntity CreateOreBranch(GameContext context, GameEntity vein, Vector2 position)
        {
            var e = context.CreateEntity();
            e.AddSprite("ore_branch");
            e.AddPosition(position);
            var health = StatCalculator.Calculate(BaseBranchHealthPercentage, 1);
            e.AddHealth(health, health);

            e.isOre = true;
            e.isOreBranch = true;
            e.isKillable = true;
            e.isRemovedWhenDead = true;
            
            e.AddParent(vein.id.value);
            e.isOnGround = true;
 
            if (vein.hasBag == false) vein.AddBag(new List<int>());

            vein.bag.items.Add(e.id.value);
            return e;
        }

        public static GameEntity CreateOrePiece(GameContext context, Vector2 pos)
        {
            var e = context.CreateEntity();
            e.AddPrefab("Prefabs/Ore/ore_piece");
            e.AddPosition(pos);
            e.isOre = true;
            e.isOrePiece = true;
            e.isMouseListener = true;
            e.isAffectedByGravity = true;
            e.AddFriction(.8f);
            return e;
        }
    }
}