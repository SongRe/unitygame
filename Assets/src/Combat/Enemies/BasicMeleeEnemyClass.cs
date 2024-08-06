using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeleeEnemyClass : CombatEntity
{
    // 2 attack, 2 def, 5 hp, 2 speed

    public BasicMeleeEnemyClass()
    {
        xp_value = 1;
        BaseStats = new Stats(2, 2, 5, 2);
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
        
    }

    public override float getHealth()
    {
        return Health;
    }

    public override Stats getStats()
    {
        return BaseStats;
    }


    public override void OnKill(ref CombatEntity killed_entity)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return "Basic Melee Enemy";
    }
}
