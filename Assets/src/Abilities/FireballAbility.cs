using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : Ability
{
    public FireballAbility()
    {
        abilityStats.cooldown = 1.0f;
        abilityStats.Speed = 50.0f;
        abilityStats.xScaling = 1.0f;
        abilityStats.yScaling = 1.0f;
        abilityStats.zScaling = 1.0f;
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
        abilityStats.cooldown = cd;
    }

    public override void setSpeed(float s)
    {
        abilityStats.Speed = s;
    }

    public override void setXScaling(float x)
    {
        abilityStats.xScaling = x;
    }

    public override void setYScaling(float y)
    {
        abilityStats.yScaling = y;
    }

    public override void setZScaling(float z)
    {
        abilityStats.zScaling = z;
    }
}
