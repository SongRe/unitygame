using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAbility : Ability
{
    // Default abilityStat values 
    public PillarAbility()
    {
        abilityStats.Speed = 5.0f;
        abilityStats.xScaling = 1;
        abilityStats.yScaling = 1;
        abilityStats.zScaling = 1;
        abilityStats.cooldown = 2.0f;
        abilityStats.attackValue = 0.0f;
    }
    public override void AddModifier(OnHitModifier modifier)
    {
        onHitModifiers.Add(modifier);
    }
    public override void AddModifier(AbilitySummonModifier a)
    {
        abilitySummonModifiers.Add(a);
    }

    public override string ToString()
    {
        return "Pillar Ability: \n" +
            "Stats: \n" +
            "Speed: Test";
    }
}
