﻿using System.Linq;
using UnityEngine;

namespace Feng.Battle
{
    public class AttackSystem : MonoBehaviour
    {
        public static AttackSystem instance;
        void Awake()
        {
            instance = this;
        }

        public void PerformAttack(int atk, Bounds position)
        {
            var damagers = FindBattleUnitInRange(position);
            foreach (var damager in damagers)
            {
                damager.OnDamage(atk);
            }
        }

        public BattleUnit[] FindBattleUnitInRange(Bounds bounds)
        {
            var battleUnits = FindAllBattleUnit();
            var rt = battleUnits.Where(unit =>
            {
                return unit.damageRange.bounds.Intersects(bounds);
            }).ToArray();
            return rt;
        }

        public BattleUnit[] FindAllBattleUnit()
        {
            return GameObject.FindObjectsOfType<BattleUnit>();
        }
    }
}