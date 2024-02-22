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
    }
    public override void AddModifier(OnHitModifier modifier)
    {
        onHitModifiers.Add(modifier);
    }
    public override void AddModifier(AbilitySummonModifier a)
    {
        abilitySummonModifiers.Add(a);
    }

    public override AbilityStats getAbilityStats()
    {
        return new AbilityStats(abilityStats.Speed, abilityStats.xScaling, abilityStats.yScaling, abilityStats.zScaling, abilityStats.cooldown);
    }

    public override void setCooldown(float cd)
    {
        abilityStats.cooldown = Mathf.Max(0, cd);
    }

    public override void setSpeed(float s)
    {
        abilityStats.Speed = Mathf.Max(0, s);
    }

    public override void setXScaling(float x)
    {
        abilityStats.xScaling = Mathf.Max(0, x);
    }

    public override void setYScaling(float y)
    {
        abilityStats.yScaling = Mathf.Max(0, y);
    }

    public override void setZScaling(float z)
    {
        abilityStats.zScaling = Mathf.Max(0, z);
    }

    public override string ToString()
    {
        return "Pillar Ability: \n" +
            "Stats: \n" +
            "Speed: Test";
    }
}
