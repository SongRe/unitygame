using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicMeleeEnemyClass : CombatEntity, Subject
{
    // 2 attack, 2 def, 5 hp, 2 speed

    public BasicMeleeEnemyClass()
    {
        xp_value = 1;
        BaseStats = new Stats(2, 2, 5, 2);
        Health = BaseStats.MaxHealth;
    }

    public BasicMeleeEnemyClass(int level)
    {
        BaseStats = new Stats(2, 2, 5, 2);
    }

    public override void AddModifier(StatModifier modifier)
    {
        BaseStats = modifier.applyModifier(BaseStats);
    }

    public override void Attacked(ref CombatEntity attacker)
    {
        Stats enemyStats = attacker.getStats();
        Health -= (enemyStats.Attack - BaseStats.Defense * 0.1f);
        if (Health <= 0)
        {
            attacker.OnKill(this);
            notifyObservers(EnemyConstants.OBSERVER_MESSAGE.ENEMY_DEATH);
        }
    }

    public override void Attacked(Ability ability, ref CombatEntity attacker)
    {
        AbilityStats enemyStats = ability.getAbilityStats();
        Health -= (enemyStats.attackValue - BaseStats.Defense * 0.1f);
        if (Health <= 0)
        {
            attacker.OnKill(this);
            notifyObservers(EnemyConstants.OBSERVER_MESSAGE.ENEMY_DEATH);
        }
    }

    public override float getHealth()
    {
        return Health;
    }

    public override Stats getStats()
    {
        return BaseStats;
    }


    public override void OnKill(CombatEntity killed_entity)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return "Basic Melee Enemy";
    }
}
